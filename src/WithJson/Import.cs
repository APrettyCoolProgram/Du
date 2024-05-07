using System.Text.Json;

namespace Du.WithJson
{
    public class Import
    {
        public static JsonObject FromFile<JsonObject>(string filePath)
        {
            /*
             *  var myThing = Du.WithJson.Import.FromLocalFile<ThingObject>("/Path/To/File.json");
             */
            var configurationFileContents = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<JsonObject>(configurationFileContents);
        }
    }
}