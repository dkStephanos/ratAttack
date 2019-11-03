using System;

namespace RatAttack
{
    class RatAttack
    {
        static void Main(string[] args)
        {
            int[] bombStrengths;                     //Holds the strengths of the bombs per scenario
            int numScenarios;                        //The number of scenarios for this execution
            int numRatPopulations;                   //Temp variable to get number of rat populations from user
            string[] tempData = new string[3];       //Temp array for split populationData 
            Grid[] grids;                            //The grids for each scenario

            //Gets the input from the user
            Console.WriteLine("Input:\n");
            numScenarios = Int32.Parse(Console.ReadLine());

            //Creates Grids and bombStrengths array for each scenario
            grids = new Grid[numScenarios];
            bombStrengths = new int[numScenarios];
            for (int i = 0; i < numScenarios; i++)
            {
                //Gets the next bomb strength from user
                bombStrengths[i] = Int32.Parse(Console.ReadLine());

                //Gets the next rat population count from user, adds next grid with that count
                numRatPopulations = Int32.Parse(Console.ReadLine());
                grids[i] = new Grid(numRatPopulations);

                //Loop through for each population, adding that data to the grid
                for (int j = 0; j < numRatPopulations; j++)
                {
                    tempData = Console.ReadLine().Split(" ");
                    grids[i].ratPopulations[j] = new RatPopulation();
                    grids[i].ratPopulations[j].x = Int32.Parse(tempData[0]);
                    grids[i].ratPopulations[j].y = Int32.Parse(tempData[1]);
                    grids[i].ratPopulations[j].size = Int32.Parse(tempData[2]);
                }
            }

            //Wait for User input to allow viewing of data
            Console.ReadLine();
        }
    }
}
