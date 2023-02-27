/*
 * Group: Shiney Rides
 * Group Members: Chris Seals, Dylan Lynch, Matthew Justis
 */


public class Program
{

    public static void Main(string[] args)
    {
        int input = 0;

        string inputString = Console.ReadLine();  WCK-- This is not what the problem statement asked for. I asked to input 2 numbers and then add them together 
        //Console.WriteLine(inputString);

        input = int.Parse(inputString); WCK -- what happens if this fails?
        //Console.WriteLine(input);
        
        Recursion(input);
    }

    /*
     * Takes an int input from the parameter, then takes the last digit and adds it to the rest of the number.
     * It then calls itself again using the sum to add the last digit again. This continues until the digit is only one digit long.
     */  WCK good comment
    public static void Recursion(int input)
    {
        Console.WriteLine(input);
        if (input > 9)   WCK what if input < 0 as in -23423515
        {

            string stringInput = input.ToString();  WCK nice approach. I wonder if it will work for floats

            string lastDigitString = stringInput.Substring(stringInput.Length - 1);
            string inputWithoutLast = stringInput.Substring(0, stringInput.Length - 1);


            //char[] inputArray = stringInput.ToCharArray();

            int lastDigit = int.Parse(lastDigitString);
            int restOfNum = int.Parse(inputWithoutLast);

            //Console.WriteLine(lastDigit + "\n" + restOfNum);


            int sum = restOfNum + lastDigit;

            //Console.WriteLine(sum);

            Recursion(sum);
        }
        else
        {
            Console.WriteLine($"{input} DONE!");
        }
    }
}
