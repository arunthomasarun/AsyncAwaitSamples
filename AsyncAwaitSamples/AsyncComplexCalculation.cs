using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitSamples
{
    public class AsyncComplexCalculation
    {

        public async Task<int> DoComplexCalculationAsync()
        {
            await Task.Delay(2000);            
            return 10;
        }

    }
}
