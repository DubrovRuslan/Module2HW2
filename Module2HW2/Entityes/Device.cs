namespace Module2HW2.Entityes
{
    public class Device
    {
        private readonly int _id;
        private readonly Сurrency _сurrency = Configurations.Instance.Currency;
        public Device(int id)
        {
            _id = id;
        }

        public Device(int id, string name, string model, double price)
        {
            _id = id;
            Name = name;
            Model = model;
            Price = price;
        }

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public string Name { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
    }
}