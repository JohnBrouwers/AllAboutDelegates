using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAreUsedInSamples.Delegates
{
    //When you create and define an object with events, you can use the predifined System.EventHandler<TEventArgs> which is based on a delegate with two parameters: 'object sender' and 'EventArgs e'
    //The object parameter is used to pass in the object itself that published or initiated and triggers the event.
    //The EventArgs parameter is used to pass in any event specific data. In a mouse click it could be the location x and y of the cursor when clicking.

    //Use the EventArgs class to derive from and create a more specialized type with extra properties. Pass this type in as the Generic type for the event member
    class SampleObject
    {
        //This event 'ObjectSpecificEvent' uses 'EventHandler' as the delegate type with 'SpecificEventArgs' as the generic type argument
        public event EventHandler<SpecificEventArgs> ObjectSpecificEvent;

        public void DoSomethingThatMightTriggerEvent()
        {
            //This method would be responsible for triggering the event

            var specificEventArgs = new SpecificEventArgs() { SpecificEventParameterProperty="SpecificEventArgumentValue" };
            ObjectSpecificEvent?.Invoke(this, specificEventArgs);
        }
    }

    //An advantage of the EventArgs class is that it is a default base to inherit from and extend to
    //This is the class that holds the event specific information, the parameter specific values aka arguments. These are the arguments
    public class SpecificEventArgs: EventArgs
    {
        public string SpecificEventParameterProperty { get; set; }
    }
}
