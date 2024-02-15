using Bogus;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.contratos;
using WebApplication1.Entities;
using WebApplication1.Enums;
using WebApplication1.UseCases.leiloes.GetCurrent;
using Xunit;

namespace UseCases.Texts.leiloes.GetCurrent
{
    public class GetCurrentLeilaoTest
    {
        [Fact]
        public void Sucess()
        {
            //Arrenge Variaveis



            var entity = new Faker<Auction>()
            .RuleFor(auction => auction.Id, f => f.Random.Number(1, 700))
            .RuleFor(auction => auction.Name, f => f.Lorem.Word())
            .RuleFor(auction => auction.Starts, f => f.Date.Past())
            .RuleFor(auction => auction.Ends, f => f.Date.Future())
            .RuleFor(auction => auction.Items, (f, auction) => new List<Item>
            {
                new Item
                {
                    Id = f.Random.Number(1, 700),
                    Name = f.Commerce.ProductName(),
                    Brand = f.Commerce.Department(),
                    BasePrice = f.Random.Decimal(50, 1000),
                    Condition = f.PickRandom<Condition>(),
                    AuctionId = auction.Id
                }
            }).Generate();

            var mock = new Mock<IAuctionRepository>();
            mock.Setup(i => i.GetCurrent()).Returns(new Auction());
            var UseCase = new GetCurrentLeilao(mock.Object);
            

            //act Acao
           var auction = UseCase.Execute();

            //assert

            //Assert.NotNull(auction);

            auction.Should().NotBeNull();
            auction.Id.Should().Be(entity.Id);
            auction.Name.Should().Be(entity.Name);

        }


    }
}
