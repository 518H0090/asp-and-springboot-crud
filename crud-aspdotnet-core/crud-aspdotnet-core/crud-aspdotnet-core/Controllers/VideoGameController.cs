using crud_aspdotnet_core.Dtos;
using crud_aspdotnet_core.Services;
using Microsoft.AspNetCore.Mvc;

namespace crud_aspdotnet_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        private readonly IVideoGameService _videoGameService;

        public VideoGameController(IVideoGameService videoGameService)
        {
            _videoGameService = videoGameService;
        }

        [HttpGet]
        [Route("get-alls")]
        public async Task<IActionResult> GetVideoGames()
        {
            return Ok(await _videoGameService.GetAllAsync());
        }

        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetVideoGameById([FromRoute] int id)
        {
            return Ok(await _videoGameService.GetAsync(id));
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateVideoGame([FromBody] VideoGameDto request)
        {
            try
            {
                var createdVideoGame = await _videoGameService.CreateAsync(request);

                return CreatedAtAction(nameof(CreateVideoGame), new { id = createdVideoGame.Id }, createdVideoGame);
            }

            catch (Exception ex)
            {
                return BadRequest();
            }
            
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateVideoGame([FromBody] VideoGameDto request)
        {
            try
            {
                var updatedVideoGame = await _videoGameService.UpdateAsync(request);

                return AcceptedAtAction(nameof(UpdateVideoGame), updatedVideoGame);
            }

            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteVideoGame(int id)
        {
            try
            {
                await _videoGameService.DeleteAsync(id);
                return AcceptedAtAction(nameof(DeleteVideoGame));
            }

             catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
