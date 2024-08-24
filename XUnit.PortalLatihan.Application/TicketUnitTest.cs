using Microsoft.AspNetCore.Mvc;
using Moq;
using PortalLatihan.API.Controllers;
using PortalLatihan.Application.Services.Interface;
using PortalLatihan.Application.ViewModel;

namespace XUnit.PortalLatihan.Application
{
    public class TicketUnitTest
    {
[Fact]
        public void GetList_Success()
        {
            // Arrange
            var mockTicketService = new Mock<ITicketService>();
            mockTicketService.Setup(x => x.GetList()).ReturnsAsync(new List<TicketListResponse>
            {
                new TicketListResponse
                {
                    BuyerName = "Buyer 1",
                    Quantity = 1,
                    BaseFee = 1000,
                    Discount = 0,
                    TotalFee = 1000,
                    Status = "Pending"
                },
                new TicketListResponse
                {
                    BuyerName = "Buyer 2",
                    Quantity = 2,
                    BaseFee = 2000,
                    Discount = 0,
                    TotalFee = 2000,
                    Status = "Paid"
                }
            });

            var ticketController = new TicketController(mockTicketService.Object, null);

            // Act
            var result = ticketController.GetList().Result as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(2, (result.Value as List<TicketListResponse>).Count);
        }

        [Fact]
        public void GetListByTrainingID_Success()
        {
            // Arrange
            var mockTicketService = new Mock<ITicketService>();

            var trainingFromServiceList = new List<TicketListResponse>
            {
                new TicketListResponse
                {
                    BuyerName = "Buyer 1",
                    Quantity = 1,
                    BaseFee = 1000,
                    Discount = 0,
                    TotalFee = 1000,
                    Status = "Pending"
                },
                new TicketListResponse
                {
                    BuyerName = "Buyer 2",
                    Quantity = 2,
                    BaseFee = 2000,
                    Discount = 0,
                    TotalFee = 2000,
                    Status = "Paid"
                }
            };

            mockTicketService.Setup(x => x.GetListByTrainingID(It.IsAny<Guid>())).ReturnsAsync(trainingFromServiceList);

            var ticketController = new TicketController(mockTicketService.Object, null);

            // Act
            var result = ticketController.GetListByTrainingID(Guid.NewGuid()).Result as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(2, (result.Value as List<TicketListResponse>).Count);
        }
    }
}
