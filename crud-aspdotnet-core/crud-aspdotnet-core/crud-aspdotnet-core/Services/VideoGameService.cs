using AutoMapper;
using crud_aspdotnet_core.Dtos;
using crud_aspdotnet_core.Entities;
using crud_aspdotnet_core.Repositories;

namespace crud_aspdotnet_core.Services
{
    public class VideoGameService : IVideoGameService
    {
        private readonly IVideoGameRepository _videoGameRepository;
        private readonly IMapper _mapper;

        public VideoGameService(IVideoGameRepository videoGameRepository, IMapper mapper)
        {
            _videoGameRepository = videoGameRepository;
            _mapper = mapper;
        }

        public async Task<VideoGameDto> CreateAsync(VideoGameDto request)
        {
            if (request == null) throw new Exception("Invalid Request");

            var videoGame = _mapper.Map<VideoGame>(request);

            var createdVideoGame = await _videoGameRepository.CreateAsync(videoGame);

            return _mapper.Map<VideoGameDto>(createdVideoGame);
        }

        public async Task DeleteAsync(int id)
        {
            var foundVideoGame = await _videoGameRepository.GetVideoAsync(id);
            if (foundVideoGame is null) throw new Exception("Not found Video Game");
            await _videoGameRepository.DeleteAsync(foundVideoGame);
        }

        public async Task<VideoGameDto> GetAsync(int id)
        {
            var videoGame = await _videoGameRepository.GetVideoAsync(id);
            return _mapper.Map<VideoGameDto>(videoGame);
        }

        public async Task<List<VideoGameDto>> GetAllAsync()
        {
            var allVideoGames = await _videoGameRepository.GetVideosAsync();

            return allVideoGames.Select(x => _mapper.Map<VideoGameDto>(x)).ToList();
        }

        public async Task<VideoGameDto> UpdateAsync(VideoGameDto request)
        {
            var foundVideoGame = await _videoGameRepository.GetVideoAsync(request.Id);
            if (foundVideoGame is null) throw new Exception("Not found Video Game");

            foundVideoGame.Title = request.Title;
            foundVideoGame.Publisher = request.Publisher;
            foundVideoGame.Developer = request.Developer;
            foundVideoGame.Platform = request.Platform;

            var updatedVideoGame = await _videoGameRepository.UpdateAsync(foundVideoGame);

            return _mapper.Map<VideoGameDto>(updatedVideoGame);
        }
    }
}
