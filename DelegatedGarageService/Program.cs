using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatedGarageService
{
    class Program
    {
        static void Main(string[] args)
        {
            Garage garage = new Garage();
            Car car = new Car();

            if (true)//The Program can apply conditional logic to add and remove extra services
            {
                //garage.ExtraService += new GarageService(garage.WinterTireService); //stuck to a specific delegate definition
                //garage.ExtraService += new Action<Car>(garage.WinterTireService);   //stuck to a specific delegate definition

                garage.ExtraService += garage.WinterTireService;//not stuck to a specific delegate definition!

                CarglassRepairCompany carglass = new CarglassRepairCompany();
                garage.WindowService += carglass.RepairWindow;

                garage.ExtraService += (c) => { Console.WriteLine($"Anonymous Method Service {c.Manufacturer}"); } ;

                //garage.ExtraService += Console.WriteLine;
            }

            garage.Service(car);


            Console.WriteLine("\nPress <ENTER> to exit..");
            Console.ReadLine();
        }


    }


}
