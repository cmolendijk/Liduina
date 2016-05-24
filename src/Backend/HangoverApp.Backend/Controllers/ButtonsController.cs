using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using HangoverApp.DL.Models;
using HangoverApp.DL.Models.ActionButton;
using HangoverApp.DL.Providers;
using System.Collections.Generic;
using HangoverApp.DL.Models.Profile;
using HangoverApp.DL.Services.Executables;

namespace HangoverApp.Backend.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using HangoverApp.DL.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Button>("Buttons");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */

    public class ButtonsController : ODataController
    {
        private DbProvider db = new DbProvider();

        // GET: odata/Buttons
        [EnableQuery]
        public IQueryable<Button> GetButtons()
        {
            return db.Button;
        }

        // GET: odata/Buttons(5)
        [EnableQuery]
        public SingleResult<Button> GetButton([FromODataUri] int key)
        {
            return SingleResult.Create(db.Button.Where(button => button.Id == key));
        }

        // PUT: odata/Buttons(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Button> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Button button = await db.Button.FindAsync(key);
            if (button == null)
            {
                return NotFound();
            }

            patch.Put(button);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ButtonExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(button);
        }

        // POST: odata/Buttons
        public async Task<IHttpActionResult> Post(Button button)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Button.Add(button);
            await db.SaveChangesAsync();

            return Created(button);
        }

        // PATCH: odata/Buttons(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Button> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Button button = await db.Button.FindAsync(key);
            if (button == null)
            {
                return NotFound();
            }

            patch.Patch(button);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ButtonExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(button);
        }

        // DELETE: odata/Buttons(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Button button = await db.Button.FindAsync(key);
            if (button == null)
            {
                return NotFound();
            }

            db.Button.Remove(button);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ButtonExists(int key)
        {
            return db.Button.Count(e => e.Id == key) > 0;
        }
    }
}
