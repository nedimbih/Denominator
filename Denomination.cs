using static System.Console;

namespace Denominator
{
	class Denomination
    {
        // this array holds all off the BAM denominations, expressed in fenings (1BAM = 100 fening), to simplify division operations
        static readonly int[] Denominations = { 5, 10, 20, 50, 100, 200, 500, 1000, 2000, 5000, 10000, 20000 };
        
        int amount;     // user's entry

        // this array will hold number of repetitions for certain denominations in a given amount 
        // for example, in entry of 55,00BAM, 20BAM denomination can be contained once, twice or none
        // since 20BAM denomination has index 8 (in Denominations array), the element repetition[8] can hold values 0, 1 or 2
        int[] repetitions;         
         
        public Denomination(int amount)
        {
            repetitions = new int[Denominations.Length];
            this.amount = amount;
        }

        internal void Analyze()
        // this program could have been made without this method
        // however this makes code in Main cleaner 
        {
            Analyze(amount, Denominations.Length - 1);
        }

        void Analyze(int amount, int index)  
        {
            int maxDenomination = FindMaxDenomination(amount, index);
            int maxTimes = FindMaxRepetition(amount, maxDenomination);

            for (int usedTimes = maxTimes; usedTimes >-1; usedTimes--)
            {
                repetitions[maxDenomination] = usedTimes;
                int remainder = amount - usedTimes * Denominations[maxDenomination];
                if (remainder == 0)
                    PrintCombination();
                else
                    if (maxDenomination > 0)
                        Analyze(remainder, maxDenomination - 1);
            }
        }

        // returns number of max repetitions of a certain denomination in a given amount
        static int FindMaxRepetition(int value, int index)
        {
            return value / Denominations[index];
        }

        // returns the index number (in Denominations array) at which the biggest possible denomination for a given amount is found
        // for example, for amount of 15,00BAM biggest denomination is 10BAM, so method returns index of 10BAM in Denominations array, in this example it is 7
        // this omits check for denomination bigger then the given amount
        static int FindMaxDenomination(int value, int index)
        {
            for (int i = index; i > -1; i--)
                if (value >= Denominations[i])
                    return i;
            return 0;
        }

        void PrintCombination()
        {
            bool somethingWritten = false;
            for (int i = Denominations.Length - 1; i > -1; i--)
                if (repetitions[i] > 0)
                {
                    if (somethingWritten)
                        Write(" + ");
                    Write($"{repetitions[i]} * {Denominations[i] / 100f:c} ");
                    somethingWritten = true;
                }
			WriteLine();
        }
    }
}