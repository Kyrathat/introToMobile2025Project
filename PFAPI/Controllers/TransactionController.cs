using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFAPI.Models;

namespace PFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransDataContext _context;

        public TransactionController(TransDataContext context)
        {
            _context = context;
        }

        // GET: api/Transaction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionModel>>> GetTransActions()
        {
            try
            {
                return await _context.Transact.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }

        // GET: api/Transaction/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionModel>> GetTransaction(int id)
        {
            try
            {
                var transaction = await _context.Transact.FindAsync(id);

                if (transaction == null)
                    return NotFound($"Transaction with ID {id} not found.");

                return transaction;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }

        // POST: api/Transaction
        [HttpPost]
        public async Task<ActionResult<TransactionModel>> PostTransaction(TransactionModel transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _context.Transact.Add(transaction);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetTransaction), new { id = transaction.TransactionID }, transaction);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }

        // PUT: api/Transaction/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaction(int id, TransactionModel transaction)
        {
            if (id != transaction.TransactionID)
                return BadRequest("ID in URL does not match ID in body.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Entry(transaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionExists(id))
                    return NotFound($"Transaction with ID {id} does not exist.");

                throw;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }

        // DELETE: api/Transaction/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            try
            {
                var transaction = await _context.Transact.FindAsync(id);
                if (transaction == null)
                    return NotFound($"Transaction with ID {id} not found.");

                _context.Transact.Remove(transaction);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }

        private bool TransactionExists(int id)
        {
            return _context.Transact.Any(e => e.TransactionID == id);
        }
    }
}
