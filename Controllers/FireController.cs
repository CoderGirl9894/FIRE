using Microsoft.AspNetCore.Mvc;

namespace FireCalculator.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FireController : ControllerBase
{
    [HttpPost("calculate")]
    public IActionResult Calculate([FromBody] FireCalculationRequest request)
    {
        if (request.Expenses <= 0 || request.Swr <= 0)
        {
            return BadRequest("Expenses and withdrawal rate must be positive numbers.");
        }

        var fireNumber = request.Expenses / request.Swr;
        
        return Ok(new FireCalculationResult
        {
            FireNumber = fireNumber,
            AnnualExpenses = request.Expenses,
            WithdrawalRate = request.Swr
        });
    }
}

public class FireCalculationRequest
{
    public double Expenses { get; set; }
    public double Swr { get; set; }
}

public class FireCalculationResult
{
    public double FireNumber { get; set; }
    public double AnnualExpenses { get; set; }
    public double WithdrawalRate { get; set; }
} 