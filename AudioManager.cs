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
using NAudio.Wave;

namespace POE_Part1_Rough_V2
{
    /// <summary>
    /// Manages audio playback and related functionality
    /// Handles welcome audio and synchronization with typing animations
    /// </summary>
    internal static class AudioManager
    {
        // Audio configuration constants
        private const string AudioFilePath = "ouuu.wav"; // Path to welcome audio file

        /// <summary>
        /// Plays welcome audio and displays synchronized typing animation
        /// </summary>
        public static void PlayWelcomeSequence()
        {
            try
            {
                if (!System.IO.File.Exists(AudioFilePath))
                {
                    ConsoleManager.PrintColoredMessage("\n  Security Alert: Audio authentication missing!", ConsoleColor.Red);
                    return;
                }

                using (var audioFile = new AudioFileReader(AudioFilePath))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();

                    // Original text from your audio file
                    var welcomeText = @"
Greetings, digital traveler! You've just entered a safe zone—well, as safe as the internet allows.
I'm your friendly Cybersecurity Awareness Bot, here to help you dodge scams, outsmart hackers, 
and keep your data locked up tighter than Fort Knox.";

                    // Simulate typing at the original pace
                    var typingThread = new Thread(() => UserInteraction.SimulateTyping(welcomeText));
                    typingThread.Start();

                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                ConsoleManager.PrintColoredMessage($"\n  [ERROR] Audio subsystem failure: {ex.Message}", ConsoleColor.Red);
            }
        }
    }
}
