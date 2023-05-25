using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;

namespace AgendaCorreios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommitmentController : ControllerBase
    {
        private readonly ICommitmentRepository _commitmentRepository;

        public CommitmentController(ICommitmentRepository commitmentRepository)
        {
            _commitmentRepository = commitmentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var commitments = await _commitmentRepository.GetAll();
            return Ok(commitments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var commitment = await _commitmentRepository.GetById(id);
            if (commitment == null)
            {
                return NotFound();
            }
            return Ok(commitment);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Commitment commitment)
        {
            await _commitmentRepository.Add(commitment);
            return CreatedAtAction(nameof(GetById), new { id = commitment.Id }, commitment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Commitment commitment)
        {
            if (id != commitment.Id)
            {
                return BadRequest();
            }

            try
            {
                await _commitmentRepository.Update(commitment);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _commitmentRepository.Delete(id);
            return NoContent();
        }
    }
}
