// ---------------------------------------------------------------------------------------------------------------------
// Name: DoNumber.cs
// Version: 00.90.01.160731
// Author: Christopher Banwarth (development@aprettycoolprogram.com)
// Description: A class for AO that does various things with numbers.
// More: ao.aprettycoolprogram.com OR aprettycoolprogram.github.com
// ---------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading;

namespace AO
{
    public class DoNumber
    {
        /// <summary>Rolls a dice a specific number of times.</summary>
        /// <param name="numSides">The number of sides the die has.</param>
        /// <param name="numRolls">The number of rolls to make.</param>
        /// <returns>An array with the value of each roll.</returns>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static int[] DiceRoll(int numSides, int numRolls)
        {
            int[] rollStorage = new int[numRolls];
            for (int currentRoll = 0; currentRoll < numRolls; currentRoll++)
            {
                rollStorage[currentRoll] = Random(1, numSides, false);
            }

            return rollStorage;
        }

        /// <summary>???</summary>
        /// <param name="potentialValues"></param>
        /// <param name="weights"></param>
        /// <returns></returns>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static int HighValue(int[] potentialValues, int[] weights)
        {
            var test = 0;
            var val = 0;

            test = Random(1, 100, false);

            //foreach (var item in weights)
            //{
            //  if (test <= item)
            //  {
            //    val = potentialValues[Array.IndexOf(weights, item)];
            //  }

            //}

            return val;
        }

        /// <summary>Generates a random number.</summary>
        /// <param name="low">Low boundry.</param>
        /// <param name="high">High boundry.</param>
        /// <returns>A random number.</returns>
        /// <remarks>
        /// In the event that you get the same "random" number, which can happen if this function is called in rapid
        /// succession, pass "true" for the "pause" boolean, and a short pause will be inserted when creating a seed.
        /// </remarks>
        /// <build>160713</build>
        public static int Random(int low, int high, bool pause)
        {
            if (pause)
            {
                Thread.Sleep(15);
            }

            Random rng = new Random();
            high++;

            return rng.Next(low, high);
        }
    }
}

// CHANGELOG
// =========
// 00.90.00.160717: Initial release
// 00.90.01.160731: Code and comment cleanup

// ROADMAP
// =======
// * Proper error handling

// NOTES
// =====