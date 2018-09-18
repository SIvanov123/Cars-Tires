using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Raw_Data

// TODO: Define a class Car that holds information about model, engine, cargo and a collection of exactly 4 tires.
// TODO: The engine, cargo and tire should be separate classes
// TODO: create a constructor that receives all information about the Car and creates and initializes its inner components (engine, cargo and tires).
// TODO: On the first line of input you will receive a number N - the amount of cars you have
// TODO: on each of the next N lines you will receive information about a car in the format “<Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType> <Tire1Pressure> <Tire1Age> <Tire2Pressure> <Tire2Age> <Tire3Pressure> <Tire3Age> <Tire4Pressure> <Tire4Age>”
// TODO: the speed, power, weight and tire age are integers, tire pressure is a double.
// TODO: After the N lines you will receive a single line with one of 2 commands “fragile” or “flamable”
// TODO:  if the command is “fragile” print all cars whose Cargo Type is “fragile” with a tire whose pressure is  < 1
// TODO: if the command is “flamable” print all cars whose Cargo Type is “flamable” and have Engine Power > 250.
// TODO: The cars should be printed in order of appearing in the input.

/*
Below 2 test data sets:
 
2
ChevroletAstro 200 180 1000 fragile 1.3 1 1.5 2 1.4 2 1.7 4
Citroen2CV 190 165 1200 fragile 0.9 3 0.85 2 0.95 2 1.1 1
fragile

4
ChevroletExpress 215 255 1200 flamable 2.5 1 2.4 2 2.7 1 2.8 1
ChevroletAstro 210 230 1000 flamable 2 1 1.9 2 1.7 3 2.1 1
DaciaDokker 230 275 1400 flamable 2.2 1 2.3 1 2.4 1 2 1
Citroen2CV 190 165 1200 fragile 0.8 3 0.85 2 0.7 5 0.95 2
flamable

 */

{
    class Program
    {
        static void Main(string[] args)
        {
            int line = 0; // holds info on in which line of user input we are
            int carsNumber = 0; // how many cars we have
            Queue < Car > cars = new Queue<Car>(); // all cars, ordered by adding order

            while (true)
            {
                string input = Console.ReadLine();

                string[] tokens = input.Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);
                // expected input format: <Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType> <Tire1Pressure> <Tire1Age> <Tire2Pressure> <Tire2Age> <Tire3Pressure> <Tire3Age> <Tire4Pressure> <Tire4Age>
                int length = tokens.Length;

                if (length == 13 || length == 1)
                {
                    // ok, we got expected number of tokens - either a line with car, or a number of cars or a directive
                    if (length == 1 && int.TryParse(tokens[0], out carsNumber))
                    {
                        // this line told us number of cars
                    }
                    else if (length == 1)
                    {
                        // this line is a directive line - flammable or fragile - search for those
                        string filterByCargoType = tokens[0];

                        // initialize it empty for storing Where results
                        IEnumerable<Car> carsFiltered = Enumerable.Empty<Car>();

                        if (filterByCargoType.Equals("flamable"))
                        {
                            // find cars with flamable cargo type, and engine power > 250
                            carsFiltered = cars.Where(car => car.Cargo.Type.Equals(filterByCargoType) && car.Engine.Power > 250);
                        }
                        else if (filterByCargoType.Equals("fragile"))
                        {
                            // find cars with fragile cargo type, and any of the tyres pressure < 1
                            carsFiltered = cars.Where(car => car.Cargo.Type.Equals(filterByCargoType) && (car.Tires[0].Pressure < 1 || car.Tires[1].Pressure < 1 || car.Tires[2].Pressure < 1 || car.Tires[3].Pressure < 1));
                        }
                        else
                        {
                            Console.WriteLine("Don't understand - you can only filter cars with \"fragile\" or \"flamable\" cargo");
                        }
                        foreach (Car car in carsFiltered)
                        {
                            Console.WriteLine(car.ToString());
                        }
                    }
                    else
                    {

                        // this is a car definition line - add this car to inventory
                        string model = tokens[0];

                        // engineSpeed
                        bool canConvertToEngineSpeed = int.TryParse(tokens[1], out int engineSpeed);
                        if (!canConvertToEngineSpeed)
                        {
                            Console.WriteLine("Error - can't convert {0} to engine speed", tokens[1]);
                        }

                        // enginePower
                        bool canConvertToEnginePower = int.TryParse(tokens[2], out int enginePower);
                        if (!canConvertToEnginePower)
                        {
                            Console.WriteLine("Error - can't convert {0} to engine power", tokens[2]);
                        }

                        // cargoWeight
                        bool canConvertToCargoWeight = int.TryParse(tokens[3], out int cargoWeight);
                        if (!canConvertToCargoWeight)
                        {
                            Console.WriteLine("Error - can't convert {0} to cargo weight", tokens[3]);
                        }

                        // initialize var before used in conditional
                        string cargoType = "";
                        // cargoType
                        bool filterValid = tokens[4].Equals("flamable") || tokens[4].Equals("fragile");
                        if (filterValid)
                        {
                            cargoType = tokens[4];
                        }

                        // tire1
                        bool canConvertToPressure = double.TryParse(tokens[5].Replace('.',','), out double tire1Pressure);
                        if (!canConvertToPressure)
                        {
                            Console.WriteLine("Error - can't convert {0} to tire pressure", tokens[5]);
                        }
                        bool canConvertToAge = int.TryParse(tokens[6], out int tire1Age);
                        if (!canConvertToAge)
                        {
                            Console.WriteLine("Error - can't convert {0} to tire pressure", tokens[6]);
                        }

                        // tire2
                        canConvertToPressure = double.TryParse(tokens[7].Replace('.', ','), out double tire2Pressure);
                        if (!canConvertToPressure)
                        {
                            Console.WriteLine("Error - can't convert {0} to tire pressure", tokens[7]);
                        }
                        canConvertToAge = int.TryParse(tokens[8], out int tire2Age);
                        if (!canConvertToAge)
                        {
                            Console.WriteLine("Error - can't convert {0} to tire pressure", tokens[8]);
                        }

                        // tire3
                        canConvertToPressure = double.TryParse(tokens[9].Replace('.', ','), out double tire3Pressure);
                        if (!canConvertToPressure)
                        {
                            Console.WriteLine("Error - can't convert {0} to tire pressure", tokens[9]);
                        }
                        canConvertToAge = int.TryParse(tokens[10], out int tire3Age);
                        if (!canConvertToAge)
                        {
                            Console.WriteLine("Error - can't convert {0} to tire pressure", tokens[10]);
                        }

                        // tire4
                        canConvertToPressure = double.TryParse(tokens[11].Replace('.', ','), out double tire4Pressure);
                        if (!canConvertToPressure)
                        {
                            Console.WriteLine("Error - can't convert {0} to tire pressure", tokens[12]);
                        }
                        canConvertToAge = int.TryParse(tokens[12], out int tire4Age);
                        if (!canConvertToAge)
                        {
                            Console.WriteLine("Error - can't convert {0} to tire pressure", tokens[12]);
                        }

                        // add the car
                        cars.Enqueue(new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tire1Pressure, tire1Age, tire2Pressure, tire2Age, tire3Pressure, tire3Age, tire4Pressure, tire4Age));
                    }
                }
                else
                {
                    Console.WriteLine("Error - expected 13 or 1 data field in one line. Found {0}", tokens.Length);
                }
            }
        }
    }
}
