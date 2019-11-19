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
    public class JusProceduresController : ApiController
    {
        private DADEntities db = new DADEntities();

        // GET: api/JusProcedures
        public IQueryable<JusProcedure> GetJusProcedures()
        {
            return db.JusProcedures;
        }

        // GET: api/JusProcedures/5
        [ResponseType(typeof(JusProcedure))]
        public IHttpActionResult GetJusProcedure(int id)
        {
            JusProcedure jusProcedure = db.JusProcedures.Find(id);
            if (jusProcedure == null)
            {
                return NotFound();
            }

            return Ok(jusProcedure);
        }

        // PUT: api/JusProcedures/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJusProcedure(int id, JusProcedure jusProcedure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jusProcedure.ProcedureID)
            {
                return BadRequest();
            }

            db.Entry(jusProcedure).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JusProcedureExists(id))
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

        // POST: api/JusProcedures
        [ResponseType(typeof(JusProcedure))]
        public IHttpActionResult PostJusProcedure(JusProcedure jusProcedure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JusProcedures.Add(jusProcedure);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (JusProcedureExists(jusProcedure.ProcedureID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = jusProcedure.ProcedureID }, jusProcedure);
        }

        // DELETE: api/JusProcedures/5
        [ResponseType(typeof(JusProcedure))]
        public IHttpActionResult DeleteJusProcedure(int id)
        {
            JusProcedure jusProcedure = db.JusProcedures.Find(id);
            if (jusProcedure == null)
            {
                return NotFound();
            }

            db.JusProcedures.Remove(jusProcedure);
            db.SaveChanges();

            return Ok(jusProcedure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JusProcedureExists(int id)
        {
            return db.JusProcedures.Count(e => e.ProcedureID == id) > 0;
        }
    }
}