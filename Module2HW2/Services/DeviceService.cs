using Module2HW2.Entityes;
using Module2HW2.Providers;

namespace Module2HW2.Services
{
    public class DeviceService
    {
        private EntityProvider _entityProvider;
        public DeviceService()
        {
            _entityProvider = new EntityProvider();
        }

        public void AddNewDevice(string name, string model, double price)
        {
            _entityProvider.AddNewEntity(name, model, price);
        }

        public Device[] GetAllDevices()
        {
            return ConvertEnityToDevice(_entityProvider.GetAllEntityes());
        }

        public Device[] GetDeviceByName(string name)
        {
            return ConvertEnityToDevice(_entityProvider.GetEntityesByName(name));
        }

        public Device[] GetDeviceByModel(string model)
        {
            return ConvertEnityToDevice(_entityProvider.GetEntityesByModel(model));
        }

        public Device[] GetDeviceByPrice(double minPrice, double maxPrice)
        {
            return ConvertEnityToDevice(_entityProvider.GetEntityesByPrice(minPrice, maxPrice));
        }

        public bool DeleteDevices(Device[] devices)
        {
            var devicesId = new int[devices.Length];
            for (var i = 0; i < devices.Length; i++)
            {
                devicesId[i] = devices[i].Id;
            }

            return _entityProvider.DeleteEntityes(devicesId);
        }

        private Entity ConvertDiviceToEntity(Device device)
        {
            var entity = new Entity(device.Id);
            entity.Model = device.Model;
            entity.Name = device.Name;
            entity.Price = device.Price;
            return entity;
        }

        private Entity[] ConvertDiviceToEntity(Device[] devices)
        {
            var entities = new Entity[devices.Length];
            for (var i = 0; i < devices.Length; i++)
            {
                entities[i] = ConvertDiviceToEntity(devices[i]);
            }

            return entities;
        }

        private Device ConvertEnityToDevice(Entity entity)
        {
            var device = new Device(entity.Id);
            device.Model = entity.Model;
            device.Name = entity.Name;
            device.Price = entity.Price;
            return device;
        }

        private Device[] ConvertEnityToDevice(Entity[] entityes)
        {
            var devices = new Device[entityes.Length];
            for (var i = 0; i < entityes.Length; i++)
            {
                devices[i] = ConvertEnityToDevice(entityes[i]);
            }

            return devices;
        }
    }
}