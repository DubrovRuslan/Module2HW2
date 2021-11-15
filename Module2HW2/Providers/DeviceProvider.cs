using Module2HW2.Entityes;

namespace Module2HW2.Providers
{
    public class DeviceProvider
    {
        private int _countEntityes = 0;
        private Entity[] _entities;
        public void AddNewEntity(string name, string model, double price)
        {
            Entity[] tempEntityes = new Entity[_countEntityes + 1];
            for (int i = 0; i < _countEntityes; i++)
            {
                tempEntityes[i] = _entities[i];
            }

            var newId = (_countEntityes == 0) ? 1 : _entities[_countEntityes - 1].Id + 1;
            tempEntityes[_countEntityes] = new Entity(newId);
            tempEntityes[_countEntityes].Name = name;
            tempEntityes[_countEntityes].Model = model;
            tempEntityes[_countEntityes].Price = price;
            _entities = tempEntityes;
            _countEntityes++;
        }

        public Entity[] GetAllEntityes()
        {
            if (_countEntityes == 0)
            {
                return null;
            }

            return _entities;
        }

        public Entity[] GetEntityesByName(string name)
        {
            if (_countEntityes == 0)
            {
                return null;
            }

            var countFind = 0;
            foreach (var entity in _entities)
            {
                if (entity.Name.Contains(name))
                {
                    countFind++;
                }
            }

            Entity[] entitiesFound = new Entity[countFind];
            for (int i = 0, j = 0; i < _countEntityes; i++)
            {
                if (_entities[i].Name.Contains(name))
                {
                    entitiesFound[j] = _entities[i];
                    j++;
                }
            }

            return entitiesFound;
        }

        public Entity[] GetEntityesByModel(string model)
        {
            if (_countEntityes == 0)
            {
                return null;
            }

            var countFind = 0;
            foreach (var entity in _entities)
            {
                if (entity.Model.Contains(model))
                {
                    countFind++;
                }
            }

            Entity[] entitiesFound = new Entity[countFind];
            for (int i = 0, j = 0; i < _countEntityes; i++)
            {
                if (_entities[i].Model.Contains(model))
                {
                    entitiesFound[j] = _entities[i];
                    j++;
                }
            }

            return entitiesFound;
        }

        public Entity[] GetEntityesByPrice(double minPrice, double maxPrice)
        {
            if (_countEntityes == 0)
            {
                return null;
            }

            var countFind = 0;
            foreach (var entity in _entities)
            {
                if (entity.Price >= minPrice && entity.Price <= maxPrice)
                {
                    countFind++;
                }
            }

            Entity[] entitiesFound = new Entity[countFind];
            for (int i = 0, j = 0; i < _countEntityes; i++)
            {
                if (_entities[i].Price >= minPrice && _entities[i].Price <= maxPrice)
                {
                    entitiesFound[j] = _entities[i];
                    j++;
                }
            }

            return entitiesFound;
        }

        public bool DeleteEntityes(int[] idToDelete)
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

            Entity[] tempEntityes = new Entity[_countEntityes - idToDelete.Length];
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