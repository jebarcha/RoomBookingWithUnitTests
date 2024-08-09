using RoomBookingApp.Core.BaseModels;
using RoomBookingApp.Core.Enums;

namespace RoomBookingApp.core.Models;

public class RoomBookingResult : RoomBookingBase
{
    public BookingResultFlag Flag { get; set; }
    public int? RoomBookingId { get; set; }
}