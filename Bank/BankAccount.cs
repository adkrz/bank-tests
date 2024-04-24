using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;

        public IBank? Bank { get; set; }

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance; }
        }

        public void Withdraw(double amount, ILogger logger)
        {
            if (amount > m_balance)
            {
                logger.Error($"Insufficient funds on account: {this}");
                throw new ArgumentOutOfRangeException("amount");
            }
            logger.Info($"{this}: Withdraw {amount}");
            m_balance -= amount;
        }

        public void Deposit(double amount, ILogger logger)
        {
            logger.Info($"{this}: Deposit {amount}");
            m_balance += amount;
        }

        public void Transfer(BankAccount other, double amount, ILogger logger)
        {
            logger.Info($"Transfer from {this} to {other}, amount {amount}");
            // Fix: zla kolejnosc
            Withdraw(amount, logger);
            other.Deposit(amount, logger);
        }

        public override string ToString()
        {
            return $"Bank {Bank!.GetName()}: {m_customerName}: {m_balance.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}
