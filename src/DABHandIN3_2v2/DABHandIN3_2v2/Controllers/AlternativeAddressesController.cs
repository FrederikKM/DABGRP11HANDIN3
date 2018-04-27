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
    public class AlternativeAddressesController : ApiController
    {
        private DABHandIN3_2v2Context db = new DABHandIN3_2v2Context();
        private readonly IUnitOfWork _unitOfWork;

        public AlternativeAddressesController()
        {
            _unitOfWork = new UnitOfWork(db);
        }

        // GET: api/AlternativeAddresses
        public IEnumerable<AlternativeAddress> GetAlternativeAddresses()
        {
            var model = _unitOfWork.AltAddressRepository.GetAll();
            return model;
        }


        // GET: api/AlternativeAddresses/5
        [ResponseType(typeof(AlternativeAddress))]
        public async Task<IHttpActionResult> GetAlternativeAddress(int id)
        {
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

            _unitOfWork.AltAddressRepository.Add(alternativeAddress);

            try
            {
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

            _unitOfWork.AltAddressRepository.Add(alternativeAddress);
            _unitOfWork.Save();

            return CreatedAtRoute("DefaultApi", new { id = alternativeAddress.Id }, alternativeAddress);
        }

        // DELETE: api/AlternativeAddresses/5
        [ResponseType(typeof(AlternativeAddress))]
        public async Task<IHttpActionResult> DeleteAlternativeAddress(int id)
        {
            AlternativeAddress alternativeAddress = _unitOfWork.AltAddressRepository.GetById(id);
            if (alternativeAddress == null)
            {
                return NotFound();
            }

            _unitOfWork.AltAddressRepository.Delete(alternativeAddress);
            _unitOfWork.Save();

            return Ok(alternativeAddress);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Save();
            }
            base.Dispose(disposing);
        }

        private bool AlternativeAddressExists(int id)
        {
            return db.AlternativeAddresses.Count(e => e.Id == id) > 0;
        }
    }
}