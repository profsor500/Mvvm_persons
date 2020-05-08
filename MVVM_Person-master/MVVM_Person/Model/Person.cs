using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Person.Model
{
    public class Person
    {
        private string name { get; set; }
        public string Name {get { return this.name; } set { this.name = value; } }
        private string lastname { get; set; }
        public string LastName { get { return this.lastname; } set { this.lastname = value; } }

        private int weight { get; set; }
        public int Weight { get { return this.weight; } set { this.weight = value; } }
        private int age { get; set; }
        public int Age { get { return this.age; } set { this.weight = value; } }








        public string ALL
        {
            get
            {
                return $"{this.Name} {this.LastName}, waga(kg): {this.Weight}, wiek(lata): {this.Age}";
            }
        }

        public Person()
        {
            this.Name = "Name";
            this.LastName = "LastName";
            this.Weight = 1;
            this.Age = 1;
        }


        public Person(string Name, string LastName, int Weight, int Age)
        {
            this.Name = Name;
            this.LastName = LastName;
            this.Weight = Weight;
            this.Age = Age;
        }

        
    }
}
