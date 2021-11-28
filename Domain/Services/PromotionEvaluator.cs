using PromotionEngine.Domain.Models;
using PromotionEngine.Domain.Models.Promotions;
using System.Collections.Generic;

namespace PromotionEngine.Domain.Services
{
    public class PromotionEvaluator
    {
        public int Evaluate(Cart cart, IEnumerable<IPromotion> promotions)
        {
            foreach (var promotion in promotions)
            {
                if (promotion.IsPromotionApplicable(cart))
                {
                    promotion.Apply(cart);
                }
            }
            return 0;
        }
    }
}