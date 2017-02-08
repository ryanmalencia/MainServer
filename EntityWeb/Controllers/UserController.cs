using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using DataTypes;
using EntityWeb.Logic;

namespace EntityWeb.Controllers
{
    [EnableCors("*", "*", "*")]
    public class UserController : ApiController
    {
        private UserLogic UserLogic = new UserLogic();
        [Route("api/user/add/")]
        [HttpPut]
        public void Add(User user)
        {
            UserLogic.Add(user);
        }

        [Route("api/user/get/{user}/")]
        [HttpGet]
        public IHttpActionResult Get(string user)
        {
            return Ok(JsonConvert.SerializeObject(UserLogic.Get(user)));
        }
    }
}