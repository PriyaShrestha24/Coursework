using Coursework.Model;
using Coursework.Abstraction;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using Coursework.Service.Interface;

namespace Coursework.Service
{
    public class TagService : TagBase, ITagService
    {

        private List<Tag> _tags;

        public TagService()
        {
            _tags = LoadTags();
        }

        public void AddTag(Tag tag)
        {
            if (!_tags.Any(u => u.TagName == tag.TagName))
            {
                if (tag.TagID == Guid.Empty)
                {
                    tag.TagID = Guid.NewGuid();
                }
                _tags.Add(new Tag { TagID = tag.TagID, TagName = tag.TagName });
                SaveTags(_tags);
            }
        }

        public void DeleteTag(Guid tagId)
        {
            var tag = _tags.FirstOrDefault(t => t.TagID == tagId);
            if (tag != null)
            {
                _tags.Remove(tag);
                SaveTags(_tags); // Save updated list to storage
            }
        }


        public List<Tag> GetTags()
        {
            return _tags; // Return the list of tags
        }

        private List<Tag> LoadTags()
        {
            // Load tags from persistent storage (e.g., a JSON file)
            try
            {
                var json = File.ReadAllText("tags.json");
                return JsonSerializer.Deserialize<List<Tag>>(json) ?? new List<Tag>();
            }
            catch
            {
                return new List<Tag>();
            }
        }

        private void SaveTags(List<Tag> tags)
        {
            // Save tags to persistent storage (e.g., a JSON file)
            var json = JsonSerializer.Serialize(tags);
            File.WriteAllText("tags.json", json);
        }
    }
}
