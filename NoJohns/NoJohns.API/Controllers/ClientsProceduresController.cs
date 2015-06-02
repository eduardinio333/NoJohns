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
using NoJohns.Portable;

namespace NoJohns.API.Controllers
{
    public class ClientsProceduresController : ApiController
    {
        private NoJohnsModelContainer db = new NoJohnsModelContainer();

        // GET: api/ClientsProcedures
        public IQueryable<ClientsProcedures> GetClientsProceduresSet()
        {
            return db.ClientsProceduresSet;
        }

        // GET: api/ClientsProcedures/5
        [ResponseType(typeof(ClientsProcedures))]
        public async Task<IHttpActionResult> GetClientsProcedures(int id)
        {
            ClientsProcedures clientsProcedures = await db.ClientsProceduresSet.FindAsync(id);
            if (clientsProcedures == null)
            {
                return NotFound();
            }

            return Ok(clientsProcedures);
        }
        [Route("api/ClientsProcedures/Client/{ClientId}")]
        public dynamic GetProcedureByClient(int ClientId)
        {
            ClientsProcedures customer = db.ClientsProceduresSet.Find(ClientId );
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/ClientsProcedures/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClientsProcedures(int id, ClientsProcedures clientsProcedures)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientsProcedures.Id)
            {
                return BadRequest();
            }

            db.Entry(clientsProcedures).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientsProceduresExists(id))
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

        // POST: api/ClientsProcedures
        [ResponseType(typeof(ClientsProcedures))]
        public async Task<IHttpActionResult> PostClientsProcedures(ClientsProcedures clientsProcedures)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClientsProceduresSet.Add(clientsProcedures);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = clientsProcedures.Id }, clientsProcedures);
        }

        // DELETE: api/ClientsProcedures/5
        [ResponseType(typeof(ClientsProcedures))]
        public async Task<IHttpActionResult> DeleteClientsProcedures(int id)
        {
            ClientsProcedures clientsProcedures = await db.ClientsProceduresSet.FindAsync(id);
            if (clientsProcedures == null)
            {
                return NotFound();
            }

            db.ClientsProceduresSet.Remove(clientsProcedures);
            await db.SaveChangesAsync();

            return Ok(clientsProcedures);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientsProceduresExists(int id)
        {
            return db.ClientsProceduresSet.Count(e => e.Id == id) > 0;
        }
    }
}