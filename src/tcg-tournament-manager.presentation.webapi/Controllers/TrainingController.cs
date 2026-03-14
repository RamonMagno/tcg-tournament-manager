using Microsoft.AspNetCore.Mvc;
using tcg_tournament_manager.application.Shared.Dispatcher;
using tcg_tournament_manager.application.Training.Commands;
using tcg_tournament_manager.application.Training.Dto;

namespace tcg_tournament_manager.presentation.webapi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TrainingController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public TrainingController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingDto>> Get(Guid id)
        {
            return await _dispatcher.SendAsync<CreateTrainingCommand, TrainingDto>(new CreateTrainingCommand(id));
        }

    }
}
