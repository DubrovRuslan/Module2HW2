using Module2HW2.Entityes;
using Module2HW2.Services;

namespace Module2HW2
{
    public class Actions
    {
        private readonly DeviceService _deviceService;
        private readonly ClientService _clientService;
        private readonly OrderService _orderService;
        private Cart _cart = Cart.Instance;
        private Logger _logger = Logger.Instance;
        public Actions()
        {
            _deviceService = new DeviceService();
            _clientService = new ClientService();
            _orderService = new OrderService();
        }

        public void NewClient(string firstName, string lastname, int age, string email)
        {
            _clientService.AddClient(firstName, lastname, age, email);
        }

        public void SomeTestDevices()
        {
            _deviceService.AddNewDevice("Toshiba", "Satellite", 13456);
            _deviceService.AddNewDevice("Xiaomi", "MiBook", 23400);
            _deviceService.AddNewDevice("Samsung", "Galaxy Chromebook", 25600);
            _deviceService.AddNewDevice("Apple", "MacBook Pro", 43500);
            _deviceService.AddNewDevice("Lenovo", "ThinkPad", 51435);
            _deviceService.AddNewDevice("Asus", "ZenBook", 19234);
            _deviceService.AddNewDevice("Sony", "Vaio", 43232);
            _deviceService.AddNewDevice("Hp", "Envy", 29243);
            _deviceService.AddNewDevice("Dell", "XPS", 18234);
            _deviceService.AddNewDevice("MSI", "Modern", 23435);
            _deviceService.AddNewDevice("Asus", "Rog", 46234);
            _deviceService.AddNewDevice("Apple", "MacBook Air", 35133);
            _deviceService.AddNewDevice("Toshiba", "DuraBook", 99999);
            _deviceService.AddNewDevice("Sager", "Ultimate",  14343);
        }

        public void GetFoodsToCart()
        {
            var devicesClientLikes = _deviceService.GetDeviceByPrice(20000.0, 30000.0);
            foreach (var device in devicesClientLikes)
            {
                _cart.AddToCart(device);
            }
        }

        public int ConfirmOrder()
        {
            var orderDevices = _cart.Confirm();
            var orderNumber = _orderService.AddOrder(_clientService.GetClient(1), orderDevices);
            _deviceService.DeleteDevices(orderDevices);
            return orderNumber;
        }

        public void SaveCurentStateInLog()
        {
            _logger.WriteToLog("============================");
            _logger.WriteToLog("НА СКЛАДЕ:");
            var devices = _deviceService.GetAllDevices();
            if (devices != null)
            {
                foreach (var device in _deviceService.GetAllDevices())
                {
                    _logger.WriteToLog($"{device.Name} {device.Model} {device.Price}");
                }
            }

            _logger.WriteToLog("В КОРЗИНЕ:");
            devices = _cart.GetNowDevicesInCart();
            if (devices != null)
            {
                foreach (var device in devices)
                {
                    _logger.WriteToLog($"{device.Name} {device.Model} {device.Price}");
                }
            }

            _logger.WriteToLog("ЗАКАЗЫ:");
            var orders = _orderService.GetAllOrders();
            if (orders != null)
            {
                foreach (var order in orders)
                {
                    _logger.WriteToLog($"{order.OrderClient.FirstName} {order.OrderTime.ToShortDateString()} {order.GetTotalPrice()} Грн");
                }
            }

            _logger.WriteToLog("============================");
        }

        public void PaidOrder()
        {
            _orderService.PaidOrder(_orderService.GetLastOrderId());
        }
    }
}
