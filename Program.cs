using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace DiceRole
{
    class Program
    {
        static List<int> rolls = new List<int>();
        static void Main()
        {
            string filePath = "./rolls.txt";
            if (File.Exists(filePath))
            {
                string[] arr = File.ReadAllLines(filePath);
                foreach (string s in arr)
                {
                    rolls.Add(int.Parse(s));
                }
            }
            while (true)
            {
                int inputNum;
                while (true)
                {
                    Console.WriteLine("1. Roll Dice\n2. Calculate Key Values\n3. List Rolls\n4. Delete All Rolls\n5. Exit\nEnter the number for the action you wish to complete");
                    string input = Console.ReadLine().Trim();

                    if (char.IsDigit(input, 0))
                    {

                        inputNum = (int)char.GetNumericValue(input[0]);
                        if (1 <= inputNum && inputNum <= 5)
                            break;
                    }
                    Console.Clear();
                    Console.WriteLine("Incorrect Input");
                    //checks to see if input was a digit between 1 and 5 if not loops back on itself
                }
                switch (inputNum)
                {
                    case 1:
                        Roll();
                        break;
                    case 2:
                        calcKeyVals();
                        break;
                    case 3:
                        listAllRolls();
                        break;
                    case 4:
                        Console.Clear();
                        using (StreamWriter writer = new StreamWriter("./rolls.txt", false))
                        {
                            writer.Write("");
                        }
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        static void Roll()
        {
            int inputNum;

            Console.Clear();
            while (true)
            {

                Console.WriteLine("How many dice would you like to roll?");
                string input = Console.ReadLine().Trim();
                if (int.TryParse(input, out inputNum))
                    break;
                Console.Clear();
                Console.WriteLine("Incorrect Input");
            }
            Console.Clear();
            Random rnd = new Random();
            List<int> tempRolls = new List<int>();
            Console.WriteLine(inputNum);
            for (int i = 0; i < inputNum; i++)
            {
                int roll = rnd.Next(1, 6);
                rolls.Add(roll);
                tempRolls.Add(roll);
            }
            while (true)
            {
                using (StreamWriter writer = new StreamWriter("./rolls.txt", true))
                {
                    foreach (int roll in tempRolls)
                    {
                        Console.WriteLine(roll);
                        writer.WriteLine(roll);
                    }
                }
                Console.WriteLine("Would you like to return? (Y/N)");
                string yesNo = Console.ReadLine().Trim().ToUpper();
                if (yesNo[0] == 'Y')
                {
                    Console.Clear();
                    break;
                }
            }
        }
        //Rolls dice and writes the results to the text file and adds it to the list
        static void calcKeyVals()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"The average of the rolls was: {rolls.Average()}");
                Console.WriteLine($"The total was {rolls.Sum()}");
                Console.WriteLine("Would you like to return? (Y/N)");
                string yesNo = Console.ReadLine().Trim().ToUpper();
                if (yesNo[0] == 'Y')
                {
                    Console.Clear();
                    break;
                }
            }
        }
        //prints key values (total, average) to the console
        static void listAllRolls()
        {
            while (true)
            {
                Console.Clear();
                foreach (int roll in rolls)
                {
                    Console.WriteLine(roll);
                }
                Console.WriteLine("Would you like to return? (Y/N)");
                string yesNo = Console.ReadLine().Trim().ToUpper();
                if (yesNo[0] == 'Y')
                {
                    Console.Clear();
                    break;
                }
            }
        }
        //lists all the rolls that are stored in the list
    }
}
