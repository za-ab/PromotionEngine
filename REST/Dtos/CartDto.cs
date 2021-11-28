using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PromotionEngine.REST.Dtos
{
    [BindProperties]
    public class CartDto
    {
        public IEnumerable<char> SkuIds { get; set; }
    }
}
