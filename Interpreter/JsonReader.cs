// Modified JsonReader to simply load all JSON into a centralized store
namespace EGGS.Interpreter
{
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Diagnostics;

    internal static class JsonReader
    {
        public static Dictionary<string, Dictionary<string, object>> LoadAllJsonFiles(string directoryPath)
        {
            var allData = new Dictionary<string, Dictionary<string, object>>();

            try
            {
                var jsonFiles = Directory.GetFiles(directoryPath, "*.json");
                foreach (var file in jsonFiles)
                {
                    string json = File.ReadAllText(file);
                    JObject jsonObj = JObject.Parse(json);
                    var dataDict = ConvertToDictionary(jsonObj);

                    var fileName = Path.GetFileNameWithoutExtension(file);
                    allData[fileName] = dataDict;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading JSON files: {ex.Message}");
                // Optionally, handle errors or throw
            }

            return allData;
        }

        private static Dictionary<string, object> ConvertToDictionary(JObject jsonObj)
        {
            return jsonObj.ToObject<Dictionary<string, object>>();
        }
    }
}
