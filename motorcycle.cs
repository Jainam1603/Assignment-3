// Represents a Motorcycle, derived from Vehicle
public class Motorcycle : Vehicle
{
    public bool HasSideCar { get; set; }

    public Motorcycle(string make, int year, decimal basePrice, decimal tax, bool hasSideCar)
        : base("Motorcycle", make, year, basePrice, tax)
    {
        HasSideCar = hasSideCar;
        GenerateVIN();
        CalculateSellingPrice();
    }

    // VIN for motorcycles starts with "MC" and 4 random letters
    public override void GenerateVIN()
    {
        const string letters = "ABDEFGHIJKLMNOPQRSTUVWXYZ";
        var rand = new Random();
        VIN = "MC";
        for (int i = 0; i < 4; i++)
            VIN += letters[rand.Next(letters.Length)];
    }
}
