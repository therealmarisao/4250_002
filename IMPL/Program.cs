/*
 * Group: Shiney Rides
 * Group Members: Chris Seals, Dylan Lynch, Matthew Justis
 * 
 * UPDATE: This was updated by Chris Seals after receiving the feedback from github, 
 *         the feedback given is on the commented lines that start with WCK.
 *         For every comment that had something to fix, I put a new line
 *         below it that says "FIX - #fix here#", #fix here# is how I fixed the problem.
 */



public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("This application takes two numbers, adds them, " +
            "then takes the last digit and adds it to the rest of the number again and again until the number is only one digit long. " +
            "When the number is one digit long, it will be displayed and the application will exit.\n\n" +
            "*Please note if you use decimals, the additions might have precision errors.*\n\n\n");

        bool loop = true;
        double input1 = 0;
        double input2 = 0;
        string? inputString = null;
        
        /*
        * WCK-- This is not what the problem statement asked for. I asked to input 2 numbers and then add them together
        * FIX - I changed the solution to take two numbers from the user
        */

        //loop for user input, will keep going until the user inputs the correct format, a number
        do
        {
            Console.WriteLine("Please enter your first number: ");

            inputString = Console.ReadLine();
            //Console.WriteLine(inputString);

            /*
            * WCK-- what if input < 0 as in -23423515
            * FIX - If input is out of the range of a double, it will not parse, resulting in false for the if statement.
            *       If it does parse, the new double will be assigned to input1
            */
            if (double.TryParse(inputString, out double value1))
            {
                /*
                * WCK-- what happens if this fails?
                * FIX - This was in reference to when we tried to parse the string to an int,
                *       this was fixed by using the tryparse method, as it returns false if it cannot parse the string.
                *       It will not parse if user enters nothing, enters letters, or characters other than digits.
                *       It also works with negative numbers and decimals.
                */
                //Console.WriteLine(value1);
                input1 = value1;
            }
            else
            {
                //Restarts loop if invalid input is received
                Console.WriteLine("Please enter a valid number. Valid numbers are positive or negative integers or decimals.\n");
                continue;
            }

            //stops loop if no invalid input was received.
            WCK2 - It would be better practice to set loop to false inside the if statement after you set the input1 value instead of using continue
                to jump back to the start. 
            loop = false;

        } while (loop);

        loop = true;

        /*
        * Another loop for the second input, I did it this way instead of one big do loop so if the user inputted a wrong number for the second number,
        * it wouldn't start at the beginning of the do loop, meaning they would have to enter their first number again.
        */
        WCK2 - it would be better coding practice to set the input logic into a method and call it twice instead of copying and pasting (duplicating) the code.
            Duplicated code is harder to maintain. An error in logic might be fixed in one instance of the code but overlooked in other instances especially if they 
                are not co-located. 
        do
        {
            Console.WriteLine("\nPlease enter your second number: ");

            inputString = Console.ReadLine();
            //Console.WriteLine(inputString);

            //Same implemenation as first if statement with TryParse.
            if (double.TryParse(inputString, out double value2))
            {
                //Console.WriteLine(value2);
                input2 = value2;
            }
            else
            {
                //Restarts loop if invalid input is received
                Console.WriteLine("Please enter a valid number. Valid numbers are positive or negative integers or decimals\n");
                continue;
            }

            // Stops loop if no invalid input was received
            loop = false;

        } while (loop);

        Console.WriteLine("\nCalculating...\n");
        Recursion(input1, input2);
        Console.WriteLine("\nDone.");
    }//Main()

    /*
     * Takes two double parameters, then adds them together.
     * If the sum is greater than one digit long, then it will call itself again resursively until the sum is only one digit long.
     * A number also counts as more than one digit in length if there are decimals. Example: '1.2' counts as two digits.
     * 
     * Note: The parameters cannot be null in C# since they are not "double?" types.
     */
    //WCK good comment
    public static void Recursion(double input1, double input2)
    {
        double sum = input1 + input2;  WCK2 - what if the sum exceeds double's maxValue?

        Console.WriteLine($"{input1} + {input2} = {sum}\n");

        /*
        * WCK nice approach. I wonder if it will work for floats
        * FIX - The previous implementation would not work with floats, this one does, it now also works with negatives as well.
        */
        string sumString = sum.ToString();
        //This if statement is in case the sum is so large it is in scientific format, if it is, the string will be converted to regular format for substring methods below
        if (sum.ToString().Contains('E'))
        {
            sumString = sum.ToString("F0");
        }
        //Console.WriteLine(sumString);

        /*
        * This if statement will check if the sum is greater than one digit in length. It is prepared to deal with negative numbers as well.
        * A number also counts as more than one digit in length if there are decimals. Example: '1.2' would count as two digits
        */
        if ((double.IsNegative(sum) && sumString.Length > 2) || (!double.IsNegative(sum) && sumString.Length > 1))
        {
            string lastDigitString = sumString.Substring(sumString.Length - 1);
            string restOfNumString = sumString.Substring(0, sumString.Length - 1);

            //This if statement will see if the substrings can parse to doubles, then call the method again recursively.
            if (double.TryParse(lastDigitString, out double lastdigit) && double.TryParse(restOfNumString, out double restOfNum))
            {
                Recursion(restOfNum, lastdigit);
            }
            else
            {
                //This shouldn't happen, as the parameters were validated before being passed in, but just in case, this is here. WCK2 - good idea
                throw new FormatException("Could not convert substrings to type double in Recursive method.");
            }
        }
        else
        {
            //This will displayed at the final recursion call.
            Console.WriteLine($"Final Number: {sum}");
        }
    }//Recursion()
}//Program{}
