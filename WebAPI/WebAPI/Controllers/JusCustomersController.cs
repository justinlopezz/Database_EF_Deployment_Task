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
    public class JusCustomersController : ApiController
    {
        private DADEntities db = new DADEntities();

        // GET: api/JusCustomers
        public IQueryable<JusCustomer> GetJusCustomers()
        {
            return db.JusCustomers;
        }

        // GET: api/JusCustomers/5
        [ResponseType(typeof(JusCustomer))]
        public IHttpActionResult GetJusCustomer(int id)
        {
            JusCustomer jusCustomer = db.JusCustomers.Find(id);
            if (jusCustomer == null)
            {
                return NotFound();
            }

            return Ok(jusCustomer);
        }

        // PUT: api/JusCustomers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJusCustomer(int id, JusCustomer jusCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jusCustomer.OwnerID)
            {
                return BadRequest();
            }

            db.Entry(jusCustomer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JusCustomerExists(id))
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

        // POST: api/JusCustomers
        [ResponseType(typeof(JusCustomer))]
        public IHttpActionResult PostJusCustomer(JusCustomer jusCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JusCustomers.Add(jusCustomer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (JusCustomerExists(jusCustomer.OwnerID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = jusCustomer.OwnerID }, jusCustomer);
        }

        // DELETE: api/JusCustomers/5
        [ResponseType(typeof(JusCustomer))]
        public IHttpActionResult DeleteJusCustomer(int id)
        {
            JusCustomer jusCustomer = db.JusCustomers.Find(id);
            if (jusCustomer == null)
            {
                return NotFound();
            }

            db.JusCustomers.Remove(jusCustomer);
            db.SaveChanges();

            return Ok(jusCustomer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JusCustomerExists(int id)
        {
            return db.JusCustomers.Count(e => e.OwnerID == id) > 0;
        }
    }
}