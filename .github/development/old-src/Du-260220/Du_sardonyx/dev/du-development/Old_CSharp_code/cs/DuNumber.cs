#region HEADER
//   PROJECT: Du
//  FILENAME: DuNumber.cs
//   VERSION: 0.12.0-alpha
//     BUILD: 180227
//   AUTHORS: development@aprettycoolprogram.com
// COPYRIGHT: 2017 A Pretty Cool Program
//   LICENSE: Apache License, Version 2.0 [http://www.apache.org/licenses/LICENSE-2.0]
// MORE INFO: http://aprettycoolprogram.com/Du
#endregion

#region CLASS_DESCRIPTION
// Does things with numbers.
#endregion

using System;
using System.Collections.Generic;
using System.Threading;

namespace Du
{
    public class DuNumber
    {
        /// <summary>Generates a random number.</summary>
        /// <param name="min"> The minimum random number (i.e. "0").</param>
        /// <param name="max"> The maximim random number (i.e. "10")</param>
        /// <returns>A random number.</returns>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static int GenerateSingle(int min, int max)
        {
            return new Random().Next(min, max++); // Redundant increment?
        }

        /// <summary>Generates a List of random numbers.</summary>
        /// <param name="min"> The minimum random number (i.e. "0").</param>
        /// <param name="resultMax"> The maximim random number (i.e. "10")</param>
        /// <returns>A List of random number.</returns>
        /// <remarks>This method will return a list of random numbers. When generating random numbers in quick
        /// succession, it's possible that the generated numbers will not, in fact, be random.In order to avoid this, a
        /// short pause is inserted between each generation.</remarks>
        /// <build>180225</build>
        public static List<int> GenerateList(int quantity, int min, int max)
        {
            var wrkList = new List<int>();

            for (var iteration = 0; iteration < quantity; iteration++)
            {
                Thread.Sleep(15);
                wrkList.Add(new Random().Next(min, max++));
            }

            return wrkList;
        }
    }
}