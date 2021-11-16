using Module2HW2.Entityes;

namespace Module2HW2.Providers
{
    public class ClientProvider
    {
        private Client[] _clients;
        private int _clientCount = 0;
        public Client[] Clients
        {
            get
            {
                return _clients;
            }
        }

        public void AddClient(string firstName, string lastname, int age, string email, string phoneNumber)
        {
            var newId = (_clientCount == 0) ? 1 : _clients[_clientCount - 1].Id + 1;
            var clientsTemp = new Client[_clientCount + 1];
            for (int i = 0; i < _clientCount; i++)
            {
                clientsTemp[i] = _clients[i];
            }

            clientsTemp[_clientCount] = new Client { Id = newId, FirstName = firstName, LastName = lastname, Age = age, Email = email, PhoneNumber = phoneNumber };
            _clients = clientsTemp;
            _clientCount++;
        }
    }
}
