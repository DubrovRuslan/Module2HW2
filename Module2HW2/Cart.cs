using Module2HW2.Entityes;

namespace Module2HW2
{
    public class Cart
    {
        private static readonly Cart _instance = new Cart();
        private Device[] _goodsInCart;
        private int _currentDeviceCount = 0;
        private double _totalPrice = 0.0;
        static Cart()
        {
        }

        private Cart()
        {
        }

        public static Cart Instance
        {
            get
            {
                return _instance;
            }
        }

        public void AddToCart(Device device)
        {
            if (_currentDeviceCount >= Configurations.Instance.CartSize)
            {
                return;
            }

            var cartTemp = new Device[_currentDeviceCount + 1];
            for (var i = 0; i < _currentDeviceCount; i++)
            {
                cartTemp[i] = _goodsInCart[i];
            }

            cartTemp[_currentDeviceCount] = device;
            _goodsInCart = cartTemp;
            _currentDeviceCount++;
            _totalPrice += device.Price;
        }

        public void CleanCart()
        {
            _currentDeviceCount = 0;
            _goodsInCart = null;
            _totalPrice = 0.0;
        }

        public Device[] Confirm()
        {
            var orderDevices = _goodsInCart;
            CleanCart();
            return orderDevices;
        }

        public Device[] GetNowDevicesInCart()
        {
            return _goodsInCart;
        }
    }
}
