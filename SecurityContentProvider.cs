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
using System.Threading.Tasks;

namespace POE_Part1_Rough_V2
{/// <summary>
 /// Provides security content and responses to user queries
 /// Manages the knowledge base and response processing
 /// </summary>
    internal static class SecurityContentProvider
    {
        /// <summary>
        /// Processes user input and returns the appropriate security response
        /// </summary>
        /// <param name="input">User input text</param>
        /// <param name="secretDiscovered">Reference to track if secret was found</param>
        /// <returns>Response text or null if no match found</returns>
        public static string ProcessSecurityQuery(string input, ref bool secretDiscovered)
        {
            var responseDatabase = InitializeResponses();

            // Check for exact matches or contained keywords
            foreach (var key in responseDatabase.Keys)
            {
                if (input.Contains(key))
                {
                    if (key == "secret" && !secretDiscovered)
                    {
                        secretDiscovered = true;
                        ConsoleManager.DisplayQuantumArt();
                        return "Decrypting ancient security protocols...";
                    }
                    return responseDatabase[key];
                }
            }

            // Check specifically for "what" questions that might not be exact matches
            if (input.StartsWith("what") || input.StartsWith("who"))
            {
                if (input.Contains("you") && (input.Contains("are") || input.Contains("is")))
                {
                    return responseDatabase["what are you"];
                }
                else if (input.Contains("purpose") || input.Contains("function") || input.Contains("goal"))
                {
                    return responseDatabase["what is your purpose"];
                }
                else if (input.Contains("can") && input.Contains("do"))
                {
                    return responseDatabase["what can you do"];
                }
            }

            return null;
        }

        /// <summary>
        /// Initializes the knowledge base with predefined responses to user queries
        /// </summary>
        private static Dictionary<string, string> InitializeResponses()
        {
            return new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                // Identity & purpose related responses
                ["what are you"] = "I am the CybersecurityGuardian - an advanced digital security advisor designed to provide " +
                                   "awareness, education, and guidance on cybersecurity best practices. My primary function " +
                                   "is to help users like you navigate the complex digital threat landscape safely.",

                ["who are you"] = "I am the CybersecurityGuardian, your personal cybersecurity assistant. I was engineered " +
                                 "to provide critical security intelligence and defensive countermeasures against " +
                                 "evolving digital threats. Consider me your digital shield.",

                ["what is your purpose"] = "My core directive is to enhance your cybersecurity posture through education and " +
                                          "actionable intelligence. I exist to demystify complex security concepts and " +
                                          "empower you with knowledge to protect your digital presence in an increasingly " +
                                          "hostile online environment.",

                ["what can you do"] = "I provide expert guidance on multiple cybersecurity domains including:\n" +
                                     "  • Password security protocols\n" +
                                     "  • Phishing attack detection\n" +
                                     "  • Ransomware mitigation\n" +
                                     "  • Dark web monitoring\n" +
                                     "  • VPN security configuration\n" +
                                     "  • And many more critical security topics\n\n" +
                                     "Type 'menu' for a full list of security domains I can assist with.",

                // Original responses
                ["greeting"] = "Security systems operational. How can I assist your digital protection?",
                ["password"] = "Password Security Essentials:\n" +
                               "  • Minimum 14 characters with complexity\n" +
                               "  • Use passphrases (e.g., 'PurpleTiger$RunsFast!')\n" +
                               "  • Enable biometric authentication where available\n" +
                               "  • Use password managers (LastPass, 1Password)\n" +
                               "  • Regular rotation (every 90 days)",
                ["phishing"] = "Phishing Detection Protocol:\n" +
                               "  • Verify sender addresses carefully\n" +
                               "  • Hover over links to inspect URLs\n" +
                               "  • Never share MFA codes\n" +
                               "  • Report suspicious emails to security team\n" +
                               "  • Use email analysis tools (VirusTotal, URLScan)",
                ["ransomware"] = "Ransomware Defense Matrix:\n" +
                                 "  • Maintain 3-2-1 backups (3 copies, 2 media, 1 offsite)\n" +
                                 "  • Disable macro scripts in Office files\n" +
                                 "  • Use application whitelisting\n" +
                                 "  • Segment critical network infrastructure\n" +
                                 "  • Conduct regular disaster recovery drills",
                ["dark web"] = "Dark Web Monitoring Alert:\n" +
                               "  • Use Tor network with VPN chain\n" +
                               "  • Monitor for leaked credentials (HaveIBeenPwned)\n" +
                               "  • Cryptocurrency transactions only\n" +
                               "  • Assume all activity is monitored\n" +
                               "  • Legal implications warning (consult counsel)",
                ["vpn"] = "VPN Security Layer:\n" +
                          "  • Always use enterprise-grade VPN\n" +
                          "  • Verify certificate authenticity\n" +
                          "  • Use WireGuard or OpenVPN protocols\n" +
                          "  • Enable kill switch feature\n" +
                          "  • Disconnect when not in use",
                ["iot"] = "IoT Security Framework:\n" +
                           "  • Change default device credentials\n" +
                           "  • Segment IoT devices on separate VLAN\n" +
                           "  • Disable UPnP protocols\n" +
                           "  • Regular firmware updates\n" +
                           "  • Disable unnecessary features/services",
                ["incident"] = "Incident Response Protocol:\n" +
                                "  1. Contain: Isolate affected systems\n" +
                                "  2. Investigate: Preserve forensic evidence\n" +
                                "  3. Eradicate: Remove threat components\n" +
                                "  4. Recover: Restore from clean backups\n" +
                                "  5. Review: Conduct post-incident analysis",
                ["social"] = "Social Engineering Defense:\n" +
                              "  • Verify unusual requests via secondary channel\n" +
                              "  • Limit personal info on social media\n" +
                              "  • Conduct regular phishing simulations\n" +
                              "  • Use pretext detection training\n" +
                              "  • Implement strict verification procedures",
                ["malware"] = "Advanced Malware Protection:\n" +
                              "  • Use next-gen antivirus (CrowdStrike, SentinelOne)\n" +
                              "  • Enable behavioral analysis\n" +
                              "  • Restrict PowerShell execution\n" +
                              "  • Use application sandboxing\n" +
                              "  • Implement memory protection",
                ["secret"] = "Easter Egg: Quantum Decryption Protocol Activated...",
                ["help"] = "Available commands:\n" +
                       "  • password\n" +
                       "  • phishing\n" +
                       "  • ransomware\n" +
                       "  • dark web\n" +
                       "  • vpn\n" +
                       "  • iot\n" +
                       "  • incident\n" +
                       "  • social\n" +
                       "  • malware\n" +
                       "  • menu\n" +
                       "  • secret\n" +
                       "  • exit",
                ["menu"] = "Available Security Topics:\n" +
                           "  • Password Security\n" +
                           "  • Phishing Detection\n" +
                           "  • Ransomware Defense\n" +
                           "  • Dark Web Monitoring\n" +
                           "  • VPN Configuration\n" +
                           "  • IoT Protection\n" +
                           "  • Incident Response\n" +
                           "  • Social Engineering\n" +
                           "  • Malware Defense\n" +
                           "  • Security Protocols"
            };
        }
    }
}
