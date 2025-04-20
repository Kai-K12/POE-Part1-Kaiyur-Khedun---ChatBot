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

/// <summary>
/// Manages console display, formatting, and visual elements
/// Handles all console output styling and ASCII art rendering
/// </summary>
namespace POE_Part1_Rough_V2
{
    static class ConsoleManager
    {
        // Console configuration constants
        private const int TerminalWidth = 100; // Preferred terminal width

        /// <summary>
        /// Sets up the console environment and styling.
        /// - Clears the screen
        /// - Hides the cursor
        /// - Sets console title and output encoding
        /// - Adjusts window width to a fixed maximum
        /// </summary>
        public static void InitializeConsole()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();
            Console.CursorVisible = false;
            Console.Title = "CyberSecurity Guardian v2.1";
            Console.WindowWidth = Math.Min(TerminalWidth, Console.LargestWindowWidth);
        }

        /// <summary>
        /// Displays the main ASCII artwork for the application.
        /// - Shows a green robot figure
        /// - Shows a red CYBER ATTACKS banner
        /// - Draws colored borders above and below
        /// </summary>
        public static void DisplayAsciiArt()
        {
            // Green header bot
            string asciiBot = @"
       ...
     ;::::; 
   ;::::; :;
 ;:::::'   :;
;:::::;     ;.
,:::::'       ;           OOO\
::::::;       ;          OOOOO\
;:::::;       ;         OOOOOOOO
,;::::::;     ;'         / OOOOOOO
;:::::::::`. ,,,;.      /  / DOOOOOO
';:::::::::::::::::;,  /  /     DOOOO
,::::::;::::::;;;;::::;/  /        DOOO
;`::::::`'::::::;;;::::: #/         DOOO
:`:::::::`;::::::;;::: ;::#         DOOO
::`:::::::`;:::::::: ;::::#         DOO
`:`:::::::`;:::::: ;::::::#         DOO
 :::`:::::::`;; ;:::::::::#         OO
 ::::`:::::::`;::::::::;:::#        OO
 `:::::`::::::::::::;'`:;::#        O
  `:::::`::::::::;' /  / `:#        
   ::::::`:::::;'  /  /   `#";

            PrintAsciiAnimated(asciiBot, ConsoleColor.Green, 15);

            // Border top
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  " + new string('═', Console.WindowWidth - 4));

            // Cyber Attack ASCII
            string cyberAttackAscii = @"
  CCCCC  Y   Y  BBBBB   EEEEE  RRRRR      AAAAA  TTTTT  TTTTT  AAAAA  CCCCC  K   K  SSSSS
 C        Y Y   B    B  E       R    R   A     A   T      T   A     A C       K  K  S
 C         Y    BBBBB   EEEE    RRRRR    AAAAAAA   T      T   AAAAAAA C       K K    SSS
 C         Y    B    B  E       R  R     A     A   T      T   A     A C       K  K      S
  CCCCC    Y    BBBBB   EEEEE   R   R    A     A   T      T   A     A  CCCCC  K   K  SSSSS
";
            PrintAsciiAnimated(cyberAttackAscii, ConsoleColor.Red, 25);

            // Border bottom
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  " + new string('═', Console.WindowWidth - 4));
            Console.ResetColor();
        }

        /// <summary>
        /// Animates ASCII art line by line with a delay between lines.
        /// Useful for dramatic effect or smooth visual transitions.
        /// </summary>
        /// <param name="ascii">The ASCII art string to print</param>
        /// <param name="color">The color used to display the text</param>
        /// <param name="delay">Milliseconds to wait between each line (default 30)</param>
        public static void PrintAsciiAnimated(string ascii, ConsoleColor color, int delay = 30)
        {
            Console.ForegroundColor = color;
            foreach (string line in ascii.Split('\n'))
            {
                Console.WriteLine(line);
                Thread.Sleep(delay);
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Prints a message in a specific console color.
        /// Color resets automatically after printing.
        /// </summary>
        /// <param name="message">The message to be displayed</param>
        /// <param name="color">The desired color for the message</param>
        public static void PrintColoredMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Prints a stylized section header using box-drawing characters.
        /// Visually separates sections of output for readability.
        /// </summary>
        /// <param name="title">The header text to display</param>
        public static void PrintSectionHeader(string title)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"  ╔{new string('≡', title.Length + 4)}╗");
            Console.WriteLine($"  ║  {title.ToUpper()}  ║");
            Console.WriteLine($"  ╚{new string('≡', title.Length + 4)}╝");
            Console.ResetColor();
        }

        /// <summary>
        /// Prints a thick horizontal border line made of '▓' symbols.
        /// Used for strong visual separation between content blocks.
        /// </summary>
        public static void PrintSecurityBorder()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string border = new string('▓', Console.WindowWidth - 4);
            Console.WriteLine($"\n  {border}");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays the main application command menu.
        /// - Shows available user commands and categories
        /// - Uses color-coded formatting for clarity
        /// </summary>
        public static void ShowMainMenu()
        {
            PrintSectionHeader("THREAT MANAGEMENT CONSOLE");

            // Enhanced UI with color-coded categories
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  ┌─────────────────────────────┐");
            Console.WriteLine("  │       COMMAND CENTER        │");
            Console.WriteLine("  └─────────────────────────────┘");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("  ► help    - Show available commands");
            Console.WriteLine("  ► menu    - Display security topics");
            Console.WriteLine("  ► clear   - Reset console display");
            Console.WriteLine("  ► exit    - Terminate session");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  ┌─────────────────────────────┐");
            Console.WriteLine("  │        INFO QUERIES         │");
            Console.WriteLine("  └─────────────────────────────┘");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("  ► what are you        - Learn about this system");
            Console.WriteLine("  ► what is your purpose - System objectives");
            Console.WriteLine("  ► what can you do      - Capability overview");

            PrintSecurityBorder();
        }

        /// <summary>
        /// Displays a secret "Quantum Art" Easter egg screen.
        /// Shows a large ASCII banner with classified message.
        /// Waits 3 seconds before clearing the screen.
        /// </summary>
        public static void DisplayQuantumArt()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@"
    ██████╗ ██╗   ██╗ █████╗ ███╗   ██╗████████╗██╗   ██╗███╗   ███╗
    ██╔══██╗██║   ██║██╔══██╗████╗  ██║╚══██╔══╝██║   ██║████╗ ████║
    ██████╔╝██║   ██║███████║██╔██╗ ██║   ██║   ██║   ██║██╔████╔██║
    ██╔═══╝ ██║   ██║██╔══██║██║╚██╗██║   ██║   ██║   ██║██║╚██╔╝██║
    ██║     ╚██████╔╝██║  ██║██║ ╚████║   ██║   ╚██████╔╝██║ ╚═╝ ██║
    ╚═╝      ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═╝    ╚═════╝ ╚═╝     ╚═╝
    
    ◢◤◢◤◢◤◢◤ SECURITY LEVEL: CLASSIFIED ◢◤◢◤◢◤◢◤
            ");
            Console.ResetColor();
            Thread.Sleep(3000);
            Console.Clear();
        }

        /// <summary>
        /// Displays a response string with typing animation and cyan color.
        /// Uses SimulateTyping from the UserInteraction class.
        /// </summary>
        /// <param name="response">The multi-line text to display</param>
        public static void PrintColoredResponse(string response)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            var lines = response.Split('\n');
            foreach (var line in lines)
            {
                UserInteraction.SimulateTyping(line);
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}
