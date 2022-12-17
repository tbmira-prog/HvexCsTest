using HvexTransformerReports.Models;
using Microsoft.AspNetCore.Mvc;

namespace HvexTransformerReports.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            var transformer = new Transformer()
            {
                Name = "trafo_1", 
                InternalNumber = 1, 
                TensionClass = "75 kV", 
                Current = "100 A", 
                Potency = "75 MVA"
            };

            var user = new User()
            { Name = "Thiago", Email = "thiagao123@email.com"};
            user.Transformers.Add(transformer);

            return Ok(user);
        }
    }
}
