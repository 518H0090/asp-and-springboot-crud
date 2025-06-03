using crud_aspdotnet_core.Dtos;

namespace crud_aspdotnet_core.Services
{
    public interface IVideoGameService
    {
        Task<VideoGameDto> CreateAsync(VideoGameDto request);
        Task<VideoGameDto> UpdateAsync(VideoGameDto request);
        Task<List<VideoGameDto>> GetAllAsync();

        Task<VideoGameDto> GetAsync(int id);

        Task DeleteAsync(int id);
    }
}
