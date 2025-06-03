using crud_aspdotnet_core.Entities;

namespace crud_aspdotnet_core.Repositories
{
    public interface IVideoGameRepository
    {
        Task<VideoGame> CreateAsync(VideoGame videoGame);
        Task<VideoGame> UpdateAsync(VideoGame videoGame);
        Task<List<VideoGame>> GetVideosAsync();

        Task<VideoGame> GetVideoAsync(int id);

        Task DeleteAsync(VideoGame videoGame);
    }
}
