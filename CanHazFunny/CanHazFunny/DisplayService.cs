﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;

public class DisplayService : IDisplayService
{
    public void DisplayToScreen(string joke)
    {
        ArgumentNullException.ThrowIfNull(joke);

        Console.WriteLine(joke);
    }
}
