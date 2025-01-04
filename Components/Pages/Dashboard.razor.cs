using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Coursework.Components.Pages
{
    public partial class Dashboard : ComponentBase
    {
        // Creating a transaction class with some properties
        public class Transaction
        {
            public string Description { get; set; }
            public DateTime Date { get; set; }
            public decimal Amount { get; set; }
            public string Type { get; set; } // Income, Expense, Debt
        }

        // Declaring fields for storing transaction data and totals
        private Transaction newTransaction = new Transaction(); // Object for new transaction
        private bool showModal = false; // Flag for showing or hiding the modal

        // These fields will hold the total values for inflows, outflows, and debts
        private decimal totalIncome;
        private decimal totalExpense;
        private decimal totalDebt;

        // A list of transactions to be displayed
        private List<Transaction> transactions = new List<Transaction>()
        {
            new Transaction { Description = "Grocery Shopping", Date = DateTime.Parse("2024-12-25"), Amount = 150, Type = "Expense" },
            new Transaction { Description = "Freelance Payment", Date = DateTime.Parse("2024-12-24"), Amount = 500, Type = "Income" },
            new Transaction { Description = "Borrowed from Someone", Date = DateTime.Parse("2024-12-22"), Amount = 300, Type = "Debt" }
        };

        // This method is called when the component is initialized
        protected override void OnInitialized()
        {
            CalculateTotals();
        }

        // Method to calculate totals for income, expense, and debt
        private void CalculateTotals()
        {
            totalIncome = transactions
                .Where(t => t.Type == "Income")
                .Sum(t => t.Amount);

            totalExpense = transactions
                .Where(t => t.Type == "Expense")
                .Sum(t => t.Amount);

            totalDebt = transactions
                .Where(t => t.Type == "Debt")
                .Sum(t => t.Amount);
        }

        // Method to open the "Add Transaction" modal
        private void OpenModal()
        {
            newTransaction = new Transaction();
            newTransaction.Date = DateTime.Now;
            showModal = true;
        }

        // Method to close the modal
        private void CloseModal()
        {
            showModal = false;
        }

        // Method to add a new transaction to the list
        private void AddTransaction()
        {
            if (newTransaction != null && !string.IsNullOrWhiteSpace(newTransaction.Description))
            {
                transactions.Add(new Transaction
                {
                    Description = newTransaction.Description,
                    Date = newTransaction.Date == default ? DateTime.Now : newTransaction.Date,
                    Amount = newTransaction.Amount,
                    Type = newTransaction.Type
                });

                CalculateTotals(); // Update totals after adding a new transaction
            }

            CloseModal();
        }
    }
}
