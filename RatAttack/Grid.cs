using System;
using System.Collections.Generic;
using System.Text;

namespace RatAttack
{
    class Grid
    {
        int numRatPopulations;                         //Total number of rat populations
        int[,] ratPopulationData;                      //Holds data on each rat population

        //Constructor that takes number of rat populations to set up the grid data
        public Grid(int numRatPopulations)
        {
            this.numRatPopulations = numRatPopulations;
            ratPopulationData = new int[numRatPopulations, 3];
        }
    }
}
