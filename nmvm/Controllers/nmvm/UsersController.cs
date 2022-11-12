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
    /// The Restful API controller for the interactions with the User data
    /// </summary>
    public class UsersController : ApiController
    {
        private NMVM_Entities db = new NMVM_Entities();

        // GET: api/Users
        ///<Summary>
        /// List the users
        ///</Summary>
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        ///<Summary>
        /// Get the user by its id
        /// <param name="id">The id of the user</param>
        ///</Summary>
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        ///<Summary>
        /// Update the user
        /// <param name="id">The id of the user</param>
        /// <param name="user">The update content of the user</param>
        ///</Summary>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(int id, [FromBody] dynamic user)
        {
            int _id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (Int32.TryParse(user.id.Value.ToString(), out _id))
                {
                    _id = Int32.Parse(user.id.Value.ToString());
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

            User existingUser = db.Users.Where(u => u.Id == id).First();
            User merge = ObjectMerger.UpsertDynamic(existingUser, user);
            if (existingUser != null)
            {
                db.Entry(existingUser).CurrentValues.SetValues(merge);

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(id))
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

        // POST: api/Users
        ///<Summary>
        /// Create a new user
        /// <param name="user">The content of the new user</param>
        ///</Summary>
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User newUser = new User().New(user);

            db.Users.Add(newUser);
            
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = newUser.Id }, newUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}