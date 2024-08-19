using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using RoomBookingApp.Api.Controllers;

namespace RoomBookingApp.Api.Tests;

public class UnitTest1
{
    [Fact]
    public void Should_Return_forecast_Results()
    {
        var loggerMock = new Mock<ILogger<WeatherForecastController>>();
        var controller = new WeatherForecastController(loggerMock.Object);

        var result = controller.Get();

        result.Should().NotBeNull()
            .And.HaveCountGreaterThan(1);
    }
}