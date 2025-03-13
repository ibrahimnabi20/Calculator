using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly CalculatorDbContext _context;

        public CalculatorController(CalculatorDbContext context)
        {
            _context = context;
        }

        [HttpGet("history")]
        public async Task<ActionResult<IEnumerable<CalculationHistory>>> GetHistory()
        {
            return await _context.CalculationHistories.OrderByDescending(h => h.Timestamp).ToListAsync();
        }

        [HttpPost("calculate")] 
        public async Task<ActionResult<int>> Calculate([FromBody] CalculationRequest request)
        {
            int result = request.Operation switch
            {
                "add" => request.A + request.B,
                "subtract" => request.A - request.B,
                "multiply" => request.A * request.B,
                "divide" => request.B != 0 ? request.A / request.B : throw new System.DivideByZeroException(),
                _ => throw new System.ArgumentException("Invalid operation")
            };

            var historyEntry = new CalculationHistory
            {
                Operation = request.Operation,
                A = request.A,
                B = request.B,
                Result = result
            };
            
            _context.CalculationHistories.Add(historyEntry);
            await _context.SaveChangesAsync();

            return Ok(result);
        }
    }

    public class CalculationRequest
    {
        public string Operation { get; set; }
        public int A { get; set; }
        public int B { get; set; }
    }

    public class CalculationHistory
    {
        public int Id { get; set; }
        public string Operation { get; set; }
        public int A { get; set; }
        public int B { get; set; }
        public int Result { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }

    public class CalculatorDbContext : DbContext
    {
        public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options) : base(options) { }
        public DbSet<CalculationHistory> CalculationHistories { get; set; }
    }
}
