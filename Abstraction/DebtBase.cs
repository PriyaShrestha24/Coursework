using Coursework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Coursework.Abstraction
{
    public abstract class DebtBase
    {

        protected static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "debt.json");
        protected List<Debt> LoadDebts()
        {
            // If the file does not exist, return an empty list to indicate no users are saved
            if (!File.Exists(FilePath)) return new List<Debt>();

            // Read the JSON content from the file
            var json = File.ReadAllText(FilePath);

            // Deserialize the JSON content into a list of User objects
            // If deserialization fails (null result), return an empty list
            return JsonSerializer.Deserialize<List<Debt>>(json) ?? new List<Debt>();
        }

        // Method to save user data to the users.json file
        protected void SaveDebts(List<Debt> debts)
        {
            // Serialize the list of User objects into a JSON string
            var json = JsonSerializer.Serialize(debts);

            // Write the JSON string to the users.json file
            File.WriteAllText(FilePath, json);
        }

        // Method to empty the users.json file
        protected void ClearDebts()
        {
            // Write an empty JSON array to the file
            File.WriteAllText(FilePath, "[]");
        }
    }
}
