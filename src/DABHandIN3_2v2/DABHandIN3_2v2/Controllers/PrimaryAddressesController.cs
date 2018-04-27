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
    public class PrimaryAddressesController : ApiController
    {
        private DABHandIN3_2v2Context db = new DABHandIN3_2v2Context();
        private readonly IUnitOfWork _unitOfWork;

        public PrimaryAddressesController()
        {
            _unitOfWork = new UnitOfWork(db);
        }

        // GET: api/PrimaryAddresses
        public IEnumerable<PrimaryAddress> GetPrimaryAddresses()
        {
            var model = _unitOfWork.PrimaryAddressRepository.GetAll();
            return model;
        }

        // GET: api/PrimaryAddresses/5
        [ResponseType(typeof(PrimaryAddress))]
        public async Task<IHttpActionResult> GetPrimaryAddress(int id)
        {
            PrimaryAddress primaryAddress = _unitOfWork.PrimaryAddressRepository.GetById(id);
            if (primaryAddress == null)
            {
                return NotFound();
            }

            return Ok(primaryAddress);
        }

        // PUT: api/PrimaryAddresses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPrimaryAddress(int id, PrimaryAddress primaryAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != primaryAddress.Id)
            {
                return BadRequest();
            }

           _unitOfWork.PrimaryAddressRepository.Add(primaryAddress);

            try
            {
                _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrimaryAddressExists(id))
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

        // POST: api/PrimaryAddresses
        [ResponseType(typeof(PrimaryAddress))]
        public async Task<IHttpActionResult> PostPrimaryAddress(PrimaryAddress primaryAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.PrimaryAddressRepository.Add(primaryAddress);
            _unitOfWork.Save();

            return CreatedAtRoute("DefaultApi", new { id = primaryAddress.Id }, primaryAddress);
        }

        // DELETE: api/PrimaryAddresses/5
        [ResponseType(typeof(PrimaryAddress))]
        public async Task<IHttpActionResult> DeletePrimaryAddress(int id)
        {
            PrimaryAddress primaryAddress = _unitOfWork.PrimaryAddressRepository.GetById(id);
            if (primaryAddress == null)
            {
                return NotFound();
            }

            _unitOfWork.PrimaryAddressRepository.Delete(primaryAddress);
            _unitOfWork.Save();

            return Ok(primaryAddress);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Save();
            }
            base.Dispose(disposing);
        }

        private bool PrimaryAddressExists(int id)
        {
            return db.PrimaryAddresses.Count(e => e.Id == id) > 0;
        }
    }
}