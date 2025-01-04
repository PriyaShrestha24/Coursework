using Coursework.Model;

namespace Coursework.Components.Pages
{

    public partial class DebtPage
    {

        // Property to hold error messages
        private string? ErrorMessage;

        // Property to bind data for the tag being added
        public Debt Debts { get; set; } = new();
        private List<Debt> debts;

        protected override void OnInitialized()
        {
            debts = DebtService.GetDebts(); // Get all tags when the component is initialized
        }
        // Event handler to register tags

        public async Task HandleDelete(Guid debtId)
        {
            try
            {
                DebtService.DeleteDebt(debtId); // Call the service to delete the tag
                debts = DebtService.GetDebts(); // Refresh the list of tags
                ErrorMessage = null;
            }
            catch (Exception ex)
            {
                ErrorMessage = "An error occurred while deleting the tag.";
                Console.WriteLine(ex);
            }
        }
        public async void HandleRegister()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Debts.DebtName))
                {
                    ErrorMessage = "Debt Name is required.";
                    return;
                }
                DebtService.AddDebt(Debts);
                debts = DebtService.GetDebts(); // Refresh the list of tags

                // Reset the form
                Debts = new Debt();
                ErrorMessage = null;
            }
            catch (Exception ex)
            {
                ErrorMessage = "An error occurred while registering the tag.";
                Console.WriteLine(ex);
            }

        }

    }
}






