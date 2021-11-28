using Moq;
using NUnit.Framework;
using PromotionEngine.Domain.Models;
using PromotionEngine.Domain.Models.Promotions;
using PromotionEngine.Domain.Services;

namespace PromotionEngine.Tests.Domain.Services
{
    public class PromotionEvaluatorTests
    {
        private PromotionEvaluator _promotionEvaluator;

        [SetUp]
        public void Setup()
        {
            _promotionEvaluator = new PromotionEvaluator();
        }

        [Test]
        public void If_no_promotions_are_applicable_none_should_be_applied()
        {
            //Arrange
            var cart = new Cart();
            var promotionMock1 = new Mock<IPromotion>();
            var promotionMock2 = new Mock<IPromotion>();
            promotionMock1.Setup(x => x.IsPromotionApplicable(It.IsAny<Cart>()))
                .Returns(false);
            promotionMock2.Setup(x => x.IsPromotionApplicable(It.IsAny<Cart>()))
                .Returns(false);
            var promotions = new[] { promotionMock1.Object, promotionMock2.Object };

            //Act
            _promotionEvaluator.Evaluate(cart, promotions);

            //Assert
            promotionMock1.Verify(f => f.IsPromotionApplicable(cart), Times.Once);
            promotionMock2.Verify(f => f.IsPromotionApplicable(cart), Times.Once);
            promotionMock1.VerifyNoOtherCalls();
            promotionMock2.VerifyNoOtherCalls();
        }

        [Test]
        public void If_a_promotions_is_applicable_it_should_be_applied()
        {
            //Arrange
            var cart = new Cart();
            var promotionMock1 = new Mock<IPromotion>();
            var promotionMock2 = new Mock<IPromotion>();
            promotionMock1.Setup(x => x.IsPromotionApplicable(It.IsAny<Cart>()))
                .Returns(true);
            promotionMock2.Setup(x => x.IsPromotionApplicable(It.IsAny<Cart>()))
                .Returns(false);
            var promotions = new[] { promotionMock1.Object, promotionMock2.Object };

            //Act
            _promotionEvaluator.Evaluate(cart, promotions);

            //Assert
            promotionMock1.Verify(f => f.IsPromotionApplicable(cart), Times.Once);
            promotionMock2.Verify(f => f.IsPromotionApplicable(cart), Times.Once);
            promotionMock1.Verify(f => f.Apply(cart), Times.Once);
            promotionMock1.VerifyNoOtherCalls();
            promotionMock2.VerifyNoOtherCalls();
        }
    }
}