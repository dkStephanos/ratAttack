using System;
using System.Collections.Generic;
using System.Text;

namespace RatAttack
{
    class Grid
    {
        public int[,] grid = new int[1025, 1025];                   //Represents locations in possible grid range
        public int numRatPopulations;                               //Total number of rat populations
        public RatPopulation[] ratPopulations;                      //Holds data on each rat population
        public int bombStrength;                                    //Holds the strength of the bomb
        string bombLocal;                                           //Contains coordinates for bomb and expected kill count

        //Constructor that takes number of rat populations to set up the grid data
        public Grid(int numRatPopulations, int bombStrength)
        {
            this.numRatPopulations = numRatPopulations;
            ratPopulations = new RatPopulation[numRatPopulations];
            this.bombStrength = bombStrength;
            this.bombLocal = "Not yet found.";
        }

        //Finds ideal bomb location
        public string plantBomb()
        {
            int currentX,                       //X coordinate for current nest search area
                currentY,                       //Y coordinate for current nest search area
                currentMaxKills,                //Holds the max kills for coordinate currently being tested
                maxX,                           //X coordinate for current highest kill count bomb local
                maxY,                           //Y coordinate for current highest kill count bomb local
                maxKillCount;                   //Current highest kill count found

            //Set the starting max assuming only first nest is covered by ideal bomb placement
            //Bomb can be at most (x - bombStrength, y - bombStrength)
            maxX = 0;
            maxY = 0;
            if (0 < ratPopulations[0].x - bombStrength)
            {
                maxX = ratPopulations[0].x - bombStrength;
            }
            if (0 < ratPopulations[0].y - bombStrength)
            {
                maxY = ratPopulations[0].y - bombStrength;
            }
            maxKillCount = ratPopulations[0].size;
            currentMaxKills = 0;

            //Loop through each rat population searching for overlaps
            for (int i = 0; i < numRatPopulations; i++)
            {
                //Sets current coordinates to bottom of range of possible bomb locals
                currentX = 0;
                currentY = 0;
                if (0 < ratPopulations[i].x - bombStrength)
                {
                    currentX = ratPopulations[i].x - bombStrength;
                }
                if (0 < ratPopulations[i].y - bombStrength)
                {
                    currentY = ratPopulations[i].y - bombStrength;
                }


                //Loop through radius of nest and test for nests that can be reached with bomb
                //Start by scanning through the x range, then the y
                for (int j = currentY; j <= currentY + bombStrength*2; j++)
                {
                    for (int k = currentX; k <= currentX + bombStrength*2; k++)
                    {
                        //Check to make sure location is on grid
                        if (k < 1025 && k >= 0 && j < 1025 && j >= 0)
                        {
                            //If we've scanned here already, skip this
                            if (grid[k, j] != 1)
                            {
                                //First, mark that we've been here before
                                grid[k, j] = 1;
                                //If we haven't loop through the rat populations to search for overlaps
                                for (int l = 0; l < numRatPopulations; l++)
                                {
                                    //If we find a nest in range, add its size to the currentMaxKills for this location
                                    if (Math.Max(Math.Abs(ratPopulations[l].x - k), Math.Abs(ratPopulations[l].y - j)) <= bombStrength)
                                    {
                                        currentMaxKills += ratPopulations[l].size;
                                    }
                                }
                                //If the currentMaxKilss is higher than what we have so far, update the maxKillCount, maxX and maxY
                                if (currentMaxKills > maxKillCount)
                                {
                                    maxX = k;
                                    maxY = j;
                                    maxKillCount = currentMaxKills;

                                }
                                else if (currentMaxKills == maxKillCount)
                                {
                                    //Also check to make sure, if the counts are equal, we keep the earlier location
                                    if (maxX >= k)
                                    {
                                        if (maxY >= j)
                                        {
                                            maxX = k;
                                            maxY = j;
                                        }
                                    }
                                }
                                //Regardless, reset currentMaxKills
                                currentMaxKills = 0;
                            }
                        }
                    }
                }
            }

            //Constructs and returns the bombLocal data as a string for ouptput
            bombLocal = $"{maxX} {maxY} {maxKillCount}";
            return bombLocal;
        }
    }
}
