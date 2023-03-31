namespace CarDealer.DTOs.Export;

public class ExportSaleDto
{
    public string Name { get; set; } = null!;

    public int BoughtCars { get; set; }

    public decimal[] CarPrices { get; set; } = null!;
}
