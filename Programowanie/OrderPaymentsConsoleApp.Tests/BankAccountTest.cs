using System;
using System.Collections.Generic;
using System.Text;

namespace OrderPaymentsConsoleApp.Tests
{
    public class BankAccountTest
    {
        [Theory]
        [InlineData(15)]
        public void BankAccountTest_PositiveBalance_SetExpectedBankBalance(decimal initialBalance)
        {
            //arrange
            BankAccount bankAccount;

            //act
            bankAccount = new BankAccount(initialBalance);

            //assert
            Assert.Equal(initialBalance, bankAccount.Balance);
        }


        [Theory]
        [InlineData(-15)]

        public void BankAccount_NegativeBalance_ThrowExcepion(decimal initialBalance) 
        {
            //arrange
            BankAccount bankAccount;

            //act
            Action action = () => { new BankAccount(initialBalance); };

            //assert
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }
    }
}
