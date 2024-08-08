using RoomBookingApp.core.Models;

namespace RoomBookingApp.core.Processors;

public class RoomBookingRequestProcessor
{
    public RoomBookingRequestProcessor()
    {
    }

    public RoomBookingResult BookRoom(RoomBookingRequest bookingRequest)
    {
        return new RoomBookingResult
        {
            FullName = bookingRequest.FullName,
            Email = bookingRequest.Email,
            Date = bookingRequest.Date,
        };
    }
}