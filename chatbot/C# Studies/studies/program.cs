using System;
using System;
using System.Collections.Generic;
using System.Media;  // Required for playing .wav files
using System.Threading;

class Program
{
    static void Main()
    {
        PlayGreeting(); // Play voice greeting
        DisplayHeader();
        
        Console.Write("What's your name? ");
        string userName = Console.ReadLine();

        StartChat(userName);
    }

    static void DisplayHeader()
    {
        Console.Clear();
        string asciiArt = @"
   _____ _           _     _         
  / ____| |         | |   (_)        
 | |    | |__   __ _| |__  _ _ __    
 | |    | '_ \ / _` | '_ \| | '_ \   
 | |____| | | | (_| | | | | | | | |  
  \_____|_| |_|\__,_|_| |_|_|_| |_|  
                                      
        Simple CMD ChatBot
--------------------------------";
        Console.WriteLine(asciiArt);
        Thread.Sleep(1500); // Pause for effect
    }

    static void PlayGreeting()
    {
        try
        {
            string filePath = "greeting.wav"; // Ensure the file exists in the same directory as the program
            using (SoundPlayer player = new SoundPlayer(filePath))
            {
                player.PlaySync(); // Play the sound synchronously before proceeding
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error playing greeting sound: " + ex.Message);
        }
    }

    static void StartChat(string userName)
    {
        Console.WriteLine($"\n[ChatBot]: Hello {userName}! Type 'exit' to end the chat.");

        Dictionary<string, string> responses = new Dictionary<string, string>
        {
            {"hello", $"Hi {userName}! How can I help you today?"},
            {"how are you", $"I'm just a bot, but I'm doing great! How about you, {userName}?"},
            {"what's your name", "I'm ChatBot, your friendly assistant!"},
            {"bye", $"Goodbye {userName}! Have a great day!"},
            {"what's your purpose", $"I'm here to provide helpful information and answer your questions, {userName}!"},
            {"what can i ask you about", $"You can ask me about general topics, password safety, phishing, and safe browsing, {userName}."},
            {"tell me about password safety", "Strong passwords should be at least 12 characters long and include a mix of letters, numbers, and symbols. Never reuse passwords!"},
            {"what is phishing", "Phishing is a cyber attack where attackers trick you into revealing personal information through fake emails or websites. Always verify sources!"},
            {"how can i browse safely", "To browse safely, avoid clicking on suspicious links, use updated software, and enable two-factor authentication whenever possible."}
        };

        while (true)
        {
            Console.Write("\nYou: ");
            string userInput = Console.ReadLine().ToLower();

            if (userInput == "exit")
            {
                Console.WriteLine($"\n[ChatBot]: Chat ended. Bye {userName}!");
                break;
            }

            if (responses.ContainsKey(userInput))
            {
                Console.WriteLine($"[ChatBot]: {responses[userInput]}");
            }
            else
            {
                Console.WriteLine($"[ChatBot]: Sorry {userName}, I don't understand that.");
            }
        }
    }
}
