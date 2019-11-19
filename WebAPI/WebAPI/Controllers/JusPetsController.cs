using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class JusPetsController : ApiController
    {
        private DADEntities db = new DADEntities();

        // GET: api/JusPets
        public IQueryable<JusPet> GetJusPets()
        {
            return db.JusPets;
        }

        // GET: api/JusPets/5
        [ResponseType(typeof(JusPet))]
        public IHttpActionResult GetJusPet(string id)
        {
            JusPet jusPet = db.JusPets.Find(id);
            if (jusPet == null)
            {
                return NotFound();
            }

            return Ok(jusPet);
        }

        // PUT: api/JusPets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJusPet(string id, JusPet jusPet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jusPet.PetName)
            {
                return BadRequest();
            }

            db.Entry(jusPet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JusPetExists(id))
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

        // POST: api/JusPets
        [ResponseType(typeof(JusPet))]
        public IHttpActionResult PostJusPet(JusPet jusPet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JusPets.Add(jusPet);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (JusPetExists(jusPet.PetName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = jusPet.PetName }, jusPet);
        }

        // DELETE: api/JusPets/5
        [ResponseType(typeof(JusPet))]
        public IHttpActionResult DeleteJusPet(string id)
        {
            JusPet jusPet = db.JusPets.Find(id);
            if (jusPet == null)
            {
                return NotFound();
            }

            db.JusPets.Remove(jusPet);
            db.SaveChanges();

            return Ok(jusPet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JusPetExists(string id)
        {
            return db.JusPets.Count(e => e.PetName == id) > 0;
        }
    }
}