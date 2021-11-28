using System.Collections.Generic;

namespace PromotionEngine.Domain.Models
{
    public class Cart
    {
        public IEnumerable<char> SkuIds { get; set; }
    }
}