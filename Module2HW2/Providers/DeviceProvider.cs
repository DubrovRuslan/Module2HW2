using Module2HW2.Entityes;

namespace Module2HW2.Providers
{
    public class DeviceProvider
    {
        private int _countEntityes = 0;
        private Device[] _entities;
        public void AddNewDevice(string name, string model, double price)
        {
            var tempEntityes = new Device[_countEntityes + 1];
            for (int i = 0; i < _countEntityes; i++)
            {
                tempEntityes[i] = _entities[i];
            }

            var newId = (_countEntityes == 0) ? 1 : _entities[_countEntityes - 1].Id + 1;
            tempEntityes[_countEntityes] = new Device { Id = newId, Name = name, Model = model, Price = price };
            _entities = tempEntityes;
            _countEntityes++;
        }

        public Device[] GetAllDevices()
        {
            if (_countEntityes == 0)
            {
                return null;
            }

            return _entities;
        }

        public bool DeleteDevices(int[] idToDelete)
        {
            bool flagIsOk = false;
            for (var i = 0; i < idToDelete.Length; i++)
            {
                flagIsOk = false;
                for (var j = 0; j < _countEntityes; j++)
                {
                    if (idToDelete[i] == _entities[j].Id)
                    {
                        flagIsOk = true;
                        break;
                    }
                }

                if (!flagIsOk)
                {
                    return flagIsOk;
                }
            }

            var tempEntityes = new Device[_countEntityes - idToDelete.Length];
            for (int i = 0, j = 0; i < _countEntityes; i++)
            {
                var deleteFlag = false;
                foreach (var id in idToDelete)
                {
                    if (id == _entities[i].Id)
                    {
                        deleteFlag = true;
                        break;
                    }
                }

                if (!deleteFlag)
                {
                    tempEntityes[j] = _entities[i];
                    j++;
                }
            }

            _entities = tempEntityes;
            _countEntityes -= idToDelete.Length;
            return flagIsOk;
        }
    }
}