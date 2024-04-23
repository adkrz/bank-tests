using BankProject;
using Moq;

namespace TestProject
{
    public class TestAccounts
    {
        private readonly IBank _mockBank;
        private readonly ILogger _mockLogger;
        public TestAccounts()
        { 
            var moqBank = new Mock<IBank>();
            moqBank.Setup(bank => bank.GetName()).Returns(() => "bank1");
            _mockBank = moqBank.Object;

            _mockLogger = new Mock<ILogger>().Object;
        }

        [Fact]
        public void TestPrintAccount()
        {
            // Arrange
            var acc = new BankAccount("TEST", 1.23);
            acc.Bank = _mockBank;

            // Act
            var str = acc.ToString();

            // Assert
            Assert.Equal("Bank bank1: TEST: 1.23", str); // . czy , -> oto jest pytanie ;)
        }

        [Fact]
        public void TestAccountDeposit()
        {
            // Arrange
            var acc = new BankAccount("TEST", 1);
            acc.Bank = _mockBank;


            // Act
            acc.Deposit(2, _mockLogger);

            // Assert
            Assert.Equal(3, acc.Balance);
        }

        [Theory]
        [InlineData(10, false)]
        [InlineData(7, false)]
        [InlineData(11, true)]
        public void TestAccountWithdraw(double amount, bool expectError)
        {
            // Arrange
            var acc = new BankAccount("TEST", 10);
            acc.Bank = _mockBank;


            // Act/assert
            if (expectError)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => acc.Withdraw(amount, _mockLogger));
            }
            else
            { 
                acc.Withdraw(amount, _mockLogger);
                Assert.Equal(10 - amount, acc.Balance);
            }
        }

        [Fact]
        public void TestAccountTransfer()
        {
            // Arrange
            var acc1 = new BankAccount("TEST1", 0.1);
            acc1.Bank = _mockBank;
            var acc2 = new BankAccount("TEST2", 0.2);
            acc2.Bank = _mockBank;

            // Act
            acc2.Transfer(acc1, 0.2, _mockLogger);

            // Assert
            Assert.Equal(0.3, acc1.Balance); // a co tu sie stalo? :P

            // TODO: znalezc blad w logice TRANSFER, napisac regression testa i naprawic
        }
    }
}