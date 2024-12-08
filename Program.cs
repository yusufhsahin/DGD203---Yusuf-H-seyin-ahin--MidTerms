using System;
using System.Collections.Generic;

class AnatolianAdventureGame
{
    // Note: This code was developed with assistance from ChatGPT and Claude AI to improve structure and readability

    // Results dictionary storing story outcomes based on player choices
    static readonly Dictionary<List<int>, string> ResultMap = new Dictionary<List<int>, string>
    {
        { new List<int> {1, 1, 1, 1}, "In Cappadocia, to the melody of a flute, you discovered an ancient cave wall inscribed with an unknown language. Perhaps these markings hold secrets from centuries past." },
        { new List<int> {1, 1, 1, 2}, "Among the fairy chimneys, you uncovered an ancient passage, but unfortunately, it has collapsed. Only the symbols at its edge might offer a clue." },
        { new List<int> {2, 2, 3, 1}, "In the narrow streets of Safranbolu, you found a hidden treasure in an old mansion's attic! However, the treasure map seems incomplete." },
        { new List<int> {3, 3, 1, 3}, "At the summit of Mount Nemrut, as the sun set, the statues revealed a breathtaking secret. A mystery that has slumbered for centuries is now yours." }
    };

    /// <summary>
    /// Retrieves the story outcome based on player choices
    /// </summary>
    static string GetResultText(int choice1, int choice2, int choice3, int choice4)
    {
        var choices = new List<int> { choice1, choice2, choice3, choice4 };

        // Return specific result if the choice combination exists
        return ResultMap.TryGetValue(choices, out string result) 
            ? result 
            : "You became part of an unforgettable story in the depths of Anatolia. Some mysteries remain unsolved.";
    }

    /// <summary>
    /// Validates and retrieves user choice
    /// </summary>
    static int GetValidChoice(string prompt, int maxChoice)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= maxChoice)
            {
                return choice;
            }
            Console.WriteLine($"Please enter a valid number between 1 and {maxChoice}.");
        }
    }

    static void Main()
    {
        // Welcome and player introduction
        Console.WriteLine("Hello! Are you ready for a journey through Anatolia's fertile lands?");
        Console.Write("Please enter your name: ");
        string playerName = Console.ReadLine();

        Console.WriteLine($"\nWelcome, {playerName}! Your choices will shape your destiny on this adventure.\n");

        // First Question - Starting Point
        int choice1 = GetValidChoice(
            "1. Where would you like to begin your journey?\n" +
            "   1. The mystical fairy chimneys of Cappadocia\n" +
            "   2. The historic mansions of Safranbolu\n" +
            "   3. The summit of Mount Nemrut\n", 3);

        // Second Question - Items to Bring
        int choice2 = GetValidChoice(
            "2. You must bring something with you. What do you choose?\n" +
            "   1. A flute - To play melodies along the way\n" +
            "   2. A water jug - Critically important for the journey\n" +
            "   3. A dagger - For protection against dangers\n", 3);

        // Third Question - Dynamic Story Question
        int choice3;
        if (choice1 == 1)
        {
            choice3 = GetValidChoice(
                "\n3. You found an object in the fairy chimneys. What do you do?\n" +
                "   1. Dig and look inside\n" +
                "   2. Leave it where it is and continue your journey\n" +
                "   3. Consult a wise elder nearby\n", 3);
        }
        else if (choice1 == 2)
        {
            choice3 = GetValidChoice(
                "\n3. You discovered a map inside an old mansion in Safranbolu. What do you do?\n" +
                "   1. Follow the map\n" +
                "   2. Keep the map and examine it later\n" +
                "   3. Show the map to someone knowledgeable\n", 3);
        }
        else
        {
            choice3 = GetValidChoice(
                "\n3. You found a mysterious cover beneath a statue at Mount Nemrut. What do you do?\n" +
                "   1. Open the cover\n" +
                "   2. Move away\n" +
                "   3. Ask another visitor for help\n", 3);
        }

        // Fourth Question - Encounter with a Stranger
        int choice4 = GetValidChoice(
            "\n4. You encounter a stranger during your journey. What do you do?\n" +
            "   1. Greet them friendly\n" +
            "   2. Try to get more information about them\n" +
            "   3. Ignore them and continue your journey\n", 3);

        // Result
        Console.WriteLine($"\nThank you, {playerName}! Your choices have led you on an incredible journey:");
        string result = GetResultText(choice1, choice2, choice3, choice4);
        Console.WriteLine(result);

        Console.WriteLine($"\nThe game has ended. Thank you, {playerName}! Until we meet again.\n");
    }
}
