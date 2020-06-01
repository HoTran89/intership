using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class UserController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            using (var db = new UserContext())
            {
                return db.Users.ToList().OrderBy(item => item.FirstName);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<User> Get(Guid id)
        {
            using (var db = new UserContext())
            {
                return db.Users.FirstOrDefault(item => item.Id == id);
            }
        }

        // POST api/values
        [HttpPost]

        public async Task<bool> Post([FromBody] User user)
        {
            using (var context = new UserContext())
            {
                var entity = new User();
                entity.Id = Guid.NewGuid();
                entity.FirstName = user.FirstName;
                entity.LastName = user.LastName;
                context.Users.Add(entity);
                context.SaveChanges();
                return true;
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<bool> Put(Guid id, [FromBody] User user)
        {
            using (var context = new UserContext())
            {
                var entity = context.Users.FirstOrDefault(item => item.Id == id);
                if (entity != null)
                {
                    entity.FirstName = user.FirstName;
                    entity.LastName = user.LastName;
                    context.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            using (var context = new UserContext())
            {
                var entity = context.Users.FirstOrDefault(item => item.Id == id);
                if (entity != null)
                {
                    context.Users.Remove(entity);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
