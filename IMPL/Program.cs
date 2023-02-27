/*
 * Group: Shiney Rides
 * Group Members: Chris Seals, Dylan Lynch, Matthew Justis
 */


public class Program
{

    public static void Main(string[] args)
    {
        int input = 0;

        string inputString = Console.ReadLine();
        //Console.WriteLine(inputString);

        input = int.Parse(inputString);
        //Console.WriteLine(input);
        
        Recursion(input);
    }

    /*
     * Takes an int input from the parameter, then takes the last digit and adds it to the rest of the number.
     * It then calls itself again using the sum to add the last digit again. This continues until the digit is only one digit long.
     */
    public static void Recursion(int input)
    {
        Console.WriteLine(input);
        if (input > 9)
        {

            string stringInput = input.ToString();

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