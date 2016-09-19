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
using BankingWebAPI2.Models;

namespace BankingWebAPI2.Controllers
{
    public class eUsersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/eUsers
        public IQueryable<eUser> GeteUsers()
        {
            return db.eUsers;
        }

        // GET: api/eUsers/5
        [ResponseType(typeof(eUser))]
        public async Task<IHttpActionResult> GeteUser(long id)
        {
            eUser eUser = await db.eUsers.FindAsync(id);
            if (eUser == null)
            {
                return NotFound();
            }

            return Ok(eUser);
        }

        // PUT: api/eUsers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PuteUser(long id, eUser eUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eUser.Id)
            {
                return BadRequest();
            }

            db.Entry(eUser).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!eUserExists(id))
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

        // POST: api/eUsers
        [ResponseType(typeof(eUser))]
        public async Task<IHttpActionResult> PosteUser(eUser eUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.eUsers.Add(eUser);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = eUser.Id }, eUser);
        }

        // DELETE: api/eUsers/5
        [ResponseType(typeof(eUser))]
        public async Task<IHttpActionResult> DeleteeUser(long id)
        {
            eUser eUser = await db.eUsers.FindAsync(id);
            if (eUser == null)
            {
                return NotFound();
            }

            db.eUsers.Remove(eUser);
            await db.SaveChangesAsync();

            return Ok(eUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool eUserExists(long id)
        {
            return db.eUsers.Count(e => e.Id == id) > 0;
        }
    }
}