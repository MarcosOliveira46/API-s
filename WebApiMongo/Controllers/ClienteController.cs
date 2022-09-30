using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Contexts;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteContext _cliente;

        public ClienteController(ClienteContext cli)
        {
            _cliente = cli;
        }

        [HttpGet]
        public List<Cliente> Get()
        {
            return _cliente.Select();
             
        }

        [HttpGet("{id}")]
        public Cliente Get(string id){
            return _cliente.Select(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente){
            try{

                var cli = _cliente.Insert(cliente);
                return CreatedAtAction(nameof(Get), new {Id = cli.Id}, cli);

            }catch(Exception e){

                return NotFound();

            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(string Id, [FromBody] Cliente cliente)
        {
            try{
                _cliente.Update(Id, cliente);
                return Ok();
            }catch(Exception e){return NotFound();}
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(string Id){

            try{
                _cliente.Delete(Id);
                return Ok();
            }catch(Exception e){return NotFound();}
        }

    }
}