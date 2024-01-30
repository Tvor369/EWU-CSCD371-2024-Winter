using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class Jester
    {

        public IJokeService JokeService {  get; set; }

        public IDisplayService DisplayService { get; set; }

        public Jester(IJokeService JokeService, IDisplayService DisplayService) 
        {
            ArgumentNullException.ThrowIfNull(JokeService);
            ArgumentNullException.ThrowIfNull(DisplayService);

            this.JokeService = JokeService;
            this.DisplayService = DisplayService;
            
        }

        public void TellJoke()
        {
            string joke;
            do //If the joke contains "Chuck Norris", skip it and get another.
            {
                joke = JokeService.GetJoke();
            } while (joke.Contains("Chuck Norris"));

            DisplayService.DisplayToScreen(joke);
        }
        
    }
}
