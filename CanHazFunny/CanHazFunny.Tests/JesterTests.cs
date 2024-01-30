using System;
using Xunit;
using Moq;
using System.Collections;
using System.Collections.Generic;

namespace CanHazFunny.Tests;

public class JesterTests
{
    //Method_Condition_Pass/Fail()

    [Fact]
    public void TellJoke_NullJokeService_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => new Jester(null!, new DisplayService()));
    }

    [Fact]
    public void TellJoke_NullDisplayService_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => new Jester(new JokeService(), null!));
    }

    [Fact]
    public void TellJoke_SetJokeService_Success()
    {
        JokeService jokeService = new();
        Jester jester = new(jokeService, new DisplayService());
        Assert.Equal<IJokeService>(jokeService, jester.JokeService);
    }

    [Fact]
    public void TellJoke_SetDisplayService_Success()
    {
        DisplayService displayService = new();
        Jester jester = new(new JokeService(), displayService);
        Assert.Equal<IDisplayService>(displayService, jester.DisplayService);
    }

    //Test for Chuck Norris cases...
    [Fact]
    public void TellJoke_SkipChuckNorrisJoke_Success()
    {
        string joke1 = "Chuck Norris";
        string joke2 = "new joke";

        Queue<string> jokeQueue = new();
        jokeQueue.Enqueue(joke1);
        jokeQueue.Enqueue(joke2);


        var mockJokeService = new Mock<IJokeService>();
        var mockDisplayService = new Mock<IDisplayService>();

        mockJokeService.Setup(jokes => jokes.GetJoke()).Returns(jokeQueue.Dequeue);

        Jester jester = new(mockJokeService.Object, mockDisplayService.Object);

        jester.TellJoke();

        mockDisplayService.Verify(display => display.DisplayToScreen(joke2));
    }

    [Fact]
    public void TellJoke_TellNonChuckNorrisJoke_Success()
    {

        string joke1 = "this joke is fine to tell";
        string joke2 = "why did you skip the joke before?";

        Queue<string> jokeQueue = new();
        jokeQueue.Enqueue(joke1);
        jokeQueue.Enqueue(joke2);

        var mockJokeService = new Mock<IJokeService>();
        var mockDisplayService = new Mock<IDisplayService>();

        mockJokeService.Setup(jokes => jokes.GetJoke()).Returns(jokeQueue.Dequeue);

        Jester jester = new(mockJokeService.Object, mockDisplayService.Object);

        jester.TellJoke();

        mockDisplayService.Verify(display => display.DisplayToScreen(joke1));
    }
}
