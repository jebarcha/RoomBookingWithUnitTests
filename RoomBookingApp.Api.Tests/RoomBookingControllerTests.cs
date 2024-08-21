using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using RoomBookingApp.Api.Controllers;
using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Processors;
using RoomBookingApp.Core.Enums;

namespace RoomBookingApp.Api.Tests;

public class RoomBookingControllerTests
{
    private Mock<IRoomBookingRequestProcessor> _roomBookingProcessor;
    private RoomBookingController _controller;
    private RoomBookingRequest _request;
    private RoomBookingResult _result;

    public RoomBookingControllerTests()
    {
        _roomBookingProcessor = new Mock<IRoomBookingRequestProcessor>();
        _controller = new RoomBookingController(_roomBookingProcessor.Object);
        _request = new RoomBookingRequest();
        _result = new RoomBookingResult();

        _roomBookingProcessor.Setup(x => x.BookRoom(_request)).Returns(_result);
    }

    [Theory]
    [InlineData(1, true, typeof(OkObjectResult), BookingResultFlag.Success)]
    [InlineData(0, false, typeof(BadRequestObjectResult), BookingResultFlag.Failure)]
    public async Task Should_Return_forecast_Results(int expectedMethodCalls, bool isModelValid,
        Type expectedActionResultType, BookingResultFlag bookingResultFlag )
    {
        // Arrange
        if (!isModelValid)
        {
            _controller.ModelState.AddModelError("Key", "ErrorMEssage");
        }

        _result.Flag = bookingResultFlag;

        // Act
        var result = await _controller.BookRoom(_request);

        // Assert
        result.Should().BeOfType(expectedActionResultType);
        _roomBookingProcessor.Verify(x => x.BookRoom(_request), Times.Exactly(expectedMethodCalls));
    }

}
