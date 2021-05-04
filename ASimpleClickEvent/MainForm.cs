using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASimpleClickEvent
{
    //Events are easy??

    //A form has a button 
    //A button has a click event
    //The form has a code in a method
    //The form connects the method to the event
    //When a user clicks the button the method will be called

    //An important principle above is that the method gets connected at one time and that it will be called at another time.
    //This method called by the button is a so called 'eventhandler' and the connecting done by the form is called 'subscibing'
    //The button publishes a click event and the form can subscribe to that event with an method handling that event
    //It's like the form tells the button: if you are clicked please call this method i'm offering

    //When you doubleclick a button in the form designer, the designer will automatically create the eventhandler and subscribes the eventhandler to the buttons click event member.
    //Visual Studio will activate the window with the forms code behind file, and position to line where the eventhandler was created
    //The eventhandler is named starting with the name of the button, underscore and eventname

    //If you go to the designer of the form. You can see the name of the eventhandler in the Properties panel when you switch the display with the lightning filter symbol to show the events in the Properties panel
    public partial class MainForm : Form
    {
        public MainForm()
        {
            //You can also see the event subscription when you go to the definition of this InitializeComponent method (right click and select 'Go To Definition' or use 'F12')
            InitializeComponent();

            //This next code line will add another eventhandler to the click event, code like this is also located inside the InitializeComponent method
            //Clicking the button will now call the SayHelloButton_Click twice, so the message 'Hello' will also be displayed twice
            SayHelloButton.Click += new EventHandler(SayHelloButton_Click);
            //The form subscribes to the click event with += operator

        }

        private void SayHelloButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello!");
        }


        //Event Publisher and Event Subscriber or Event Source and Event Sink?
        //Both can be used to describe use of events, lately Microsoft preferres the 'publisher and subscriber'
        //The button is called 'event source', the eventhandler is called 'event sink'

        //'event source'
        //The button initiates and is the source of the event. This is the object that contains and raises the is also called 'event publisher'.

        //'event sink'
        //the eventhandler 'handles' the event and runs the code the moment the button is clicked. The object containing the eventhandler is called the 'event subscriber'


        //Remarks:

        //Events enable objects (the form and the button) to work together. The form extends the buttons behavior and adds callable code to the workings of the button. This way resposibility is separated too: the button knows when a specific state or condition is met and communicates by triggering the click as an event. The form decides whether to subscribe and what to do in addition to to the buttons click event.
        //The button has many 'empty' events. The form does not need to use all the events that a button has events.
        //An event can contain and call multiple methods, multiple eventhandlers can be subscribed to one event
        //An eventhandler can even be added to an event during a running application, an eventhandler can be added to an event of an loaded object in runtime
        //An Event is of type delegate, the delegate type specifies the method or communication signature (params and return type) and the delegate object instance can hold multiple references to methods. A multicast delegate has an method InvokationList as an container for methods to be called when the delegate is executed.
    }
}
