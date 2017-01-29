using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using DataTypes;
using EntityWeb.Logic;


namespace EntityWeb.Controllers
{
    [EnableCors("*", "*", "*")]
    public class MyAppController : ApiController
    {
        private AppLogic AppLogic = new AppLogic();
        [Route("api/myapp/addnewdevice/")]
        [HttpPut]
        public void AddNewDevice(AppDevice device)
        {
            AppLogic.AddNewDevice(device);
        }
    }
}