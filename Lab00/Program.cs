using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace Lab0;

class Program
{
    static void Main(string[] args)
    {
        //low number
        int lowNum = GetLowNumber();

        //high number
        int highNum = GetHighNumber(lowNum);

        //list low to high
        List<int> numList = MakeList(lowNum, highNum);


        //write list to file in reverse order
        using (StreamWriter sw = new StreamWriter("C:/cprg211/labs/lab-0/Lab00/numbers.txt"))
        {
            numList.Reverse();
            foreach (double number in numList)
            {
                sw.WriteLine(number);
            }
        }

        //print file and sum

        using (StreamReader sr = new StreamReader("C:/cprg211/labs/lab-0/Lab00/numbers.txt"))
        { 
            int summ = 0;
            int numm; //number to convert to integer from file and add to sum
            string line;
            // Read and display lines from the file until the end of
            // the file is reached.
            Console.WriteLine("\nThe numbers between high and low:");
            while ((line = sr.ReadLine()) != null)
            {
                
                Console.WriteLine(line);
                bool b = int.TryParse(line, out numm);
                summ = summ + numm;
            }
            Console.WriteLine($"\nThe sum is {summ}\n");
        }

        //print prime numbers
        int highestNum = numList.First(); // high number now first from being reversed earlier
       
        List<int> natNums = MakeList(1,highestNum); //list of natural positive numbers up to high number, there are no negative prime numbers
        foreach (int n in natNums) // test each number against all below it
        {
            bool p = IsPrime(n, natNums);
            if (p == true)
            {
                Console.WriteLine($"{n} is a prime number");
            }
        }

    }

    public static int GetLowNumber()
    {
        Console.WriteLine("Enter a low number:");
        int intInput1; //define a int variable
        while (true) //infinite loop until if executes return statement
        {
            string UserInput1 = Console.ReadLine(); //read user input
            bool b1 = int.TryParse(UserInput1, out intInput1); //assign int value of string

            if (intInput1 < 0 && b1)// if an integer and negative
            {
                return intInput1;
            }
            else
            {
                Console.WriteLine("Invalid input, enter a new low number"); // restart while loop
            }
        }
    }

    public static int GetHighNumber(int lowNum)
    {
        Console.WriteLine("\nEnter a high number:");
        int intInput2; //define a int variable
        while (true) //infinite loop until if executes return statement
        {
            string UserInput2 = Console.ReadLine(); //read user input
            bool b2 = int.TryParse(UserInput2, out intInput2); //assign int value of string

            if (intInput2 > lowNum && b2)// if an integer and negative
            {
                return intInput2;
            }
            else
            {
                Console.WriteLine("Invalid input, enter a new high number"); // restart while loop
            }
        }
    }

    //make list method
    public static List<int> MakeList(int lowNum, int highNum) // List<int> defines return type??
    {
        List<int> ListOfNumbers = new List<int>(); // initialize list
        for (int i = 0; i < (highNum - lowNum + 1); i++)
        {
            ListOfNumbers.Add(i + lowNum); // add lownum to highnum in each index
        }
        return ListOfNumbers;
    }
    public static bool IsPrime(int n, List<int> natNums)
    {
        bool isPrime = true;
        for (int i = 0; i < (n - 1); i++) 
        {
            int moddu = n%natNums[i];
         
            if (moddu==0 && (n != natNums[i]) && (natNums[i]!=1)) // if modulus is 0 by a divisor that is not itself or 1, the number is not prime!
            {
                isPrime = false;
                return isPrime;
            
            }
        }
        return isPrime; 
    }
}




