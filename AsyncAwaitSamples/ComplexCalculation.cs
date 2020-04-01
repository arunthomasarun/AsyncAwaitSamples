using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitSamples
{
    public class ComplexCalculation
    {

        public int DoComplexCalculation()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            while(true)
            {
                if(watch.ElapsedMilliseconds > 5000)
                {
                    break;
                }
            }

            return 10;
        }
    }
}
