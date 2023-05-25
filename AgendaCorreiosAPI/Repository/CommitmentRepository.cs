using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository
{
    public interface ICommitmentRepository
    {
        Task<List<Commitment>> GetAll();
        Task<Commitment> GetById(int id);
        Task Add(Commitment commitment);
        Task Update(Commitment commitment);
        Task Delete(int id);
    }

    public class CommitmentRepository : ICommitmentRepository
    {
        private readonly MyDbContext _context;

        public CommitmentRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Commitment>> GetAll()
        {
            return await _context.Commitments.ToListAsync();
        }

        public async Task<Commitment> GetById(int id)
        {
            return await _context.Commitments.FindAsync(id);
        }

        public async Task Add(Commitment commitment)
        {
            _context.Commitments.Add(commitment);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Commitment commitment)
        {
            _context.Entry(commitment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var commitment = await _context.Commitments.FindAsync(id);
            if (commitment != null)
            {
                _context.Commitments.Remove(commitment);
                await _context.SaveChangesAsync();
            }
        }
    }
}