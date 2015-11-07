using MCollarApi2.BusinessLayer;
using MCollarApi2.Model;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MCollarApi2.Controllers
{
    [EnableCors(origins: "http://mcollarapi2.azurewebsites.net", headers: "*", methods: "*")]
    public class FencesController : ApiController
    {

    }
}
