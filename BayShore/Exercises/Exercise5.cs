using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BayShore.Exercises
{
   public static class Exercise5
    {
        /*
        Write some code that can be used in a templating engine.
        This should take a map of variables ("day" => "Thursday", "name"
        => "Billy") as well as a string
        template ("${name} has an appointment on ${Thursday}") and
        perform substitution as needed.
        This needs to be somewhat robust, throwing some kind of error if
        a template uses a variable that has not
        been assigned, as well as provide a way to escape the strings
        ("hello ${${name}}" -> "hello ${Billy}")
        Good Luck!
        */

       private static string stringTemplate = "${name} has an appointment on ${day}";

       private static void TemplateEngine(Dictionary<string, string> appointments, string template)
       {
           string updatedTemplate;

           Console.WriteLine("\nAppointments available: ");
           foreach (var person in appointments)
           {
               updatedTemplate = template.Replace("name", person.Key);
               updatedTemplate = updatedTemplate.Replace("day", person.Value);
               Console.WriteLine(updatedTemplate);
           }
       }


       
       
       
       public static Dictionary<string, string> GetAppointments()
       {
           int selection;
           string repeat;

           Console.WriteLine("Exercise 5");
           Console.WriteLine("------------");
           Console.WriteLine("Template Engine takes map of variables and string template\n" +
                             "Ex1: ${name} has an appointment on ${day}\n" +
                             "It should escape strings, Ex2: \"hello ${${name}}\" -> \"hello ${Billy}\"");
           Console.WriteLine("");
           
           var appointmentBook = new Dictionary<string, string>
           {
               {"Billy", "Thursday"},
               {"Kathy", "Monday"}

           };
           do
           {
               
               Console.WriteLine("\n More Options:");
               Console.WriteLine("      1 - Add an appointment");
               Console.WriteLine("      2 - Lookup An appointment");
               Console.WriteLine("      3 - Display All");
               Console.Write("\nSelection :");
               selection = Convert.ToInt32(Console.ReadLine());
               switch (selection)
               {
                   case 1:
                       AddAppointment(appointmentBook);
                       break;

                   case 2:
                       LookupByName(appointmentBook);
                       break;

                   case 3:
                       TemplateEngine(appointmentBook, stringTemplate);
                       break;

                   default:
                       Console.WriteLine("Invalid Option");
                       break;

               }

               Console.Write("\nAnother Appointment Selection y,n ?");
               repeat = Console.ReadLine();
               Console.WriteLine();

           } while (repeat == "y");

          

           return appointmentBook;
       }


       private static string CleanString(string input)
       {
           string cleanedString = "";
           var charsToRemove = new string[] { "$", "{", "}" };
           foreach( var c in charsToRemove)
           {
              input = input.Replace(c, "");
           }
           cleanedString = input;

           return cleanedString;
       }

       private static void LookupByName(Dictionary<string,string> apptBook)
       {
           string name, day;
           bool found;
           Console.WriteLine("\nLookup person's appointment day by name\n");
           Console.Write("Enter name of Person :");
           name =  Console.ReadLine();
           name = CleanString(name);

           found = apptBook.TryGetValue(name, out day);
           if (found)
               Console.WriteLine("Appointment day is {0}", day);
           else
               Console.WriteLine("{0} doesn't have an appointment", name); 
       }

       private static void AddAppointment(Dictionary<string,string> app)
       {
           Console.Write("\nEnter person's name :");
           string name = Console.ReadLine();
           Console.Write("Enter appointment day :");
           string day = Console.ReadLine();
           name = CleanString(name);
           day = CleanString(day);
           if (app.ContainsKey(name))
           {
               Console.WriteLine("{0} already exist", name);
           }
           else
               app.Add(name, day);

       }
            

    }//class
}
