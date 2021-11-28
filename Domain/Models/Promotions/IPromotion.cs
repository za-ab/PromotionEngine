namespace PromotionEngine.Domain.Models.Promotions
{
    public interface IPromotion
    {
        bool IsPromotionApplicable(Cart cart);

        void Apply(Cart cart);
    }
}