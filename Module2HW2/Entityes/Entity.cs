namespace Module2HW2.Entityes
{
    public class Entity
    {
        private readonly int _id;
        public Entity(int id)
        {
            _id = id;
        }

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public string Name { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
    }
}
