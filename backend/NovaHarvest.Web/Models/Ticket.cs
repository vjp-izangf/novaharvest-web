namespace NovaHarvest.Web.Models;

public class Ticket
{
    public string Reservation { get; set; }
    public string Product { get; set; }
    public int Kg { get; set; }
    public string Pickup { get; set; }
    public DateTime GeneratedAt { get; set; }
}