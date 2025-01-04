using Coursework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Coursework.Abstraction
{
    public abstract class TagBase
    {

        protected static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "tag.json");
        protected List<Tag> LoadTags()
        {
            // If the file does not exist, return an empty list to indicate no users are saved
            if (!File.Exists(FilePath)) return new List<Tag>();

            // Read the JSON content from the file
            var json = File.ReadAllText(FilePath);

            // Deserialize the JSON content into a list of User objects
            // If deserialization fails (null result), return an empty list
            return JsonSerializer.Deserialize<List<Tag>>(json) ?? new List<Tag>();
        }

        // Method to save user data to the users.json file
        protected void SaveTags(List<Tag> tags)
        {
            // Serialize the list of User objects into a JSON string
            var json = JsonSerializer.Serialize(tags);

            // Write the JSON string to the users.json file
            File.WriteAllText(FilePath, json);
        }

        // Method to empty the users.json file
        protected void ClearTags()
        {
            // Write an empty JSON array to the file
            File.WriteAllText(FilePath, "[]");
        }
    }
}
