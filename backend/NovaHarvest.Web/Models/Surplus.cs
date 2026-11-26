namespace NovaHarvest.Web.Models;

public class Surplus
{
    public string Product { get; init; } 
    public string Producer { get; init; } 
    public string Village { get; init; } 
    public DateTime HarvestDate { get; init; } 
    public int AvailableKg { get; init; } 
    public int ReservedKg { get; init; }
    public decimal PricePerKg { get; init; }
    public string? Note { get; init; } 
}