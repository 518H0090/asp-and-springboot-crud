using crud_aspdotnet_core.DataContext;
using crud_aspdotnet_core.Entities;
using Microsoft.EntityFrameworkCore;

namespace crud_aspdotnet_core.Repositories
{
    public class VideoGameRepository : IVideoGameRepository
    {
        private readonly ApplicationDbContext _context;

        public VideoGameRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<VideoGame> CreateAsync(VideoGame videoGame)
        {
            var created = await _context.VideoGames.AddAsync(videoGame);
            await _context.SaveChangesAsync();
            return created.Entity;
        }

        public async Task DeleteAsync(VideoGame videoGame)
        {
            _context.VideoGames.Remove(videoGame);
            await _context.SaveChangesAsync();
        }

        public async Task<VideoGame> GetVideoAsync(int id)
        {
            return await _context.VideoGames.FindAsync(id);
        }

        public async Task<List<VideoGame>> GetVideosAsync()
        {
            return await _context.VideoGames.AsNoTracking().ToListAsync();
        }

        public async Task<VideoGame> UpdateAsync(VideoGame videoGame)
        {
            var updatedVideoGame = _context.VideoGames.Update(videoGame);
            await _context.SaveChangesAsync();
            return updatedVideoGame.Entity;
        }
    }
}
