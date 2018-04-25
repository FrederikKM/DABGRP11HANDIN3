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
using System.Web.Mvc;
using DABHandIn3_2.Interfaces;
using DABHandIn3_2.Models;

namespace DABHandIn3_2.Controllers
{
    

    public class PersonController : ApiController
    {
        private readonly DABHandIn3_2Context db = new DABHandIn3_2Context();
        private readonly IUnitOfWork _unitOfWork;

        public PersonController()
        {
            
        }

        public PersonController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Person
       //** Changed IQueryable to IEnumerable** -> public IQueryable<Person> GetPeople()
        public IEnumerable<Person> GetPeople()
        {
           // return db.People;
            var model = _unitOfWork.PersonRepository.GetAll();
            return model;
        }

        // GET: api/Person/5
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> GetPerson(int id)
        {
            //Person person = await db.People.FindAsync(id);
            Person person = _unitOfWork.PersonRepository.GetById(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PUT: api/Person/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPerson(int id, Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.Id)
            {
                return BadRequest();
            }

            //db.Entry(person).State = EntityState.Modified;
            _unitOfWork.PersonRepository.Add(person);

            try
            {
                //await db.SaveChangesAsync();
                _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST: api/Person
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> PostPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.People.Add(person);
            _unitOfWork.PersonRepository.Add(person);

            try
            {
                //await db.SaveChangesAsync();
                _unitOfWork.Save();
            }
            catch (DbUpdateException)
            {
                if (PersonExists(person.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = person.Id }, person);
        }

        // DELETE: api/Person/5
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> DeletePerson(int id)
        {
            //Person person = await db.People.FindAsync(id);
            Person person = _unitOfWork.PersonRepository.GetById(id);
            if (person == null)
            {
                return NotFound();
            }

            //db.People.Remove(person);
            //await db.SaveChangesAsync();

            _unitOfWork.PersonRepository.Delete(person);
            _unitOfWork.Save();

            return Ok(person);
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
        
        private bool PersonExists(int id)
        {
            return db.People.Count(e => e.Id == id) > 0;
        }
        
    }
}