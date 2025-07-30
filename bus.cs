public class Bus : Vehicle
{
    public int PassengerCapacity { get; set; }

    public Bus(string make, int year, decimal basePrice, decimal tax, int capacity)
        : base("Bus", make, year, basePrice, tax)
    {
        PassengerCapacity = capacity;
        GenerateVIN();
        CalculateSellingPrice();
    }

    public override void GenerateVIN()
    {
        var rand = new Random();
        VIN = "B" + (char)rand.Next(65, 91) + (char)rand.Next(65, 91) + rand.Next(100, 999);
    }

    public override void CalculateSellingPrice()
    {
        if (PassengerCapacity > 40)
            SellingPrice = BasePrice + (BasePrice * Tax / 100) + (PassengerCapacity - 40) * 200;
        else
            base.CalculateSellingPrice();
    }
}
