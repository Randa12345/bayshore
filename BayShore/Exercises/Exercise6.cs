using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BayShore.Exercises
{
   public static class Exercise6
    {
       /*
       Please implement a function that checks whether a positive number is a palindrome or not. For
       example, 121 is a palindrome, but 123 is not.
       */

       public static void Palindrome()
       {
           string  input, backwards;

           Description6();
           Console.Write("Enter a positive number :");
           input = Console.ReadLine();
           
           char[] arrayInput = input.ToCharArray();
           Array.Reverse(arrayInput);
           backwards = new string(arrayInput);
           
           if(input == backwards)
           {
               Console.WriteLine("{0} is palindrome", input);
           }
           else
           {
               Console.WriteLine("{0} is not palindrome", input);
           }
           
       }

       private static void Description6()
       {
           Console.WriteLine("Exercise 6");
           Console.WriteLine("------------");
           Console.WriteLine("Function checks whether a positive number is a palindrome or not\n" + 
                             "Example, 121 is a palindrome, but 123 is not.");
           Console.WriteLine();

       }

    }//class
}
