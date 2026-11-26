using Microsoft.AspNetCore.Mvc.RazorPages;
using NovaHarvest.Web.Models;

namespace NovaHarvest.Web.Pages.Reservations;

public class TicketModel : PageModel
{
    public Ticket Ticket { get; } = new()
    {
        Reservation = "RES-0001",
        Product = "Cereza Picota",
        Kg = 20,
        Pickup = "Cooperativa del Valle del Jerte",
        GeneratedAt = DateTime.Now
    };
}
