using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static server.RockPaperScissorsGame;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RockPaperScissorsController : ControllerBase
    {
        private readonly RockPaperScissorsGame game;

        public RockPaperScissorsController()
        {
            game = new RockPaperScissorsGame();
        }

        [HttpPost]
        public ActionResult<Result> PlayMove([FromBody] JsonRequest jsonRequest)
        {
            if (!Enum.TryParse(jsonRequest.PlayerMove, out Move move))
            {
                return BadRequest("Invalid player move.");
            }

            Result result = game.Play(move);
            return result;
        }

        public class JsonRequest
        {
            [JsonProperty("playerMove")]
            public string PlayerMove { get; set; }
        }
    }
}
