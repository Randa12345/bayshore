using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BayShore.Exercises;


namespace BayShore
{
    class Program
    {
        static void Main(string[] args)
        {
            var selection = 0;
            string repeat ="";

            do
            {
              Console.WriteLine("Exercises available:\n");
              Console.WriteLine("  1 - Exercise1");
              Console.WriteLine("  4 - Exercise4");
              Console.WriteLine("  5 - Exercise5");
              Console.WriteLine("  6 - Exercise6");
              Console.Write("Type the number of one of the Exercises :");
              selection = Int32.Parse(Console.ReadLine());
              Console.WriteLine();
            
              switch(selection)
              {
                case 1:
                    Exercise1.GetInput();
                    break;
                             
                case 4:
                    Exercise4.GameHeader();
                    break;

                case 5:
                   Exercise5.GetAppointments();
                   break;

                case 6:
                    Exercise6.Palindrome();
                    break;

                default:
                    Console.WriteLine("Invalid Selection");
                    break;
              }
                
              Console.Write("\nAnother Exercise y,n ?");
              repeat = Console.ReadLine();
              Console.WriteLine();

         }while(repeat == "y" ); 
            
              Console.ReadLine();

        }//main
    }
}
