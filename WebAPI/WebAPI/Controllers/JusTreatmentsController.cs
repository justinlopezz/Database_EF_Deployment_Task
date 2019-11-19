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
    public class JusTreatmentsController : ApiController
    {
        private DADEntities db = new DADEntities();

        // GET: api/JusTreatments
        public IQueryable<JusTreatment> GetJusTreatments()
        {
            return db.JusTreatments;
        }

        // GET: api/JusTreatments/5
        [ResponseType(typeof(JusTreatment))]
        public IHttpActionResult GetJusTreatment(DateTime id)
        {
            JusTreatment jusTreatment = db.JusTreatments.Find(id);
            if (jusTreatment == null)
            {
                return NotFound();
            }

            return Ok(jusTreatment);
        }

        // PUT: api/JusTreatments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJusTreatment(DateTime id, JusTreatment jusTreatment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jusTreatment.Date)
            {
                return BadRequest();
            }

            db.Entry(jusTreatment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JusTreatmentExists(id))
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

        // POST: api/JusTreatments
        [ResponseType(typeof(JusTreatment))]
        public IHttpActionResult PostJusTreatment(JusTreatment jusTreatment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JusTreatments.Add(jusTreatment);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (JusTreatmentExists(jusTreatment.Date))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = jusTreatment.Date }, jusTreatment);
        }

        // DELETE: api/JusTreatments/5
        [ResponseType(typeof(JusTreatment))]
        public IHttpActionResult DeleteJusTreatment(DateTime id)
        {
            JusTreatment jusTreatment = db.JusTreatments.Find(id);
            if (jusTreatment == null)
            {
                return NotFound();
            }

            db.JusTreatments.Remove(jusTreatment);
            db.SaveChanges();

            return Ok(jusTreatment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JusTreatmentExists(DateTime id)
        {
            return db.JusTreatments.Count(e => e.Date == id) > 0;
        }
    }
}