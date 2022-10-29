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
using nmvm;
using nmvm.Models.nmvm;

namespace nmvm.Controllers.nmvm
{
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
        public async Task<IHttpActionResult> PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            User existingUser = db.Users.Where(u => u.Id == id).First();

            if (existingUser != null)
            {
                existingUser.Username = string.IsNullOrEmpty(user.Username) ? existingUser.Username : user.Username;
                existingUser.FirstName = string.IsNullOrEmpty(user.FirstName) ? existingUser.FirstName : user.FirstName;
                existingUser.LastName = string.IsNullOrEmpty(user.LastName) ? existingUser.LastName : user.LastName;
                existingUser.Email = string.IsNullOrEmpty(user.Email) ? existingUser.Email : user.Email;
                existingUser.Mobile = string.IsNullOrEmpty(user.Mobile) ? existingUser.Mobile : user.Mobile;
                existingUser.PreferredName = string.IsNullOrEmpty(user.PreferredName) ? existingUser.PreferredName : user.PreferredName;
                existingUser.Email = string.IsNullOrEmpty(user.Email) ? existingUser.Email : user.Email;
                existingUser.ModifiedByUserName = string.IsNullOrEmpty(user.ModifiedByUserName) ? existingUser.ModifiedByUserName : user.ModifiedByUserName;
                existingUser.ModifiedByDisplaName = string.IsNullOrEmpty(user.ModifiedByDisplaName) ? existingUser.ModifiedByDisplaName : user.ModifiedByDisplaName;
                existingUser.ModifiedDateTime = DateTime.Now;

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

            db.Users.Add(user);
            
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            await db.SaveChangesAsync();

            return Ok(user);
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