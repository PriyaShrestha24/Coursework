using Coursework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Service.Interface
{
    public interface IDebtService
    {
        void AddDebt(Debt debt);

        void DeleteDebt(Guid debtId);

        List<Debt> GetDebts();
    }
}
