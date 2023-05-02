namespace resourceCollecter
{
    using Newtonsoft.Json;
    using System.IO;

    public class SaveManager
    {
        public void SaveGameState(GameState gameState, string filePath)
        {
            var jsonString = JsonConvert.SerializeObject(gameState, Formatting.Indented);
            File.WriteAllText(filePath, jsonString);
        }

        public GameState LoadGameState(string filePath)
        {
            if (File.Exists(filePath))
            {
                var jsonString = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<GameState>(jsonString);
            }

            return null;
        }


    }

}
