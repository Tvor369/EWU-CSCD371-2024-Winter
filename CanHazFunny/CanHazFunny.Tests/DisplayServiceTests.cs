using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using System.IO;


namespace CanHazFunny.Tests;

public class DisplayServiceTests
{
    [Fact]
    public void DisplayToScreen_NullJokeString_ThrowsArgumentNull()
    {
        DisplayService displayService = new();
        Assert.Throws<ArgumentNullException>(() => displayService.DisplayToScreen(null!));
    }

    [Fact]
    public void DisplayToScreen_ConsoleDisplaysJoke_Success()
    {
        string joke = "this is a joke";

        DisplayService displayService = new();
        StringWriter stringWriter = new();

        Console.SetOut(stringWriter);
        displayService.DisplayToScreen(joke);

        //StringWriter will add a newline to the end, so I'm using Replace to ignore that.
        Assert.Equal(joke, stringWriter.ToString().Replace("\r\n", string.Empty));
    }
}
