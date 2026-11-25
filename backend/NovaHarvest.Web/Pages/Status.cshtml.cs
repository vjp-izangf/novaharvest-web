using Microsoft.AspNetCore.Mvc.RazorPages;
using NovaHarvest.Web.Models;

namespace NovaHarvest.Web.Pages;

public class StatusModel : PageModel
{
    public DateTime ServerTime { get; private set; }
    public string Server { get; private set; }
    public int Visits { get; private set; }

    public void OnGet()
    {
        ServerTime = DateTime.Now;
        Server = Environment.MachineName;

        SiteStats.Visits++;
        Visits = SiteStats.Visits;
    }
}