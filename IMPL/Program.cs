/*
 * Group: Shiney Rides
 * Group Members: Chris Seals, Dylan Lynch, Matthew Justis
 * 
 * UPDATE: This was updated by Chris Seals after receiving the feedback from github, 
 *         the feedback given is on the commented lines that start with WCK.
 *         For every comment that had something to fix, I put a new line
 *         below it that says "FIX - #fix here#", #fix here# is how I fixed the problem.
 *         FIX2 means that they were fixes from the second round of comments.
 *         FIX3 means that they were fixes from the third round of comments.
 */



public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("This application takes two numbers, adds them, " +
            "then takes the last digit and adds it to the rest of the number again and again until the number is only one digit long. " +
            "When the number is one digit long, it will be displayed and the application will exit.\n\n" +
            "*Please note if you use decimals or numbers past 1.0E+300, the additions might have precision errors.*\n\n\n");

        /*
         *  WCK2 - it would be better coding practice to set the input logic into a method and call it twice instead of copying and pasting(duplicating) the code.
         *  Duplicated code is harder to maintain.An error in logic might be fixed in one instance of the code but overlooked in other instances especially if they
         *  are not co - located.
         *  FIX2 - I created a method at the end of this file that has the input logic. It returns a double that is validated in the method from the user. I also
         *         wanted the user to know if they were entering the first number or second for the input logic, 
         *         so I included a string to be a parameter for the UserInput() method.
         */
        double input1 = UserInput("Please enter your first number: ");
        double input2 = UserInput("Please enter your second number: ");

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
        /*
         * WCK2 - what if the sum exceeds double's maxValue?
         * FIX2 - This is in reference to when input1 and input2 are added below.
         *        I tested to see what would happen in this scenario. To test this, I passed in two variables that were double.MaxValue, 
         *        and the system displayed the infinity symbol, so that is interesting.
         *        I researched more about this, and according to the Microsoft documentation, the positive infinity constant is returned
         *        when an operation is greater than the double.MaxValue: https://learn.microsoft.com/en-us/dotnet/api/system.double.positiveinfinity?redirectedfrom=MSDN&view=net-7.0.
         *        I decided to print a line saying the maxvalue was passed and have an error message. I'm not sure what the best approach here is so I am open to suggestions.
         */
        /*
         * WCK3 - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/checked-and-unchecked ;
         *        you can define the behavior to just put out a message saying the two numbers were too large to sum
         *        so you show the maxDouble value as the sum you will use, they can try again with different numbers
         *        if they choose too(on a different run)
         * FIX3 - Like you suggested, I manually set the double.MaxValue if it overflows to double.PositiveInfinity
         *        from the addition. I couldn't use checked statements here since they are for integer operations.
         */
        double sum = input1 + input2;

        if (double.IsPositiveInfinity(sum))
        {
            Console.WriteLine("\nThe numbers were too large to sum, so the max value of type double will be used as the sum");
            sum = double.MaxValue;
        }

        Console.WriteLine($"{input1} + {input2} = {sum}\n");



        /*
        * WCK nice approach. I wonder if it will work for floats
        * FIX - The previous implementation would not work with floats, this one does, it now also works with negatives as well.
        */

        /*
         * WCK3 - so, if you had spent more time designing before coding the first time, do you think you could have come up with this ?
         * FIX3 - Yes I believe we could've come up with this instead. We wouldn't have had time to implement it during class but I think
         *        we could have come up with a design for it if we spent more time on it. It is also harder to decide on a single way to
         *        approach something in a team setting sometimes, so it took us longer to decide.
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

    /*
     * This method will tell the user to input a number, the input is vaildated and will keep asking
     * the user to input a new number repeatedly until valid input is recieved.
     * 
     * This method has a string parameter called prompt, this string will be displayed for when the user has to input a number.
     * This method will return a non-null double that is the user's inputted number.
     */
    public static double UserInput(string prompt)
        {
            bool loop = true;
            string? inputString = "";
            double output = 0;

            //loop for user input, will keep going until the user inputs the correct format, a number
            do
            {
                Console.WriteLine(prompt);

                inputString = Console.ReadLine();
                //Console.WriteLine(inputString);

                /*
                * WCK-- what if input < 0 as in -23423515
                * FIX - If input is out of the range of a double, it will not parse, resulting in false for the if statement.
                *       If it does parse, the new double will be assigned to input1
                */
                if (double.TryParse(inputString, out double value))
                {
                    /*
                    * WCK-- what happens if this fails?
                    * FIX - This was in reference to when we tried to parse the string to an int,
                    *       this was fixed by using the tryparse method, as it returns false if it cannot parse the string.
                    *       It will not parse if user enters nothing, enters letters, or characters other than digits.
                    *       It also works with negative numbers and decimals.
                    */
                    //Console.WriteLine(value1);
                    output = value;
                    /* WCK2 - It would be better practice to set loop to false inside the if statement after you set the input1 value instead of using continue
                     *        to jump back to the start. 
                     * FIX2 - I implemented this change here, I also removed the continue in the else block below this.
                     */
                    loop = false;
                }
                else
                {
                    //Restarts loop if invalid input is received
                    Console.WriteLine("Please enter a valid number. Valid numbers are positive or negative integers or decimals.\n");
                }
            } while (loop);

            //output is set to 0 when initialized, so no null value will be passed, also user input is validated from the if statement above, so a value will be assigned.
            return output;
        }//UserInput()
    }//Program{}
