using PromotionEngine.Domain.Models;
using System.Collections.Generic;
using PromotionEngine.Domain.Models.Promotions;

namespace PromotionEngine.Domain.Services
{
    public class PromotionEvaluator
    {
        public int Evaluate(Cart cart, IEnumerable<IPromotion> promotions)
        {
            return 0;
        }
    }
}