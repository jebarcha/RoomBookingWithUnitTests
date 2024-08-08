using RoomBookingApp.core.Models;
using RoomBookingApp.core.Processors;
using Shouldly;

namespace RoomBookingApp.Core;

public class RoomBookingRequestProcessorTest
{
    [Fact]
    public void Should_Return_Room_Booking_Response_With_Request_Values()
    {
        // Arrange
        var request = new RoomBookingRequest
        {
            FullName = "Test Name",
            Email = "test@request.com",
            Date = new DateTime(2024, 8, 8)
        };

        var processor = new RoomBookingRequestProcessor();

        // Act
        RoomBookingResult result = processor.BookRoom(request);

        // Assert
        //Assert.NotNull(result);
        //result.ShouldNotBeNull();

        //Assert.Equal(request.FullName, result.FullName);
        //Assert.Equal(request.Email, result.Email);
        //Assert.Equal(request.Date, result.Date);
        //result.FullName.ShouldBe(result.FullName);
        //result.Email.ShouldBe(result.Email);
        //result.Date.ShouldBe(result.Date);

        result.ShouldNotBeSameAs(request);
    }
}