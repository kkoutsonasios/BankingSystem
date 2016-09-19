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
using BankingWebAPI.Models;

namespace BankingWebAPI.Controllers
{
    public class SettingsController : ApiController
    {
        private BankingWebAPIContext db = new BankingWebAPIContext();

        // GET: api/Settings
        public IQueryable<Setting> GetSettings()
        {
            return db.Settings;
        }

        // GET: api/Settings/5
        [ResponseType(typeof(Setting))]
        public async Task<IHttpActionResult> GetSetting(string id)
        {
            Setting setting = await db.Settings.FindAsync(id);
            if (setting == null)
            {
                return NotFound();
            }

            return Ok(setting);
        }

        // PUT: api/Settings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSetting(string id, Setting setting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != setting.SettingName)
            {
                return BadRequest();
            }

            db.Entry(setting).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SettingExists(id))
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

        // POST: api/Settings
        [ResponseType(typeof(Setting))]
        public async Task<IHttpActionResult> PostSetting(Setting setting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Settings.Add(setting);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SettingExists(setting.SettingName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = setting.SettingName }, setting);
        }

        // DELETE: api/Settings/5
        [ResponseType(typeof(Setting))]
        public async Task<IHttpActionResult> DeleteSetting(string id)
        {
            Setting setting = await db.Settings.FindAsync(id);
            if (setting == null)
            {
                return NotFound();
            }

            db.Settings.Remove(setting);
            await db.SaveChangesAsync();

            return Ok(setting);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SettingExists(string id)
        {
            return db.Settings.Count(e => e.SettingName == id) > 0;
        }
    }
}