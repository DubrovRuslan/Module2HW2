using System;
using Module2HW2.Entityes;

namespace Module2HW2.Services
{
    public class OrderService
    {
        private Order[] _orders;
        private int _ordersCount = 0;
        public int AddOrder(Client client, Device[] devices)
        {
            var newId = (_ordersCount == 0) ? 1 : _orders[_ordersCount - 1].Id + 1;
            var tempOrders = new Order[_ordersCount + 1];
            for (var i = 0; i < _ordersCount; i++)
            {
                tempOrders[i] = _orders[i];
            }

            tempOrders[_ordersCount] = new Order { Id = newId, OrderClient = client, OrderTime = DateTime.UtcNow };
            tempOrders[_ordersCount].AddDevices(devices);
            _orders = tempOrders;
            _ordersCount++;
            return newId;
        }

        public void PaidOrder(int id)
        {
            for (var i = 0; i < _ordersCount; i++)
            {
                if (_orders[i].Id == id)
                {
                    _orders[i].Paid = true;
                    break;
                }
            }
        }

        public int GetLastOrderId()
        {
            return _orders[_ordersCount - 1].Id;
        }

        public Order[] GetAllOrders()
        {
            return _orders;
        }
    }
}
