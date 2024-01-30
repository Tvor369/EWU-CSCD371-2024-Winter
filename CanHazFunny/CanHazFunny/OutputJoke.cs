using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class OutputJoke : IOutputJokeToScreen
    {
        public void DisplayToScreen(string joke)
        {
            Console.WriteLine(joke);
        }
    }
}
