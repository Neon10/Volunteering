using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Volunteering.Domain.Entities;
using Volunteering.Service.Identity;

namespace Volunteering.UI.Controllers_Api
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        private UserService us = new UserService();

        [Route("getValues")]
        // GET: api/Test
        public IQueryable<object> Get()
        {
            var users = us.UserManager.Users.Select(u => new { UserName = u.UserName, Email = u.Email, Role = u.Roles });
            return users;
        }



        [Route("getUsers")]
        // GET: api/Test
        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            var users = us.UserManager.Users.ToList();
            return users;

        }


        // GET: api/Test/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Test
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }
}
