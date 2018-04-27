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
using DABHandIN3_2v2.Intefaces;
using DABHandIN3_2v2.Models;

namespace DABHandIN3_2v2.Controllers
{
    public class PhoneNumbersController : ApiController
    {
        private DABHandIN3_2v2Context db = new DABHandIN3_2v2Context();
        private readonly IUnitOfWork _unitOfWork;

        public PhoneNumbersController()
        {
            _unitOfWork = new UnitOfWork(db);
        }   
            

        // GET: api/PhoneNumbers
        public IEnumerable<PhoneNumber> GetPhoneNumbers()
        {
            var model = _unitOfWork.PhoneRepository.GetAll();
            return model;
        }

        // GET: api/PhoneNumbers/5
        [ResponseType(typeof(PhoneNumber))]
        public async Task<IHttpActionResult> GetPhoneNumber(int id)
        {
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

           _unitOfWork.PhoneRepository.Add(phoneNumber);

            try
            {
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

            _unitOfWork.PhoneRepository.Add(phoneNumber);
            _unitOfWork.Save();

            return CreatedAtRoute("DefaultApi", new { id = phoneNumber.Id }, phoneNumber);
        }

        // DELETE: api/PhoneNumbers/5
        [ResponseType(typeof(PhoneNumber))]
        public async Task<IHttpActionResult> DeletePhoneNumber(int id)
        {
            PhoneNumber phoneNumber = _unitOfWork.PhoneRepository.GetById(id);
            if (phoneNumber == null)
            {
                return NotFound();
            }

            _unitOfWork.PhoneRepository.Delete(phoneNumber);
            _unitOfWork.Save();

            return Ok(phoneNumber);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
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