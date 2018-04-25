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
    public class PrimaryAddressesController : ApiController
    {
        private readonly DABHandIn3_2Context db = new DABHandIn3_2Context();
        private readonly IUnitOfWork _unitOfWork;

        public PrimaryAddressesController()
        {

        }

        public PrimaryAddressesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/PrimaryAddresses
        //** Changed IQueryable to IEnumerable** -> public IQueryable<PrimaryAddress> GetPrimaryAddresses()
        public IEnumerable<PrimaryAddress> GetPrimaryAddresses()
        {
            //return db.PrimaryAddresses;
            var model = _unitOfWork.PrimaryAddressRepository.GetAll();
            return model;
        }

        // GET: api/PrimaryAddresses/5
        [ResponseType(typeof(PrimaryAddress))]
        public async Task<IHttpActionResult> GetPrimaryAddress(int id)
        {
            //PrimaryAddress primaryAddress = await db.PrimaryAddresses.FindAsync(id);
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

            //db.Entry(primaryAddress).State = EntityState.Modified;
            _unitOfWork.PrimaryAddressRepository.Add(primaryAddress);

            try
            {
                //await db.SaveChangesAsync();
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

            //db.PrimaryAddresses.Add(primaryAddress);
            //await db.SaveChangesAsync();

            _unitOfWork.PrimaryAddressRepository.Add(primaryAddress);
            _unitOfWork.Save();

            return CreatedAtRoute("DefaultApi", new { id = primaryAddress.Id }, primaryAddress);
        }

        // DELETE: api/PrimaryAddresses/5
        [ResponseType(typeof(PrimaryAddress))]
        public async Task<IHttpActionResult> DeletePrimaryAddress(int id)
        {
            //PrimaryAddress primaryAddress = await db.PrimaryAddresses.FindAsync(id);
            PrimaryAddress primaryAddress = _unitOfWork.PrimaryAddressRepository.GetById(id);
            if (primaryAddress == null)
            {
                return NotFound();
            }

            //db.PrimaryAddresses.Remove(primaryAddress);
            //await db.SaveChangesAsync();

            _unitOfWork.PrimaryAddressRepository.Delete(primaryAddress);
            _unitOfWork.Save();

            return Ok(primaryAddress);
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

        private bool PrimaryAddressExists(int id)
        {
            return db.PrimaryAddresses.Count(e => e.Id == id) > 0;
        }
    }
}