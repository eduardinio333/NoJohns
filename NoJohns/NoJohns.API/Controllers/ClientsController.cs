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
using NoJohns.API.Models.Requests;

namespace NoJohns.API.Controllers
{
    [RoutePrefix("api/Clients")]
    public class ClientsController : ApiController
    {
        private NoJohnsModelContainer db = new NoJohnsModelContainer();

        // GET: api/Clients
        public IQueryable<Clients> GetClientsSet()
        {
            return db.ClientsSet;
        }

        // GET: api/Clients/{Username}
        // GET: api/Clients/5
        [ResponseType(typeof(Clients))]
        public async Task<IHttpActionResult> GetClients(int id)
        {
            Clients clients = await db.ClientsSet.FindAsync(id);
            if (clients == null)
            {
                return NotFound();
            }

            return Ok(clients);
        }

        [ResponseType(typeof(Clients))]
        public async Task<IHttpActionResult> GetClients(string request)
        {
            var oRequest = BaseRequest.ToRequest<ClientRequest>(request);
            IEnumerable<Clients> clients = db.ClientsSet.AsEnumerable();

            clients = oRequest.FilterRequest(clients);

            if (clients == null)
            {
                return NotFound();
            }

            return Ok(clients);
        }

        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClients(int id, Clients clients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clients.Id)
            {
                return BadRequest();
            }

            db.Entry(clients).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientsExists(id))
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

        // POST: api/Clients
        [ResponseType(typeof(Clients))]
        public async Task<IHttpActionResult> PostClients(Clients clients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClientsSet.Add(clients);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = clients.Id }, clients);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Clients))]
        public async Task<IHttpActionResult> DeleteClients(int id)
        {
            Clients clients = await db.ClientsSet.FindAsync(id);
            if (clients == null)
            {
                return NotFound();
            }

            db.ClientsSet.Remove(clients);
            await db.SaveChangesAsync();

            return Ok(clients);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientsExists(int id)
        {
            return db.ClientsSet.Count(e => e.Id == id) > 0;
        }
    }
}