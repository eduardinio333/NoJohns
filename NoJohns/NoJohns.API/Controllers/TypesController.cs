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
    public class TypesController : ApiController
    {
        private NoJohnsModelContainer db = new NoJohnsModelContainer();

        // GET: api/Types
        public IQueryable<Types> GetTypesSet()
        {
            return db.TypesSet;
        }

        // GET: api/Types/5
        [ResponseType(typeof(Types))]
        public async Task<IHttpActionResult> GetTypes(int id)
        {
            Types types = await db.TypesSet.FindAsync(id);
            if (types == null)
            {
                return NotFound();
            }

            return Ok(types);
        }

        // PUT: api/Types/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTypes(int id, Types types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != types.Id)
            {
                return BadRequest();
            }

            db.Entry(types).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypesExists(id))
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

        // POST: api/Types
        [ResponseType(typeof(Types))]
        public async Task<IHttpActionResult> PostTypes(Types types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypesSet.Add(types);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = types.Id }, types);
        }

        // DELETE: api/Types/5
        [ResponseType(typeof(Types))]
        public async Task<IHttpActionResult> DeleteTypes(int id)
        {
            Types types = await db.TypesSet.FindAsync(id);
            if (types == null)
            {
                return NotFound();
            }

            db.TypesSet.Remove(types);
            await db.SaveChangesAsync();

            return Ok(types);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypesExists(int id)
        {
            return db.TypesSet.Count(e => e.Id == id) > 0;
        }
    }
}