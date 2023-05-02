using Newtonsoft.Json;
using System.IO;

namespace resourceCollecter
{
    public class SaveManager
    {
        // Save the given game state to the specified file path
        public void SaveGameState(GameState gameState, string filePath)
        {
            // Serialize the game state to a JSON string with indented formatting
            var jsonString = JsonConvert.SerializeObject(gameState, Formatting.Indented);

            // Write the JSON string to the specified file
            File.WriteAllText(filePath, jsonString);
        }

        // Load the game state from the specified file path, if it exists
        public GameState LoadGameState(string filePath)
        {
            if (File.Exists(filePath))  // Check if the file exists
            {
                // Read the contents of the file into a string
                var jsonString = File.ReadAllText(filePath);

                // Deserialize the JSON string into a GameState object and return it
                return JsonConvert.DeserializeObject<GameState>(jsonString);
            }

            return null;  // Return null if the file does not exist
        }
    }


}
