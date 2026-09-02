/* A class for AO.cs that does various things with numbers.
 * v00.52.03.161012
 * http://aprettycoolprogram.com/ao
 */

using System;
using System.Threading;

namespace AO
{
    public class AONumber
    {
        /* Rolls a dice a specific number of times.
         * This returns all of the rolls in an array.
         *
         * ---
         * numberOfSides - the number of sides the dice has
         * numberOfRolls - the number of rolls to make                                                                */
        public static int[] DiceRoll(int numberOfSides, int numberOfRolls)
        {
            int[] results = new int[numberOfRolls];

            /* For each of the rolls, generate a number that's between 1 and the number of sides the die has, then add
             * the result to the array that contains the roll values.                                                 */
            for (int rollNumber = 0; rollNumber < numberOfRolls; rollNumber++)
            {
                results[rollNumber] = GenerateRandom(1, numberOfSides, false);
            }

            return results;
        }

        /* Generate a random number.
         * If you call this methid in rapid succession, it's possible that the same "random" number will be generated.
         * In these situations, you can force a small 15ms pause that will ensure that all random numbers are unique. */
        public static int GenerateRandom(int lowEnd, int highEnd, bool pause)
        {
            if (pause)
            {
                AOSystem.Pause(15);
            }

            Random rng = new Random();

            return rng.Next(lowEnd, highEnd++);
        }
    }
}