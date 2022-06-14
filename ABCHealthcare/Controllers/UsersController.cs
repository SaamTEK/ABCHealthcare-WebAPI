using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ABCHealthcare.Models;

namespace ABCHealthcare.Controllers
{
    public class UsersController : ApiController
    {
        private ABCHealthDBContext db = new ABCHealthDBContext();

        // GET: api/Users
        [BasicAuthentication]
        [MyAuthorize(Roles = "Admin")]
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [BasicAuthentication]
        [MyAuthorize(Roles = "User,Admin")]
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

        [HttpPost]
        public async Task<IHttpActionResult> Login(string username, string password)
        {
            var res = await db.Users.AnyAsync(user => user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password == password);
            if(res)
            {
                var plainText = username + ":" + password;
                var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                string token = "BASIC " + Convert.ToBase64String(plainTextBytes);
                return Ok(token);
            } else
            {
                return BadRequest();
            }
            
        }

        // PUT: api/Users/5
        [BasicAuthentication]
        [MyAuthorize(Roles = "User,Admin")]
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

            db.Entry(user).State = EntityState.Modified;

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

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
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
        [BasicAuthentication]
        [MyAuthorize(Roles = "User,Admin")]
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