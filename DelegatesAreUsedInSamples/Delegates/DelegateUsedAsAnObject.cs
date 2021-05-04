using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAreUsedInSamples.Delegates
{
    class DelegateUsedAsAnObject
    {
        //Custom delegate definition can be created with delegate keyword
        delegate void MessageDelegate(string message);

        public void SampleUsingTheDelegate()
        {
            //This is the delegate variable as an object
            MessageDelegate DoMessage = new MessageDelegate(DangerMessage);

            //MessageDelegate DoMessage = DangerMessage;//Same result as line above. It is not needed to use and create a new instance of the MessageDelegate delegate type. (the compiler can resolve and infer the type)

            //Use the delegate object first by adding (subscribing/ assigning) or removing methods
            //All delegates have an invokation list which stores references to methods
            DoMessage += DangerMessage;//adding a method to the delegate invokation list
            DoMessage += HappyMessage;
            DoMessage += new MessageDelegate(HappyMessage);
            DoMessage -= DangerMessage;//removing a method to the delegate invokation list

            //The delegate object is executed
            //All methods in the invokation list are called and the argument "Hey helloo!" is passed in
            DoMessage("Hey helloo!!");

            //In this example the delegate variable declaration and method assignments are in the method for clarity purpose. Usually different objects are used to execute and assign the method. This is to separate the responsibility and extend behavior of an object which is holding the delegate object

            //Remember: The button does not know which code is called when clicked, the form does!
            //Although the buttons does execute 'click-code located inside the button definition (button specific and encapsulated..)' and knows for example when it is clicked, it is the form that extends the button click with extra code thats located inside the form, aka EventHandler.
        }

        private void DangerMessage(string message)
        {
            //Do some danger message actions as an extension..
            Console.WriteLine($"#################{message}################");
        }
        private void HappyMessage(string message)
        {
            //Do some happy message actions as an extension..
            Console.WriteLine($"---------------{message}--------------------");
        }
    }
}
