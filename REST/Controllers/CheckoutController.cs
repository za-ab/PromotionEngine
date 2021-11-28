using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PromotionEngine.REST.Dtos;

namespace PromotionEngine.REST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly ILogger<CheckoutController> _logger;

        public CheckoutController(ILogger<CheckoutController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/promotions/apply")]
        public int ApplyPromotions([FromBody] CartDto cartDto)
        {
            return 0;
        }
    }
}
