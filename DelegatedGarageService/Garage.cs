using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatedGarageService
{
    //Delegate definition, signature of the method (return type and parameters), communication contract between objects (in this case: the Garage and the Program)
    delegate void GarageService(Car car);

    class Garage
    {
        public void Service(Car car) 
        {            
            //Some services need to be done explicitly and in order choosen by the garage
            Console.WriteLine("servicing tire pressure..");
            Console.WriteLine("servicing oil..");


            //Some services can be done 'indirectly or forwarded to external parties' but still in order choosen by the garage
            //Performing Extra Service, but which? The garage does not need to control that
            //if (ExtraService != null)
            //{
            //    ExtraService(car);
            //}
            //Line below ias same as if-statement above, just a null check
            ExtraService?.Invoke(car);

            Console.WriteLine("cleaning interior");

            //A window servicing company could actually travel in real life to the garage and perform services on site
            WindowService?.Invoke(car);

            //As an ending service: the car needs to be washed
            Console.WriteLine("washing car");
        }

        public void WinterTireService(Car car) 
        {
            Console.WriteLine("change winter tires");
        }

        public GarageService ExtraService;
        //Besides a custom delegate GarageService in the above commented code, you could use the predifined System.Action delegate below with same result
 
        //public Action<Car> ExtraService;

        public event Action<Car> WindowService; 
        //Adding the event keyword adds encapsulation, code external to the class cannot use the '=' operator anymore (only '+=' and '-=') are allowed. This prevents a possible 'overwrite' of the invokation list enabling the class that holds the delegate object to be in control. Inside the class '=' is allowed to assign methods to the invokation list of the delagate!

        //People often ask when should you use a custom delegate definition or use the existing ones like Action, Func and Predicate.
        // - A custom delegate definition adds to readability: the name of the delegate and parameters can have a specific name, the predefined System delegates do not allow that
        // - A custom delegate can set more specific base types for the parameters to start extending from. Just like EventHandler<TEventArgs> does. The Action, Func and Predicate allow any type to be used as a parameter
        //Advantages for the the Action, Func and Predicate are that they have a simple and easy to recognize signature: All Action delegates will not return anything (return type is void). All Func delegates will return something. A predicate delegate will always return a bool. The parameters do also not enforce any base type requirements for the parameters, they are generic from the start
    }
}
