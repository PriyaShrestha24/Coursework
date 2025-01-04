using Coursework.Model;

namespace Coursework.Components.Pages
{

    public partial class TagPage
    {

        // Property to hold error messages
        private string? ErrorMessage;

        // Property to bind data for the tag being added
        public Tag Tags { get; set; } = new();
        private List<Tag> tags;

        protected override void OnInitialized()
        {
            tags = TagService.GetTags(); // Get all tags when the component is initialized
        }
        // Event handler to register tags

        public async Task HandleDelete(Guid tagId)
        {
            try
            {
                TagService.DeleteTag(tagId); // Call the service to delete the tag
                tags = TagService.GetTags(); // Refresh the list of tags
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
                if (string.IsNullOrWhiteSpace(Tags.TagName))
                {
                    ErrorMessage = "Tag Name is required.";
                    return;
                }
                TagService.AddTag(Tags);
                tags = TagService.GetTags(); // Refresh the list of tags

                // Reset the form
                Tags = new Tag();
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






