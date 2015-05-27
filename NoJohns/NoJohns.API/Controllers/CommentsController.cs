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
    public class CommentsController : ApiController
    {
        private NoJohnsModelContainer db = new NoJohnsModelContainer();

        // GET: api/Comments
        public IQueryable<Comments> GetCommentsSet()
        {
            return db.CommentsSet;
        }

        // GET: api/Comments/5
        [ResponseType(typeof(Comments))]
        public async Task<IHttpActionResult> GetComments(int id)
        {
            Comments comments = await db.CommentsSet.FindAsync(id);
            if (comments == null)
            {
                return NotFound();
            }

            return Ok(comments);
        }

        // PUT: api/Comments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutComments(int id, Comments comments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comments.Id)
            {
                return BadRequest();
            }

            db.Entry(comments).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentsExists(id))
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

        // POST: api/Comments
        [ResponseType(typeof(Comments))]
        public async Task<IHttpActionResult> PostComments(Comments comments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CommentsSet.Add(comments);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = comments.Id }, comments);
        }

        // DELETE: api/Comments/5
        [ResponseType(typeof(Comments))]
        public async Task<IHttpActionResult> DeleteComments(int id)
        {
            Comments comments = await db.CommentsSet.FindAsync(id);
            if (comments == null)
            {
                return NotFound();
            }

            db.CommentsSet.Remove(comments);
            await db.SaveChangesAsync();

            return Ok(comments);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommentsExists(int id)
        {
            return db.CommentsSet.Count(e => e.Id == id) > 0;
        }
    }
}