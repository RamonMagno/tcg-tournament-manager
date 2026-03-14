using Microsoft.AspNetCore.Mvc;

namespace tcg_tournament_manager.presentation.webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet(Name = "Buscar usuarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<IEnumerable<object>>> Get()
        {
            return Task.FromResult<ActionResult<IEnumerable<object>>>(new object[] { });
        }

        [HttpGet("{id}", Name = "Buscar usuario por id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<object>> GetById(Guid id)
        {
            return Task.FromResult<ActionResult<object>>(new object());
        }

        [HttpPost(Name = "Criar usuário")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<ActionResult<object>> Post()
        {
            return Task.FromResult<ActionResult<object>>(new object());
        }

        [HttpPut("{id}", Name = "Atualizar usuário")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<object>> Put(Guid id)
        {
            return Task.FromResult<ActionResult<object>>(new object());
        }
    }
}