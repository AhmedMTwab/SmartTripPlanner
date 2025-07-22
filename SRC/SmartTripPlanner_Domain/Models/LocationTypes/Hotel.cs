using System;

namespace SmartTripPlanner_Domain.Models.LocationType;

public class Hotel : Location
{
    public int StarRating { get; set; }
    public string RoomType { get; set; }
    public int NumberOfRooms { get; set; }
    public double PricePerNight { get; set; }
    public string? Amenities { get; set; }
    public DateTime? CheckInTime { get; set; }
    public DateTime? CheckOutTime { get; set; }

}
