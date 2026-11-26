namespace NovaHarvest.Web.Models;

public class Ticket
{
    public string Reservation { get; init; }
    public string Product { get; init; }
    public int Kg { get; init; }
    public string Pickup { get; init; }
    public DateTime GeneratedAt { get; init; }
}