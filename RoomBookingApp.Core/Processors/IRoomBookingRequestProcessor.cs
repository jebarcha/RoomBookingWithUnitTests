using RoomBookingApp.core.Models;

namespace RoomBookingApp.core.Processors;

public interface IRoomBookingRequestProcessor
{
    RoomBookingResult BookRoom(RoomBookingRequest bookingRequest);
}