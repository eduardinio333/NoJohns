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
using NoJohns.API.Models;

namespace NoJohns.API.Controllers
{
    public class ProceduresController : ApiController
    {
        private NoJohnsModelContainer db = new NoJohnsModelContainer();

        // GET: api/Procedures
        public IQueryable<Procedures> GetProceduresSet()
        {
            return db.ProceduresSet;
        }

        // GET: api/Procedures/5
        [ResponseType(typeof(Procedures))]
        public async Task<IHttpActionResult> GetProcedures(int id)
        {
            Procedures procedures = await db.ProceduresSet.FindAsync(id);
            if (procedures == null)
            {
                return NotFound();
            }

            return Ok(procedures);
        }

        // PUT: api/Procedures/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProcedures(int id, Procedures procedures)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != procedures.Id)
            {
                return BadRequest();
            }

            db.Entry(procedures).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProceduresExists(id))
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

        // POST: api/Procedures
        [ResponseType(typeof(Procedures))]
        public async Task<IHttpActionResult> PostProcedures(Procedures procedures)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProceduresSet.Add(procedures);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = procedures.Id }, procedures);
        }

        // DELETE: api/Procedures/5
        [ResponseType(typeof(Procedures))]
        public async Task<IHttpActionResult> DeleteProcedures(int id)
        {
            Procedures procedures = await db.ProceduresSet.FindAsync(id);
            if (procedures == null)
            {
                return NotFound();
            }

            db.ProceduresSet.Remove(procedures);
            await db.SaveChangesAsync();

            return Ok(procedures);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProceduresExists(int id)
        {
            return db.ProceduresSet.Count(e => e.Id == id) > 0;
        }
    }
}