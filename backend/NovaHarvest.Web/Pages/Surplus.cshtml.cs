using Microsoft.AspNetCore.Mvc.RazorPages;
using NovaHarvest.Web.Models;

namespace NovaHarvest.Web.Pages;

public class SurplusModel : PageModel
{
    private const decimal SurplusDiscount = 0.30m;
    private const int BoxKg = 5;
    private const int ShelfLifeDays = 7;
    private const int LowStockKg = 50;

    public Surplus Surplus { get; } = new(
        "Cereza Picota",
        "Huerta Los Castaños",
        "Cabezuela del Valle",
        DateTime.Today.AddDays(-2),
        343,
        120,
        3.20m,
        "<b>Recoger antes de las 14:00</b>"
    );

    public int StockKg { get; private set; }

    public int Boxes { get; private set; }
    public int LooseKg { get; private set; }

    public DateTime ConsumeByDate { get; private set; }
    public int DaysToConsume { get; private set; }

    public decimal SurplusPrice { get; private set; }

    public decimal SurplusValue { get; private set; }

    public bool LowStock { get; private set; }

    public string StockStatus { get; private set; }

    public bool Urgent { get; private set; }

    public string NoteText { get; private set; }

    public bool OutOfStock { get; private set; }

    public void OnGet()
    {
        StockKg = Surplus.AvailableKg - Surplus.ReservedKg;

        Boxes = StockKg / BoxKg;
        LooseKg = StockKg % BoxKg;

        ConsumeByDate = Surplus.HarvestDate.AddDays(ShelfLifeDays);
        DaysToConsume = (ConsumeByDate - DateTime.Today).Days;

        SurplusPrice = Surplus.PricePerKg * (1 - SurplusDiscount);

        SurplusValue = StockKg * SurplusPrice;

        LowStock = StockKg < LowStockKg;

        StockStatus = StockKg == 0 ? "Agotado" : LowStock ? "¡Últimos kilos!" : "Disponible";

        Urgent = DaysToConsume <= 2 && StockKg > 0;

        NoteText = Surplus.Note ?? "Sin observaciones";

        OutOfStock = StockKg == 0;
    }
}