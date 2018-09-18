using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Raw_Data
{
    class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }

        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)
        {
            Model = model;
            Engine = new Engine(engineSpeed,enginePower);
            Cargo = new Cargo(cargoType,cargoWeight);
            Tires = new Tire[4];
            Tires.SetValue(new Tire(tire1Pressure, tire1Age), 0);
            Tires.SetValue(new Tire(tire2Pressure, tire2Age), 1);
            Tires.SetValue(new Tire(tire3Pressure, tire3Age), 2);
            Tires.SetValue(new Tire(tire4Pressure, tire4Age), 3);
        }

        public override string ToString()
        {
            return $"{this.Model}";
        }
    }
}
