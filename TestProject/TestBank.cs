using BankProject;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class TestBank
    {
        [Theory]
        [InlineData(2024, 04, 24, 12, 00, true)]
        [InlineData(2024, 04, 24, 15, 00, false)]
        public void TestOpeningHours(int y, int m, int d, int h, int min, bool isOpen)
        {
            var moqTime = new Mock<IDateTimeService>();
            moqTime.Setup(t => t.Now).Returns(new DateTime(y, m, d, h, min, 0));

            var bank = new Bank("TESTOWY", moqTime.Object);

            Assert.True(bank.IsNowOpen == isOpen);
        }
    }
}
