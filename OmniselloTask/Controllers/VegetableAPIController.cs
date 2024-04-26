using Microsoft.AspNetCore.Mvc;
using OmniselloTask.Models;
using Repository.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OmniselloTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VegetableAPIController : ControllerBase
    {
        private IVegetables _vege;
        public VegetableAPIController(IVegetables vege)
        {
                _vege= vege;
        }
        // GET: api/<VegetableAPIController>
        [HttpGet]
        public IEnumerable<Vegetables> Get()
        {
            return _vege.GetAllVege();
        }

        // GET api/<VegetableAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VegetableAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VegetableAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VegetableAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
