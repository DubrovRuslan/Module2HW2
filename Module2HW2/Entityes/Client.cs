namespace Module2HW2.Entityes
{
    public class Client
    {
        private readonly int _id;
        public Client(int id)
        {
            _id = id;
        }

        public Client(int id, string firstName, string lastName, int age, string email)
        {
            _id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
        }

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}
