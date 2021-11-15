using System;
namespace Module2HW2.Entityes
{
    public class Order
    {
        private readonly int _id;
        private Device[] _devices;
        private double _totalPrice;
        public Order(int id)
        {
            _id = id;
        }

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public Device[] Devices
        {
            get
            {
                return _devices;
            }
        }

        public Client OrderClient { get; set; }
        public DateTime OrderTime { get; set; }
        public bool Paid { get; set; }
        public void AddDevices(Device[] devices)
        {
            _devices = devices;
            _totalPrice = 0.0;
            foreach (var device in _devices)
            {
                _totalPrice += device.Price;
            }
        }

        public double GetTotalPrice()
        {
            return _totalPrice;
        }
    }
}
