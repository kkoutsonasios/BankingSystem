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
    public class BalancesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Balances
        public IQueryable<Balance> GetBalances()
        {
            return db.Balances;
        }

        // GET: api/Balances/5
        [ResponseType(typeof(Balance))]
        public async Task<IHttpActionResult> GetBalance(long id)
        {
            Balance balance = await db.Balances.FindAsync(id);
            if (balance == null)
            {
                return NotFound();
            }

            return Ok(balance);
        }

        // PUT: api/Balances/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBalance(long id, Balance balance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != balance.Id)
            {
                return BadRequest();
            }

            db.Entry(balance).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BalanceExists(id))
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

        // POST: api/Balances
        [ResponseType(typeof(Balance))]
        public async Task<IHttpActionResult> PostBalance(Balance balance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Balances.Add(balance);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = balance.Id }, balance);
        }

        // DELETE: api/Balances/5
        [ResponseType(typeof(Balance))]
        public async Task<IHttpActionResult> DeleteBalance(long id)
        {
            Balance balance = await db.Balances.FindAsync(id);
            if (balance == null)
            {
                return NotFound();
            }

            db.Balances.Remove(balance);
            await db.SaveChangesAsync();

            return Ok(balance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BalanceExists(long id)
        {
            return db.Balances.Count(e => e.Id == id) > 0;
        }
    }
}