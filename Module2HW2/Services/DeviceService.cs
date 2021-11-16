using Module2HW2.Entityes;
using Module2HW2.Providers;

namespace Module2HW2.Services
{
    public class DeviceService
    {
        private DeviceProvider _deviceProvider;
        public DeviceService()
        {
            _deviceProvider = new DeviceProvider();
        }

        public void AddNewDevice(string name, string model, double price)
        {
            _deviceProvider.AddNewDevice(name, model, price);
        }

        public Device[] GetAllDevices()
        {
            return _deviceProvider.GetAllDevices();
        }

        public Device[] GetDeviceByName(string name)
        {
            var allDevices = _deviceProvider.GetAllDevices();
            if (allDevices.Length == 0)
            {
                return null;
            }

            var countFind = 0;
            foreach (var device in allDevices)
            {
                if (device.Name.Contains(name))
                {
                    countFind++;
                }
            }

            var devicesFound = new Device[countFind];
            for (int i = 0, j = 0; i < allDevices.Length; i++)
            {
                if (allDevices[i].Name.Contains(name))
                {
                    devicesFound[j] = allDevices[i];
                    j++;
                }
            }

            return devicesFound;
        }

        public Device[] GetDeviceByModel(string model)
        {
            var allDevices = _deviceProvider.GetAllDevices();
            if (allDevices.Length == 0)
            {
                return null;
            }

            var countFind = 0;
            foreach (var device in allDevices)
            {
                if (device.Model.Contains(model))
                {
                    countFind++;
                }
            }

            var devicesFound = new Device[countFind];
            for (int i = 0, j = 0; i < allDevices.Length; i++)
            {
                if (allDevices[i].Model.Contains(model))
                {
                    devicesFound[j] = allDevices[i];
                    j++;
                }
            }

            return devicesFound;
        }

        public Device[] GetDeviceByPrice(double minPrice, double maxPrice)
        {
            var allDevices = _deviceProvider.GetAllDevices();
            if (allDevices.Length == 0)
            {
                return null;
            }

            var countFind = 0;
            foreach (var device in allDevices)
            {
                if (device.Price >= minPrice && device.Price <= maxPrice)
                {
                    countFind++;
                }
            }

            var devicesFound = new Device[countFind];
            for (int i = 0, j = 0; i < allDevices.Length; i++)
            {
                if (allDevices[i].Price >= minPrice && allDevices[i].Price <= maxPrice)
                {
                    devicesFound[j] = allDevices[i];
                    j++;
                }
            }

            return devicesFound;
        }

        public bool DeleteDevices(Device[] devices)
        {
            var devicesId = new int[devices.Length];
            for (var i = 0; i < devices.Length; i++)
            {
                devicesId[i] = devices[i].Id;
            }

            return _deviceProvider.DeleteDevices(devicesId);
        }
    }
}