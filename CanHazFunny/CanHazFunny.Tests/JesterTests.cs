using System;
using Xunit;

namespace CanHazFunny.Tests;

public class JesterTests
{
    //Method_Condition_Pass/Fail()

    [Fact]
    public void TellJoke_NullJokeService_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => new Jester(null!, new OutputJoke()));
    }

    [Fact]
    public void TellJoke_NullOutputJoke_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => new Jester(new JokeService(), null!));
    }

    [Fact]
    public void TellJoke_SetJokeService_Success()
    {
        JokeService jokeService = new();
        Jester jester = new(jokeService, new OutputJoke());
        Assert.Equal<JokeService>(jokeService, jester.JokeService);
    }

    [Fact]
    public void TellJoke_SetOutputJoke_Success()
    {
        OutputJoke outputJoke = new();
        Jester jester = new(new JokeService(), outputJoke);
        Assert.Equal<OutputJoke>(outputJoke, jester.OutputJoke);
    }

    //Test for Chuck Noris cases...
}
