using Invoicing.Controllers.ViewModels;
using Invoicing.Models.Domain;
using Invoicing.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Invoicing.Controllers
{
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _repository;

        public ClientController(IClientRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet("v1/clients")]
        public IActionResult GetList()
        {
            var listClients = _repository.GetAll();
            return Ok(listClients);
        }

        [HttpGet("v1/clients/{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            var client = _repository.GetById(id);
            if (client == null) return NotFound();
            return Ok(client);
        }

        [HttpPost("v1/clients")]
        public IActionResult Post([FromBody] ClientEditorViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var newClient = new Client
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber
            };

            _repository.Create(newClient);
            return Ok(new
            {
                message = "Cliente " + model.Name + " foi adicionado com sucesso!"
            });
        }

        [HttpPut("v1/clients/{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] ClientEditorViewModel model)
        {
            var client = _repository.GetById(id);

            if (client == null) return NotFound();

            client.Name = model.Name;
            client.PhoneNumber = model.PhoneNumber;

            _repository.Update(client);
            return Ok(new
            {
                message = "Cliente atualizado com sucesso!",
                id = id
            });
        }

        [HttpDelete("v1/clients/{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var clientDeleted = _repository.Delete(id);

            if (clientDeleted == false)
                return NotFound();
            else
            {
                return Ok(new
                {
                    message = "Cliente deletado com sucesso!",
                    id = id
                });
            }
        }
    }
}
