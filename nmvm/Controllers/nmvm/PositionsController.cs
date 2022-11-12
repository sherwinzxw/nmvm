using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using nmvm.Models.nmvm;
using nmvm.Utilities;

namespace nmvm.Controllers.nmvm
{
    /// <summary>
    /// The Restful API controller for the interactions with the Position data
    /// </summary>
    public class PositionsController : ApiController
    {
        private NMVM_Entities db = new NMVM_Entities();

        // GET: api/Positions
        ///<Summary>
        /// List the positions
        ///</Summary>
        public IQueryable<Position> GetPositions()
        {
            return db.Positions;
        }

        // GET: api/Positions/5
        ///<Summary>
        /// Get the position by its id
        /// <param name="id">The id of the position</param>
        ///</Summary>
        [ResponseType(typeof(Position))]
        public async Task<IHttpActionResult> GetPosition(int id)
        {
            Position position = await db.Positions.FindAsync(id);
            if (position == null)
            {
                return NotFound();
            }

            return Ok(position);
        }

        // PUT: api/Positions/5
        ///<Summary>
        /// Update the position
        /// <param name="id">The id of the position</param>
        /// <param name="position">The update content of the position</param>
        ///</Summary>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPosition(int id, [FromBody] dynamic position)
        {
            int _id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (Int32.TryParse(position.id.Value.ToString(), out _id))
                {
                    _id = Int32.Parse(position.id.Value.ToString());
                }
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, "Error Message: " + e.Message);
            }

            if (id != _id)
            {
                return BadRequest();
            }

            Position existingPosition = db.Positions.Where(u => u.Id == id).First();
            Position merge = ObjectMerger.UpsertDynamic(existingPosition, position);
            if (existingPosition != null)
            {
                db.Entry(existingPosition).CurrentValues.SetValues(merge);

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PositionExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            else
            {
                return NotFound();
            }


            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Positions
        ///<Summary>
        /// Create a new position
        /// <param name="position">The content of the new position</param>
        ///</Summary>
        [ResponseType(typeof(Position))]
        public async Task<IHttpActionResult> PostPosition(Position position)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Position newPosition = new Position().New(position);
            db.Positions.Add(newPosition);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = newPosition.Id }, newPosition);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PositionExists(int id)
        {
            return db.Positions.Count(e => e.Id == id) > 0;
        }
    }
}