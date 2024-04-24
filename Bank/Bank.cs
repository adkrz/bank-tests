using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public class Bank : IBank
    {
        private string _name { get; }
        public IDateTimeService _dateTimeService { get; }
        private List<BankAccount> Accounts { get; }
        public Bank(string name, IDateTimeService dateTimeService)
        {
            _name = name;
            _dateTimeService = dateTimeService;
            Accounts = new List<BankAccount>();
        }

        public string GetName() => _name;
        public double TotalMoney => Accounts.Sum(a => a.Balance);

        public bool IsNowOpen 
        {
            get { 
                var now = _dateTimeService.Now;
                return now.DayOfWeek >= DayOfWeek.Monday && now.DayOfWeek <= DayOfWeek.Friday && now.Hour >= 7 && now.Hour < 15;
            }
        }

        public void AddAccount(BankAccount a) { 
            a.Bank = this;
            Accounts.Add(a);
        }

        public override string ToString()
        {
            return string.Join("\n", Accounts.Select(a => a.ToString())) + $"\n\tTotal deposits: {TotalMoney}";
        }
    }
}
