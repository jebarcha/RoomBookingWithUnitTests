using RoomBookingApp.core.Models;
using RoomBookingApp.core.Processors;
using Shouldly;

namespace RoomBookingApp.Core;

public class RoomBookingRequestProcessorTest
{
    private readonly RoomBookingRequestProcessor _processor;

    public RoomBookingRequestProcessorTest()
    {
        _processor = new RoomBookingRequestProcessor();
    }

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

        //var processor = new RoomBookingRequestProcessor();

        // Act
        RoomBookingResult result = _processor.BookRoom(request);

        // Assert
        //Assert.NotNull(result);
        //result.ShouldNotBeNull();

        //Assert.Equal(request.FullName, result.FullName);
        //Assert.Equal(request.Email, result.Email);
        //Assert.Equal(request.Date, result.Date);
        //result.FullName.ShouldBe(result.FullName);
        //result.Email.ShouldBe(result.Email);
        //result.Date.ShouldBe(result.Date);
    }

    [Fact]
    public void Should_Throw_Exception_For_Null_Request()
    {
        //var processor = new RoomBookingRequestProcessor();

        var exception = Should.Throw<ArgumentNullException>(() => _processor.BookRoom(null));
        exception.ParamName.ShouldBe("bookingRequest");
    }
}