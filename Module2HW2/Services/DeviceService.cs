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
            _deviceProvider.AddNewEntity(name, model, price);
        }

        public Device[] GetAllDevices()
        {
            return ConvertEnityToDevice(_deviceProvider.GetAllEntityes());
        }

        public Device[] GetDeviceByName(string name)
        {
            return ConvertEnityToDevice(_deviceProvider.GetEntityesByName(name));
        }

        public Device[] GetDeviceByModel(string model)
        {
            return ConvertEnityToDevice(_deviceProvider.GetEntityesByModel(model));
        }

        public Device[] GetDeviceByPrice(double minPrice, double maxPrice)
        {
            return ConvertEnityToDevice(_deviceProvider.GetEntityesByPrice(minPrice, maxPrice));
        }

        public bool DeleteDevices(Device[] devices)
        {
            int[] devicesId = new int[devices.Length];
            for (var i = 0; i < devices.Length; i++)
            {
                devicesId[i] = devices[i].Id;
            }

            return _deviceProvider.DeleteEntityes(devicesId);
        }

        private Entity ConvertDiviceToEntity(Device device)
        {
            Entity entity = new Entity(device.Id);
            entity.Model = device.Model;
            entity.Name = device.Name;
            entity.Price = device.Price;
            return entity;
        }

        private Entity[] ConvertDiviceToEntity(Device[] devices)
        {
            Entity[] entities = new Entity[devices.Length];
            for (var i = 0; i < devices.Length; i++)
            {
                entities[i] = ConvertDiviceToEntity(devices[i]);
            }

            return entities;
        }

        private Device ConvertEnityToDevice(Entity entity)
        {
            Device device = new Device(entity.Id);
            device.Model = entity.Model;
            device.Name = entity.Name;
            device.Price = entity.Price;
            return device;
        }

        private Device[] ConvertEnityToDevice(Entity[] entityes)
        {
            Device[] devices = new Device[entityes.Length];
            for (var i = 0; i < entityes.Length; i++)
            {
                devices[i] = ConvertEnityToDevice(entityes[i]);
            }

            return devices;
        }
    }
}