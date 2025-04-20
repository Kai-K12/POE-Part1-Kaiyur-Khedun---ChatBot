/*
 Student Name: Kaiyur Khedun
 Student Number: ST10084490

 Reference List
 https://stackoverflow.com/questions/3436132/producing-ascii-art-via-c-sharp
 https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding.ascii?view=net-9.0
 https://www.geeksforgeeks.org/c-sharp-how-to-change-foreground-color-of-text-in-console/
 https://www.geeksforgeeks.org/parameter-passing-techniques-in-c-cpp/
 https://stackoverflow.com/questions/1702559/ascii-art-in-html
 https://csharp.2000things.com/tag/ascii-art/
 https://www.c-sharpcorner.com/UploadFile/c63ec5/use-params-keyword-in-C-Sharp/
 https://ironpdf.com/blog/net-help/csharp-thread-sleep-method/#trial-license
 https://ironpdf.com/blog/net-help/csharp-thread-sleep-method/#trial-license
 https://stackoverflow.com/questions/69392064/audio-file-path-not-dynamic
 https://products.aspose.com/total/net/?utm_source=google&utm_medium=cpc&utm_campaign=pmax-all-products&utm_content=total-for-net&gad_source=5&gad_campaignid=22310322848&gclid=EAIaIQobChMI9KbZt47ljAMVhEtHAR0IWQkgEAAYAiAAEgKin_D_BwE
 https://www.geeksforgeeks.org/c-sharp-dictionary-with-examples/
 https://www.geeksforgeeks.org/c-sharp-dictionary-with-examples/
 https://www.geeksforgeeks.org/c-sharp-dictionary-with-examples/
 https://learn.microsoft.com/en-us/dotnet/csharp/linq/
 https://www.c-sharpcorner.com/UploadFile/72d20e/concept-of-linq-with-C-Sharp/
 https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/collections
 */





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_Part1_Rough_V2
{
    /// <summary>
    /// Main entry point class for the CybersecurityGuardian application
    /// Acts as the coordinator between UI, audio, and security content components
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main entry point of the application
        /// Initializes components and manages the primary application flow
        /// </summary>
        static void Main(string[] args)
        {
            // Initialize the console UI
            ConsoleManager.InitializeConsole();
            ConsoleManager.DisplayAsciiArt();

            // Play welcome audio with synchronized typing animation
            AudioManager.PlayWelcomeSequence();

            // Get user identity and show main menu
            UserInteraction.GetUserName();
            ConsoleManager.ShowMainMenu();

            // Enter the main interactive loop
            UserInteraction.ChatLoop();

            // Program exit
            ConsoleManager.PrintColoredMessage("\n  [ Security Session Terminated. Stay vigilant! ]", ConsoleColor.DarkRed);
            Console.ReadKey();
        }
    }
}