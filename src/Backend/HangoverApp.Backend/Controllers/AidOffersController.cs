using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using HangoverApp.DL.Models;
using HangoverApp.DL.Providers;

namespace HangoverApp.Backend.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using HangoverApp.DL.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<HelpOffer>("AidOffers");
    builder.EntitySet<Calendar>("Calendars"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class AidOffersController : ODataController
    {
        private DbProvider db = new DbProvider();

        // GET: odata/HelpOffers
        [EnableQuery]
        public IQueryable<AidOffer> GetHelpOffers()
        {
            return db.AidOffers;
        }

        // GET: odata/HelpOffers(5)
        [EnableQuery]
        public SingleResult<AidOffer> GetHelpOffer([FromODataUri] int key)
        {
            return SingleResult.Create(db.AidOffers.Where(helpOffer => helpOffer.Id == key));
        }

        // PUT: odata/HelpOffers(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<AidOffer> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AidOffer aidOffer = await db.AidOffers.FindAsync(key);
            if (aidOffer == null)
            {
                return NotFound();
            }

            patch.Put(aidOffer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HelpOfferExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(aidOffer);
        }

        // POST: odata/HelpOffers
        public async Task<IHttpActionResult> Post(AidOffer aidOffer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AidOffers.Add(aidOffer);
            await db.SaveChangesAsync();

            return Created(aidOffer);
        }

        // PATCH: odata/HelpOffers(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<AidOffer> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AidOffer aidOffer = await db.AidOffers.FindAsync(key);
            if (aidOffer == null)
            {
                return NotFound();
            }

            patch.Patch(aidOffer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HelpOfferExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(aidOffer);
        }

        // DELETE: odata/HelpOffers(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            AidOffer aidOffer = await db.AidOffers.FindAsync(key);
            if (aidOffer == null)
            {
                return NotFound();
            }

            db.AidOffers.Remove(aidOffer);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/HelpOffers(5)/Availability
        [EnableQuery]
        public SingleResult<Calendar> GetAvailability([FromODataUri] int key)
        {
            return SingleResult.Create(db.AidOffers.Where(m => m.Id == key).Select(m => m.Availability));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HelpOfferExists(int key)
        {
            return db.AidOffers.Count(e => e.Id == key) > 0;
        }
    }
}
