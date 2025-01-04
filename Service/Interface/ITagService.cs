using Coursework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Service.Interface
{
     public interface ITagService
    {
        void AddTag (Tag tag);

        void DeleteTag (Guid tagId);

        List<Tag> GetTags ();
    }
}
