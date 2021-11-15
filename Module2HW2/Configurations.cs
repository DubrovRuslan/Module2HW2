using System;
using System.Collections.Generic;
using System.Linq;
namespace Module2HW2
{
    public sealed class Configurations
    {
        private static readonly Configurations _instance = new Configurations();

        static Configurations()
        {
        }

        private Configurations()
        {
            Currency = Сurrency.USD;
        }

        public int CartSize { get; set; }
        public Сurrency Currency { get; set; }
        public static Configurations Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
