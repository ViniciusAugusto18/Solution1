using Bogus;
using Castle.Core.Logging;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.communication.Request;
using WebApplication1.contratos;
using WebApplication1.Entities;
using WebApplication1.services;
using WebApplication1.UseCases.offers.create_offer;
using Xunit;

namespace UseCases.Test.Offers.CreateOffer;

public class CreateOfferUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Success(int itemId)
    {
        // Arrange

        var request = new Faker<RequestCreatedOfferJson>()
            .RuleFor(request => request.price, f => f.Random.Decimal(1, 700)).Generate();

        var offerRepository = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggerUsers>();
        loggedUser.Setup(i => i.User()).Returns(new User());

        var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);

        // Act
        var act = () => useCase.Execute(itemId, request);

        // Assert
        act.Should().NotThrow();
    }
}
