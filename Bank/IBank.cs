using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public interface IBank
    {
        public string GetName();
        public double TotalMoney { get; }

        public bool IsNowOpen { get; }
    }
}
