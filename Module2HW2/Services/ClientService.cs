using Module2HW2.Entityes;
using Module2HW2.Providers;

namespace Module2HW2.Services
{
    public class ClientService
    {
        private ClientProvider _clientProvider;
        public ClientService()
        {
            _clientProvider = new ClientProvider();
        }

        public Client GetClient(int id)
        {
            foreach (var client in _clientProvider.Clients)
            {
                if (client.Id == id)
                {
                    return client;
                }
            }

            return null;
        }

        public void AddClient(string firstName, string lastname, int age, string email)
        {
            _clientProvider.AddClient(firstName, lastname, age, email);
        }
    }
}
