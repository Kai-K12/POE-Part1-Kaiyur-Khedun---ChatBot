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
 https://youtu.be/wDTdTfkynvg?si=5_zJo3FLTmHpWs34
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace POE_Part1_Rough_V2
{
    /// <summary>
    /// Manages user interactions and input processing
    /// Handles user input, validation, and response generation
    /// </summary>
    internal static class UserInteraction
    {
        // Visual styling elements and user state
        private static readonly ConsoleColor[] SecurityColors = { ConsoleColor.Cyan, ConsoleColor.Green, ConsoleColor.Yellow };
        private static string _userName = "CyberStranger"; // Default username until provided
        private static bool _secretDiscovered = false; // Easter egg tracking

        // Typing simulation configuration
        private const int TypingSpeedMin = 30; // Minimum typing simulation delay in ms
        private const int TypingSpeedMax = 100; // Maximum typing simulation delay in ms

        /// <summary>
        /// Prompts the user for their identity/handle
        /// </summary>
        public static void GetUserName()
        {
            ConsoleManager.PrintSecurityBorder();
            Console.Write("\n  > Identity Verification Required: Enter your handle > ");
            Console.ForegroundColor = ConsoleColor.Cyan;

            string input;
            do
            {
                input = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(input))
                {
                    ConsoleManager.PrintColoredMessage("  [ALERT] Identity cannot be blank. Enter your handle > ", ConsoleColor.Red);
                }
            } while (string.IsNullOrEmpty(input));

            _userName = input.Length > 20 ? input.Substring(0, 17) + "..." : input;
            Console.ResetColor();
            ConsoleManager.PrintColoredMessage($"\n  [ Identity confirmed: {_userName} ]\n  Initializing security protocols...", ConsoleColor.Green);
            ConsoleManager.PrintSecurityBorder();
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Main interaction loop that processes user input
        /// </summary>
        public static void ChatLoop()
        {
            while (true)
            {
                ConsoleManager.PrintSectionHeader("THREAT ANALYSIS CONSOLE");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"\n  {_userName}, enter security query (type 'menu' for options) > ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string input = (Console.ReadLine()?.Trim().ToLower() ?? "").Replace("'", "");
                Console.ResetColor();

                if (ValidateInput(input)) break;
                ProcessInput(input);
            }
        }

        /// <summary>
        /// Validates special command inputs
        /// </summary>
        /// <param name="input">User input string</param>
        /// <returns>True if program should exit, false otherwise</returns>
        public static bool ValidateInput(string input)
        {
            if (input == "exit")
            {
                ConsoleManager.PrintColoredMessage("\n  [ Initiating secure session termination... ]", ConsoleColor.DarkRed);
                Thread.Sleep(1500);
                return true;
            }

            if (input == "clear")
            {
                Console.Clear();
                ConsoleManager.DisplayAsciiArt();
                return false;
            }

            return false;
        }

        /// <summary>
        /// Processes user input and displays appropriate responses
        /// </summary>
        /// <param name="input">User input string</param>
        public static void ProcessInput(string input)
        {
            string response = SecurityContentProvider.ProcessSecurityQuery(input, ref _secretDiscovered);

            if (response == null)
            {
                ConsoleManager.PrintColoredMessage("\n  [ WARNING: Unrecognized security protocol ]", ConsoleColor.Red);
                ConsoleManager.PrintColoredMessage("  Type 'menu' for available security topics", ConsoleColor.DarkYellow);
            }
            else
            {
                ConsoleManager.PrintSecurityBorder();
                ConsoleManager.PrintColoredResponse(response);
                ConsoleManager.PrintSecurityBorder();
            }
        }

        /// <summary>
        /// Simulates typing animation for text output
        /// Allows user to skip by pressing any key
        /// </summary>
        /// <param name="text">Text to be animated</param>
        public static void SimulateTyping(string text)
        {
            var rnd = new Random();
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(rnd.Next(TypingSpeedMin, TypingSpeedMax));
                if (Console.KeyAvailable) // Allow user to skip typing
                {
                    Console.ReadKey(true);
                    Console.Write(text.Substring(text.IndexOf(c) + 1));
                    break;
                }
            }
        }
    }
}
