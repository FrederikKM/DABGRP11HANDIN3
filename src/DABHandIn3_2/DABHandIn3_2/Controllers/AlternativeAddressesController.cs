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
using DABHandIn3_2.Models;

namespace DABHandIn3_2.Controllers
{
    public class AlternativeAddressesController : ApiController
    {
        private DABHandIn3_2Context db = new DABHandIn3_2Context();

        // GET: api/AlternativeAddresses
        public IQueryable<AlternativeAddress> GetAlternativeAddresses()
        {
            return db.AlternativeAddresses;
        }

        // GET: api/AlternativeAddresses/5
        [ResponseType(typeof(AlternativeAddress))]
        public async Task<IHttpActionResult> GetAlternativeAddress(int id)
        {
            AlternativeAddress alternativeAddress = await db.AlternativeAddresses.FindAsync(id);
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

            db.Entry(alternativeAddress).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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

            db.AlternativeAddresses.Add(alternativeAddress);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = alternativeAddress.Id }, alternativeAddress);
        }

        // DELETE: api/AlternativeAddresses/5
        [ResponseType(typeof(AlternativeAddress))]
        public async Task<IHttpActionResult> DeleteAlternativeAddress(int id)
        {
            AlternativeAddress alternativeAddress = await db.AlternativeAddresses.FindAsync(id);
            if (alternativeAddress == null)
            {
                return NotFound();
            }

            db.AlternativeAddresses.Remove(alternativeAddress);
            await db.SaveChangesAsync();

            return Ok(alternativeAddress);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlternativeAddressExists(int id)
        {
            return db.AlternativeAddresses.Count(e => e.Id == id) > 0;
        }
    }
}