using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAreUsedInSamples.Delegates
{
    class DelegatesUsedInTasks
    {
        public void RunSampleTasks()
        {
            //This Run method uses the Action delegate
            Task.Run(() => {
                //Running 'background' code..
            });


            //This Run method uses the Func<string> delegate
            var t = Task<string>.Run(() =>
            {
                return "Running 'background' code.";
            });

            //This invoke method uses an array of Action delegates
            Parallel.Invoke(()=> { }, ()=> { });
        }
    }
}
