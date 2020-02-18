using System;

    public class Profile
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public double weight { get; set; }
        public double length { get; set; }
        public int type { get; set; }
        public string username { get; set; }
        public string password { get; set; }


    public Profile() { }
        public double GetBmi(double weight, double length)
        {
            return Math.Round(weight / (length * length), 2);
        }

    }

