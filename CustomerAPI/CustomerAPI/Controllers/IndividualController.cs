using CustomerAPI.Models;
using CustomerAPI.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [EnableCors]
    [ApiController]
    public class IndividualController : GenericController<Individual>
    {
        public IndividualController(IGenericRepository<Individual> repository) : base(repository)
        {
        }
    }
}
