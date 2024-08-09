using RoomBookingApp.Core.Enums;
using RoomBookingApp.Core.Models;

namespace RoomBookingApp.core.Models;

public class RoomBookingResult : RoomBookingBase
{
    public BookingResultFlag Flag { get; set; }
    public int? RoomBookingId { get; set; }
}