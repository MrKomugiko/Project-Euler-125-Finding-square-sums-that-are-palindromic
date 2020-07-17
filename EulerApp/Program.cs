
using System;
using System.Collections.Generic;

namespace EulerApp
{
    class Program
    {
        static void Main(string[] args) {
            //Solution.values(596);

            Console.WriteLine($"W zakresie <0;55> znaleziono {Solution.values(56)} pasujących elementów. powino być 1.");
            Console.WriteLine($"W zakresie <0;100> znaleziono {Solution.values(100)} pasujących elementów. powino być 2");
            Console.WriteLine($"W zakresie <0;200> znaleziono {Solution.values(200)} pasujących elementów. powino być 4");
            Console.WriteLine($"W zakresie <0;300> znaleziono {Solution.values(300)} pasujących elementów. powino być 4");
            Console.WriteLine($"W zakresie <0;400> znaleziono {Solution.values(400)} pasujących elementów. powino być 5");
            Console.WriteLine($"W zakresie <0;1000> znaleziono {Solution.values(1000)} pasujących elementów. powino być 11");

            Console.ReadLine();
        }
    }
}


public class Solution
{
    public static int values(int n) {
        int ValidPalindromCounter = 0;
        foreach (int palindrom in FindAllPalindromes(n)) {
            if (CheckIfCanBeWriteWithSumOfSquares(palindrom)) {
                ValidPalindromCounter++;
            }
        }
        return ValidPalindromCounter;
    }

    public static string Reverse(string text) {
        if (text == null) return null;

        char[] array = text.ToCharArray();
        Array.Reverse(array);
        return new String(array);
    }

    public static List<int> FindAllPalindromes(int n) {
        List<int> Palindromes = new List<int>();
        for (int i = 0; i < n; i++) {
            string number = i.ToString();
            string reversedNumber = Reverse(i.ToString());
            if (number == reversedNumber && i.ToString().Length > 1) {
                Palindromes.Add(i);
            }
        }
        return Palindromes;

    }

    public static bool CheckIfCanBeWriteWithSumOfSquares(int palindrom) {
        List<int> ListOfSquares = new List<int>();
        int newNumberFromSumms = 0;
        int maxSquareNumber = (int)Math.Sqrt(palindrom);
        back:
        int resztaLiczby = palindrom;
        int SquareValue = maxSquareNumber;
        kontynuuj:

        newNumberFromSumms = (int)Math.Pow(SquareValue, 2);

        resztaLiczby -= newNumberFromSumms;
        if (SquareValue >= 0) {
            if (resztaLiczby >= 0) {
                if (resztaLiczby < (int)Math.Pow(SquareValue - 1, 2)) {
                    maxSquareNumber -= 1;
                    ListOfSquares.RemoveAll(i=>i>-10);
                    goto back;
                }
            }

            if (resztaLiczby == (int)Math.Pow(SquareValue - 1, 2)) {
                SquareValue -= 1;
                ListOfSquares.Add(SquareValue + 1);
                ListOfSquares.Add(SquareValue);

                Console.Write($"{palindrom} = ");
                foreach (int potega in ListOfSquares) {
                    Console.Write($"[{potega}^2]");
                }
                Console.WriteLine();
                return true;
            }

            if (resztaLiczby > (int)Math.Pow(SquareValue - 1, 2)) {
                if ((SquareValue -= 1) >= 0) {
                    ListOfSquares.Add(SquareValue + 1);
                    goto kontynuuj;
                } else { 
                    return false;
                }
            } 
            else {
                maxSquareNumber--;
                goto back;
            } 
        } 
        return false;
    }




}
