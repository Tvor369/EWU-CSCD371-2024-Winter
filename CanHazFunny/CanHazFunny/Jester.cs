using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class Jester
    {
        public JokeService JokeService {  get; set; }

        public OutputJoke OutputJoke { get; set; }

        public Jester(JokeService JokeService, OutputJoke OutputJoke) 
        {
            ArgumentNullException.ThrowIfNull(JokeService);
            ArgumentNullException.ThrowIfNull(OutputJoke);

            this.JokeService = JokeService;
            this.OutputJoke = OutputJoke;
            
        }

        public void TellJoke()
        {
            string joke;
            do //If the joke contains "Chuck Norris", skip it and get another.
            {
                joke = JokeService.GetJoke();
            } while (joke.Contains("Chuck Norris"));

            OutputJoke.DisplayToScreen(joke);
        }
        
    }
}
