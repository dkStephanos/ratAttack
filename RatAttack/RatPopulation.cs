using System;
using System.Collections.Generic;
using System.Text;

namespace RatAttack
{
    class RatPopulation : IComparable<RatPopulation>
    {
        public int x,                      //X coordinate of population
                   y,                      //Y coordinate of population
                   size;                   //Size of population

        //Custom CompareTo method for the IComparable implementation
        //Uses x coordinate then y coordinate to determine order
        public int CompareTo(RatPopulation ratPopulation)
        {
            if(this.x - ratPopulation.x != 0)
            {
                return this.x - ratPopulation.x;
            } else
            {
                return this.y - ratPopulation.y;
            }
        }
    }
}
