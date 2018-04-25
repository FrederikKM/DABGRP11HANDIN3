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
    public class AlternativeAddressesController : ApiController
    {
        private readonly DABHandIn3_2Context db = new DABHandIn3_2Context();
        private readonly IUnitOfWork _unitOfWork;

        public AlternativeAddressesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: api/AlternativeAddresses
        //** Changed IQueryable to IEnumerable** -> public IQueryable<AlternativeAddress> GetAlternativeAddresses()
        public IEnumerable<AlternativeAddress> GetAlternativeAddresses()
        {
            //return db.AlternativeAddresses;
            var model = _unitOfWork.AltAddressRepository.GetAll();
            return model;
        }

        // GET: api/AlternativeAddresses/5
        [ResponseType(typeof(AlternativeAddress))]
        public async Task<IHttpActionResult> GetAlternativeAddress(int id)
        {
            //AlternativeAddress alternativeAddress = await db.AlternativeAddresses.FindAsync(id);
            AlternativeAddress alternativeAddress = _unitOfWork.AltAddressRepository.GetById(id);
            if (alternativeAddress == null)
            {
                return NotFound();
            }

            return Ok(alternativeAddress);
        }

        // PUT: api/AlternativeAddresses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAlternativeAddress(int id, AlternativeAddress alternativeAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alternativeAddress.Id)
            {
                return BadRequest();
            }

            //db.Entry(alternativeAddress).State = EntityState.Modified;
            _unitOfWork.AltAddressRepository.Add(alternativeAddress);

            try
            {
                //await db.SaveChangesAsync();
                _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlternativeAddressExists(id))
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

        // POST: api/AlternativeAddresses
        [ResponseType(typeof(AlternativeAddress))]
        public async Task<IHttpActionResult> PostAlternativeAddress(AlternativeAddress alternativeAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.AlternativeAddresses.Add(alternativeAddress);
            //await db.SaveChangesAsync();

            _unitOfWork.AltAddressRepository.Add(alternativeAddress);
            _unitOfWork.Save();

            return CreatedAtRoute("DefaultApi", new { id = alternativeAddress.Id }, alternativeAddress);
        }

        // DELETE: api/AlternativeAddresses/5
        [ResponseType(typeof(AlternativeAddress))]
        public async Task<IHttpActionResult> DeleteAlternativeAddress(int id)
        {
           // AlternativeAddress alternativeAddress = await db.AlternativeAddresses.FindAsync(id);
            AlternativeAddress alternativeAddress = _unitOfWork.AltAddressRepository.GetById(id);
            if (alternativeAddress == null)
            {
                return NotFound();
            }

            //db.AlternativeAddresses.Remove(alternativeAddress);
            //await db.SaveChangesAsync();

            _unitOfWork.AltAddressRepository.Delete(alternativeAddress);
            _unitOfWork.Save();

            return Ok(alternativeAddress);
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

        private bool AlternativeAddressExists(int id)
        {
            return db.AlternativeAddresses.Count(e => e.Id == id) > 0;
        }
    }
}