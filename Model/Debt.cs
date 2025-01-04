using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Model
{
    public class Debt
    {
        public Guid DebtID { get; set; } = Guid.NewGuid();
        public string DebtName { get; set; }

        public int DebtAmount { get; set; }

        public string DebtStatus { get; set; }

        public DateTime DebtDate { get; set; }
    }
}
