using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Model
{
    public class Tag
    {
        public Guid TagID { get; set; } = Guid.NewGuid();
        public string TagName { get; set; }
    }
}
