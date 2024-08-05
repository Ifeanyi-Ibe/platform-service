using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly ApplicationDbContext _context;

        public PlatformRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreatePlatform(Platform platform)
        {
            if(platform == null)
            {
                throw new ArgumentException("Platform cannot be null");
            }

            _context.Platforms.Add(platform);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetPlatformById(Guid id)
        {
            return _context.Platforms.FirstOrDefault(p => p.Id == id) ?? throw new ArgumentException($"Platform with id {id} not found");
            // return _context.Platforms.FirstOrDefault(p => p.Id == id) ?? new Platform() { Name = "Americana", Publisher = "Orange Moon", Cost = "Free" };

        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }

}