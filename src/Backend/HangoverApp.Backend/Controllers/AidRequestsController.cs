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
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using HangoverApp.DL.Models;
using HangoverApp.DL.Models.Profile;
using HangoverApp.DL.Providers;

namespace HangoverApp.Backend.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using HangoverApp.DL.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<AidRequest>("AidRequests");
    builder.EntitySet<Activity>("Activities"); 
    builder.EntitySet<AidProvider>("AidProviders"); 
    builder.EntitySet<TimeSlot>("TimeSlots"); 
    builder.EntitySet<User>("Users"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class AidRequestsController : ODataController
    {
        private DbProvider db = new DbProvider();

        // GET: odata/AidRequests
        [EnableQuery]
        public IQueryable<AidRequest> GetAidRequests()
        {
            return db.AidRequests;
        }

        // GET: odata/AidRequests(5)
        [EnableQuery]
        public SingleResult<AidRequest> GetAidRequest([FromODataUri] int key)
        {
            return SingleResult.Create(db.AidRequests.Where(aidRequest => aidRequest.Id == key));
        }

        // PUT: odata/AidRequests(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<AidRequest> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AidRequest aidRequest = await db.AidRequests.FindAsync(key);
            if (aidRequest == null)
            {
                return NotFound();
            }

            patch.Put(aidRequest);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AidRequestExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(aidRequest);
        }

        // POST: odata/AidRequests
        public async Task<IHttpActionResult> Post(AidRequest aidRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AidRequests.Add(aidRequest);
            await db.SaveChangesAsync();

            return Created(aidRequest);
        }

        // PATCH: odata/AidRequests(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<AidRequest> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AidRequest aidRequest = await db.AidRequests.FindAsync(key);
            if (aidRequest == null)
            {
                return NotFound();
            }

            patch.Patch(aidRequest);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AidRequestExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(aidRequest);
        }

        // DELETE: odata/AidRequests(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            AidRequest aidRequest = await db.AidRequests.FindAsync(key);
            if (aidRequest == null)
            {
                return NotFound();
            }

            db.AidRequests.Remove(aidRequest);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/AidRequests(5)/Activities
        [EnableQuery]
        public IQueryable<Activity> GetActivities([FromODataUri] int key)
        {
            return db.AidRequests.Where(m => m.Id == key).SelectMany(m => m.Activities);
        }

        // GET: odata/AidRequests(5)/AidProviders
        [EnableQuery]
        public IQueryable<AidProvider> GetAidProviders([FromODataUri] int key)
        {
            return db.AidRequests.Where(m => m.Id == key).SelectMany(m => m.AidProviders);
        }

        // GET: odata/AidRequests(5)/EndTime
        [EnableQuery]
        public SingleResult<TimeSlot> GetEndTime([FromODataUri] int key)
        {
            return SingleResult.Create(db.AidRequests.Where(m => m.Id == key).Select(m => m.EndTime));
        }

        // GET: odata/AidRequests(5)/StartTime
        [EnableQuery]
        public SingleResult<TimeSlot> GetStartTime([FromODataUri] int key)
        {
            return SingleResult.Create(db.AidRequests.Where(m => m.Id == key).Select(m => m.StartTime));
        }

        // GET: odata/AidRequests(5)/TimeSlots
        [EnableQuery]
        public IQueryable<TimeSlot> GetTimeSlots([FromODataUri] int key)
        {
            return db.AidRequests.Where(m => m.Id == key).SelectMany(m => m.TimeSlots);
        }

        // GET: odata/AidRequests(5)/User
        [EnableQuery]
        public SingleResult<User> GetUser([FromODataUri] int key)
        {
            return SingleResult.Create(db.AidRequests.Where(m => m.Id == key).Select(m => m.User));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AidRequestExists(int key)
        {
            return db.AidRequests.Count(e => e.Id == key) > 0;
        }
    }
}
