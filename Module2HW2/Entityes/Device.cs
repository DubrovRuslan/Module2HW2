namespace Module2HW2.Entityes
{
    public class Device
    {
        private readonly Сurrency _сurrency = Configurations.Instance.Currency;

        public int Id { get; init; }
        public string Name { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
    }
}