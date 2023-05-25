using Microsoft.EntityFrameworkCore;
using Models;
using System.Xml.Serialization;
using System.Xml;
using Models.DTOs.Output;
using AutoMapper;

namespace Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int id);
        Task<byte[]> ExportUsersToXml();
    }

    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(MyDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.Include(u => u.Address).ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.Include(u => u.Address).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAllWithAddress()
        {
            // Retrieve users with addresses from the database
            var users = await _context.Users.Include(u => u.Address).ToListAsync();
            return users;
        }

        public async Task<byte[]> ExportUsersToXml()
        {
            var users = await GetAllWithAddress();

            var userFormatted = _mapper.Map<List<UserAddressDTO>>(users);

            var xmlSettings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "    "
            };

            using (var memoryStream = new MemoryStream())
            {
                using (var writer = XmlWriter.Create(memoryStream, xmlSettings))
                {
                    // Create XML serializer
                    var serializer = new XmlSerializer(typeof(List<UserAddressDTO>), new XmlRootAttribute("Users"));

                    // Serialize users to XML
                    serializer.Serialize(writer, userFormatted);
                }

                var xmlBytes = memoryStream.ToArray();
                return xmlBytes;
            }
        }
    }
}