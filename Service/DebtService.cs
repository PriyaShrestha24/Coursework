using Coursework.Model;
using Coursework.Abstraction;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using Coursework.Service.Interface;

namespace Coursework.Service
{
    public class DebtService : DebtBase, IDebtService
    {

        private List<Debt> _debts;

        public DebtService()
        {
            _debts = LoadDebts();
        }

        public void AddDebt(Debt debt)
        {
            if (!_debts.Any(u => u.DebtName == debt.DebtName))
            {
                if (debt.DebtID == Guid.Empty)
                {
                    debt.DebtID = Guid.NewGuid();
                }
                _debts.Add(new Debt { DebtID = debt.DebtID, DebtName = debt.DebtName, DebtAmount = debt.DebtAmount, DebtStatus= "Pending", DebtDate=debt.DebtDate });
                SaveDebts(_debts);
            }
        }

        public void DeleteDebt(Guid debtId)
        {
            var debt = _debts.FirstOrDefault(t => t.DebtID == debtId);
            if (debt != null)
            {
                _debts.Remove(debt);
                SaveDebts(_debts); // Save updated list to storage
            }
        }


        public List<Debt> GetDebts()
        {
            return _debts; // Return the list of tags
        }

        private List<Debt> LoadDebts()
        {
            // Load debts from persistent storage (e.g., a JSON file)
            try
            {
                var json = File.ReadAllText("debts.json");
                return JsonSerializer.Deserialize<List<Debt>>(json) ?? new List<Debt>();
            }
            catch
            {
                return new List<Debt>();
            }
        }

        private void SaveDebts(List<Debt> debts)
        {
            // Save tags to persistent storage (e.g., a JSON file)
            var json = JsonSerializer.Serialize(debts);
            File.WriteAllText("debts.json", json);
        }
    }
}
