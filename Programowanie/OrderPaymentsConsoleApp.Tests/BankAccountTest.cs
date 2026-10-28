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

        [Theory]
        [InlineData(0, 15, 15)]

        public void Deposit_PositiveAmount_AmountAddToDeposit(decimal startBalance, decimal depositAmount, decimal expectedBalance)
        {
            //arrange
            BankAccount bankAccount = new BankAccount(startBalance);

            //act
            bankAccount.Deposit(depositAmount);

            //assert
            Assert.Equal(expectedBalance, bankAccount.Balance);
        }

        [Theory]
        [InlineData(-1)]
        public void Deposit_NegativeAmount_ThrowExpection(decimal negativeDepositAmmount)
        {
            //arrange
            BankAccount bankAccount = new BankAccount(0);

            //act 
            Action action = () => { bankAccount.Deposit(negativeDepositAmmount); };

            //assert
            Assert.Throws<ArgumentOutOfRangeException>(action);

        }

        [Theory]
        [InlineData(15, 15, 0)]

        public void TryWithdraw_positiveAmmount_WithdrawMoney(decimal startBalance, decimal withDrawAmmount, decimal expectedBalanceAfterWithdraw)
        {
            //arrange
            BankAccount bankAccount = new BankAccount(startBalance);

            //act
            bankAccount.TryWithdraw(withDrawAmmount);

            //assert
            Assert.Equal(bankAccount.Balance, expectedBalanceAfterWithdraw);
        }

        [Theory]
        [InlineData(-1)]

        public void TryWithdraw_NegativeAmmountToWithdraw_ThrowException(decimal negativeAmountToWithdraw )
        {
            //arrange
            BankAccount bankAccount = new BankAccount(0);

            //act
            Action action = () => { bankAccount.TryWithdraw(negativeAmountToWithdraw); };

            //assert
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Theory]
        [InlineData(0,1)]

        public void TryWithDraw_WithdrowAmmountBiggerThanBalance_ReturnFalse(decimal bankAccBalance, decimal AmmountToWithdraw)
        {
            //arrange
            BankAccount bankAccount = new BankAccount(bankAccBalance);

            //act
           bool resoult =  bankAccount.TryWithdraw(AmmountToWithdraw);

            //assert
            Assert.False(resoult);
        }
    } 
}
