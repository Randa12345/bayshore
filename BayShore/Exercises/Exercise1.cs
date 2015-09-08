using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BayShore.Exercises
{
   public static class Exercise1
    {

        /*
         Write some code that will accept an amount and convert it to the appropriate string representation.
         Example:
         Convert 2523.04
         to "Two thousand five hundred twenty-three and 04/100 dollars" 
         */

        static string[] OneNinteen = new string[] { " " ,"One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", 
                                                   "Ten", "Eleven", "Tweleve", "Thirteen", "Forteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        static string[] twentyNinty = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninty" };
        static string[] hundredMillion = new string[] { "Hundred", "Thousand", "Million" };
              

       private static string ConvertIntToString(int leftNum)
       {
           string numString = "";
               
          if( leftNum < 20) //0-19
          {
             return numString = OneNinteen[leftNum];
          }
          else if( leftNum < 100) // 20-99
          {
              if (leftNum % 10 == 0)
              {
                  return numString = twentyNinty[(leftNum/10) -2 ];
              }
              else
              {
                  return numString = twentyNinty[(leftNum / 10) - 2] + "-" + ConvertIntToString(leftNum % 10);
              }
          }
          else if (leftNum < 1000) //100-999
          {
            return numString = ConvertIntToString(leftNum / 100) + " " + hundredMillion[0] + " " + ConvertIntToString(leftNum % 100);    
          }
          else if (leftNum < 1000000) // 1000 - 999,999
          {
              return numString = ConvertIntToString(leftNum / 1000) + " " + hundredMillion[1] + " " + ConvertIntToString(leftNum % 1000);  
          }

          return numString;
       }


       private static string ConvertToString(string numInput)
       {
           string numberConverted = "", decPart;
           int intPart;

           if(numInput.Contains('.'))
           {
              string[] splitNum = numInput.Split('.');
              intPart = int.Parse(splitNum[0]);
              numberConverted = ConvertIntToString(intPart);
              int len = splitNum[1].Length;

               decPart = " and " + splitNum[1] + "/" + "1".PadRight(len+1,'0');
              numberConverted += decPart;
           }
           else
               numberConverted = ConvertIntToString(int.Parse(numInput)); 
          
           return numberConverted;
       }


           
       public static void GetInput()
       {
           string numString, input;

           Console.WriteLine("Exercise 1");
           Console.WriteLine("------------");
           Console.WriteLine("convert an amount to it's appropriate string representation.\n" +
                             "Example: Convert 2523.04 to \n"+ 
                             "Two thousand five hundred twenty-three and 04/100 dollars");
           Console.WriteLine();
           
           Console.Write("Enter a number between Zero and One-Million Exclusive :");
           input = Console.ReadLine();
           numString = ConvertToString(input);
           Console.WriteLine("\n{0} is {1}", input, numString);
       }


       

    }//class
}
