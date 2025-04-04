using System;
using System.Speech.Synthesis;
using System.Threading;

namespace CybersecurityBot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new SpeechSynthesizer instance
            SpeechSynthesizer synth = new SpeechSynthesizer();

            // Set properties (optional)
            synth.Rate = 0; // Speed of speech (can adjust between -10 and 10)
            synth.Volume = 100; // Volume (0-100)

            // Print ASCII logo with typing effect
            Console.ForegroundColor = ConsoleColor.Cyan;
            TypeEffect(@"
        _ 
       / \      _-' 
     _/|  \-''- _ / 
__-' { |          \ 
    /             \ 
    /       ""o.  |o } 
    |            \ ; 
                  ', 
       \_         __\ 
         ''-_    \.// 
           / '-____' 
          / 
        _' 
      _-'");

            // Initial greeting with typing effect
            TypeEffect("\n**********************************************\n");
            TypeEffect("*       Welcome to the Cybersecurity Bot!    *\n");
            TypeEffect("**********************************************\n");
            Console.ResetColor();

            string greetingMessage = "Hello! Welcome to the cybersecurity Awareness Bot. I'm here to help you stay safe online.";
            TypeEffect(greetingMessage + "\n");
            synth.Speak(greetingMessage);

            Console.ForegroundColor = ConsoleColor.Yellow;
            TypeEffect("[INFO] Ask me something or type 'exit' to quit.\n");
            Console.ResetColor();

            // Main loop to handle user input
            while (true)
            {
                TypeEffect("\nWhat would you like to ask me?\n");
                Console.Write("You: ");
                string userInput = Console.ReadLine()?.Trim().ToLower();

                // Exit condition
                if (userInput == "exit")
                {
                    string goodbyeMessage = "Goodbye! Stay safe online.";
                    Console.ForegroundColor = ConsoleColor.Green;
                    TypeEffect("[BOT] " + goodbyeMessage + "\n");
                    synth.Speak(goodbyeMessage);
                    break; // Exit the loop and end the program
                }

                // If input is empty or null, ask user to rephrase
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    string response = "I didn't quite understand that. Could you rephrase?";
                    Console.ForegroundColor = ConsoleColor.Red;
                    TypeEffect("[ERROR] " + response + "\n");
                    synth.Speak(response);
                    continue; // Wait for another input
                }

                // Get bot response based on the user input
                string botResponse = GetBotResponse(userInput);

                // Display bot response
                Console.ForegroundColor = ConsoleColor.Green;
                TypeEffect("[BOT] " + botResponse + "\n");
                synth.Speak(botResponse);
            }
        }

        // Method to get bot response based on the question
        static string GetBotResponse(string question)
        {
            string response = string.Empty;

            // Logic to respond to specific questions
            if (question.Contains("how are you"))
            {
                response = "I'm doing well, thank you for asking! How can I help you today?";
            }
            else if (question.Contains("what's your purpose") || question.Contains("what is your purpose"))
            {
                response = "My purpose is to help you stay safe online by providing information about cybersecurity best practices.";
            }
            else if (question.Contains("what can i ask") || question.Contains("what can I ask"))
            {
                response = "You can ask me about online safety, best practices, phishing scams, password security, and much more!";
            }
            else if (question.Contains("phishing"))
            {
                response = "Phishing is a type of cyber attack where malicious actors impersonate legitimate organizations or individuals to trick people into revealing sensitive information, such as passwords or credit card details.";
            }
            else if (question.Contains("how do I make my password secure"))
            {
                response = "To make your password secure, use a mix of uppercase and lowercase letters, numbers, and special characters. Ensure your password is at least 12 characters long and avoid using easily guessed information like names or birthdays.";
            }
            else if (question.Contains("firewall"))
            {
                response = "A firewall is a network security system that monitors and controls incoming and outgoing network traffic based on predetermined security rules. It's like a barrier between your computer and external threats.";
            }
            else if (question.Contains("two-factor authentication") || question.Contains("2fa"))
            {
                response = "Two-factor authentication (2FA) is an extra layer of security where you provide two forms of identification before accessing your account. This could include something you know (like a password) and something you have (like a code sent to your phone).";
            }
            else if (question.Contains("malware"))
            {
                response = "Malware is malicious software designed to harm, exploit, or otherwise compromise your computer or network. It includes viruses, worms, ransomware, and spyware.";
            }
            else if (question.Contains("how to avoid phishing"))
            {
                response = "To avoid phishing, never click on suspicious links or open attachments from unknown senders. Always verify the authenticity of emails or messages by contacting the organization directly, and be cautious of urgent or threatening language.";
            }
            else
            {
                response = "I'm sorry, I don't have an answer to that. Could you ask something else?";
            }

            return response;
        }

        // Method to simulate typing effect
        static void TypeEffect(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(50); // Delay to simulate typing effect (adjust for faster/slower typing)
            }
        }
    }
}
