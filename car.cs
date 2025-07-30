// Represents a Car, derived from Vehicle
public class Car : Vehicle
{
    public decimal Freight { get; set; } // Additional delivery cost

    public Car(string make, int year, decimal basePrice, decimal tax, decimal freight)
        : base("Car", make, year, basePrice, tax)
    {
        Freight = freight;
        GenerateVIN();
        CalculateSellingPrice();
    }

    // VIN starts with "C" followed by 5 random characters
    public override void GenerateVIN()
    {
        VIN = "C" + Guid.NewGuid().ToString("N").Substring(0, 5).ToUpper();
    }

    // More complex pricing logic for older cars or expensive base price
    public override void CalculateSellingPrice()
    {
        if (YearManufactured < 1970)
            SellingPrice = BasePrice + (BasePrice * Tax / 100) + (2 * Freight) + 2000;
        else if (BasePrice > 50000)
            SellingPrice = BasePrice + (BasePrice * Tax / 100) + Freight;
        else
            SellingPrice = BasePrice + (BasePrice * Tax / 100);
    }

    // Overloads for different price calculation scenarios
    public void CalculateSellingPrice(decimal basePrice, decimal tax) =>
        SellingPrice = basePrice + (basePrice * tax / 100);

    public void CalculateSellingPrice(decimal basePrice, decimal tax, decimal freight) =>
        SellingPrice = basePrice + (basePrice * tax / 100) + freight;

    public void CalculateSellingPrice(decimal basePrice, int year, decimal tax, decimal freight) =>
        SellingPrice = basePrice + (basePrice * tax / 100) + (2 * freight) + 2000;
}
