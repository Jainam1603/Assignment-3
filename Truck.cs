// Represents a Truck, derived from Vehicle
public class Truck : Vehicle
{
    public int CargoCapacity { get; set; } // In kilograms or pounds

    public Truck(string make, int year, decimal basePrice, decimal tax, int capacity)
        : base("Truck", make, year, basePrice, tax)
    {
        CargoCapacity = capacity;
        GenerateVIN();
        CalculateSellingPrice();
    }

    // VIN for trucks starts with "T" and has 5 digits
    public override void GenerateVIN()
    {
        VIN = "T" + new Random().Next(10000, 99999).ToString();
    }
}
