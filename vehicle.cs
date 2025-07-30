// Base class representing a general vehicle
public class Vehicle
{
    public string VehicleType { get; set; } // e.g., Car, Truck, Bus
    public string Make { get; set; }        // Manufacturer name
    public string VIN { get; set; }         // Vehicle Identification Number
    public int YearManufactured { get; set; }
    public decimal BasePrice { get; set; }  // Starting price before tax
    public decimal Tax { get; set; }        // Tax percentage
    public decimal SellingPrice { get; set; } // Final calculated price

    // Constructor to initialize shared vehicle properties
    public Vehicle(string type, string make, int year, decimal basePrice, decimal tax)
    {
        VehicleType = type;
        Make = make;
        YearManufactured = year;
        BasePrice = basePrice;
        Tax = tax;
    }

    // Virtual method to calculate basic selling price (can be overridden)
    public virtual void CalculateSellingPrice()
    {
        SellingPrice = BasePrice + (BasePrice * Tax / 100);
    }

    // Virtual method to generate a default VIN
    public virtual void GenerateVIN()
    {
        VIN = "GENERIC" + new Random().Next(1000, 9999);
    }
}
