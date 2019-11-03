using System;
using System.Collections.Generic;
using System.Text;

namespace RatAttack
{
    class Grid
    {
        public int numRatPopulations;                         //Total number of rat populations
        public RatPopulation[] ratPopulations;                      //Holds data on each rat population

        //Constructor that takes number of rat populations to set up the grid data
        public Grid(int numRatPopulations)
        {
            this.numRatPopulations = numRatPopulations;
            ratPopulations = new RatPopulation[numRatPopulations];
        }
    }
}
