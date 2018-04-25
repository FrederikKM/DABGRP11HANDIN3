using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DABHandIn3_2.Interfaces;
using DABHandIn3_2.Models;

namespace DABHandIn3_2.Controllers
{
    public class PhoneNumbersController : ApiController
    {
        private readonly DABHandIn3_2Context db = new DABHandIn3_2Context();
        private readonly IUnitOfWork _unitOfWork;

        public PhoneNumbersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: api/PhoneNumbers
        //** Changed IQueryable to IEnumerable** -> public IQueryable<PhoneNumber> GetPhoneNumbers()
        public IEnumerable<PhoneNumber> GetPhoneNumbers()
        {
            // return db.PhoneNumbers;
            var model = _unitOfWork.PhoneRepository.GetAll();
            return model;
        }

        // GET: api/PhoneNumbers/5
        [ResponseType(typeof(PhoneNumber))]
        public async Task<IHttpActionResult> GetPhoneNumber(int id)
        {
            //PhoneNumber phoneNumber = await db.PhoneNumbers.FindAsync(id);
            PhoneNumber phoneNumber = _unitOfWork.PhoneRepository.GetById(id);
            if (phoneNumber == null)
            {
                return NotFound();
            }

            return Ok(phoneNumber);
        }

        // PUT: api/PhoneNumbers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPhoneNumber(int id, PhoneNumber phoneNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phoneNumber.Id)
            {
                return BadRequest();
            }

            //db.Entry(phoneNumber).State = EntityState.Modified;
            _unitOfWork.PhoneRepository.Add(phoneNumber);

            try
            {
                //await db.SaveChangesAsync();
                _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneNumberExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PhoneNumbers
        [ResponseType(typeof(PhoneNumber))]
        public async Task<IHttpActionResult> PostPhoneNumber(PhoneNumber phoneNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.PhoneNumbers.Add(phoneNumber);
            //await db.SaveChangesAsync();
            _unitOfWork.PhoneRepository.Add(phoneNumber);
            _unitOfWork.Save();

            return CreatedAtRoute("DefaultApi", new { id = phoneNumber.Id }, phoneNumber);
        }

        // DELETE: api/PhoneNumbers/5
        [ResponseType(typeof(PhoneNumber))]
        public async Task<IHttpActionResult> DeletePhoneNumber(int id)
        {
            //PhoneNumber phoneNumber = await db.PhoneNumbers.FindAsync(id);
            PhoneNumber phoneNumber = _unitOfWork.PhoneRepository.GetById(id);
            if (phoneNumber == null)
            {
                return NotFound();
            }

            //db.PhoneNumbers.Remove(phoneNumber);
            //await db.SaveChangesAsync();

            _unitOfWork.PhoneRepository.Delete(phoneNumber);
            _unitOfWork.Save();

            return Ok(phoneNumber);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhoneNumberExists(int id)
        {
            return db.PhoneNumbers.Count(e => e.Id == id) > 0;
        }
    }
}