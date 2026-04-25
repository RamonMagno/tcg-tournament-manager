using Microsoft.AspNetCore.Mvc;
using tcg_tournament_manager.application.Shared.Dispatcher;
using tcg_tournament_manager.application.Training.Commands;
using tcg_tournament_manager.application.Training.Dto;
using tcg_tournament_manager.application.Training.Queries;
using tcg_tournament_manager.presentation.webapi.ViewModel;

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
            return await _dispatcher.QueryAsync<GetTrainingByIdQuery, TrainingDto>(new GetTrainingByIdQuery(id));
        }

        [HttpPost]
        public async Task<ActionResult<TrainingDto>> Create([FromBody] CreateTrainingViewModel command)
        {
            var result = await _dispatcher.SendAsync<CreateTrainingCommand, TrainingDto>(new CreateTrainingCommand(command.Name,
                                                                                                                   command.Description,
                                                                                                                   command.GameId,
                                                                                                                   command.PlayersLimit));
            return Created();
        }
    }
}
