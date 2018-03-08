// This program has been coded only to show/verify algorithm
// It has been coded for happy case scenario and it could be further improved with entry checks, cleaner code etc. which have been omitted due to the fact that that is not relevant (for showing algorithmic solution)

// Note that calculations for amounts bigger than 5,00BAM may take a while to finish.
// In such a case, program may seem as it have entered an endless loop, although it is working fine 

using System;
using static System.Console;

namespace Denominator
{
	class Program
    {
        static int userInput,correctedInput;
        static void Main()
        {
            bool again = true;
            do
            {
                ObtainEntry();
                var entry = new Denomination(correctedInput);

                WriteLine($"\nYour entry in amount of {userInput / 100f:c} has been rounded to amount of {correctedInput / 100f:C}. \nThat amount can be achieved in following combinations:\n");

                entry.Analyze();

                WriteLine($"\nYour entry in amount of {userInput / 100f:c} has been rounded to amount of {correctedInput / 100f:C}. \nAll the possible combination have been listed above!");
                WriteLine("\n\nWould you like to analyze another amount?\nPress y for new analysis, or any other key to quit!");

                if (ReadLine() != "y") again = false;
            } while (again);
        }

        private static void ObtainEntry()
        {
            Write("\nPlease enter the amount: ");

            // Entry is multiplied with 100 so it can be expressed in fenings (1BAM=100fening), same as Denominations array 
            userInput = (int)(Single.Parse(ReadLine()) * 100);
            // Entry is rounded to value divisible by 5 (the smallest denomination)
            correctedInput = CorrectEntry(ref userInput);
        }

        private static int CorrectEntry(ref int startingValue)
        {
            int remainder = startingValue % 5;
            return remainder < 3 ? (startingValue - remainder) : (startingValue - remainder + 5);
        }
    }
}