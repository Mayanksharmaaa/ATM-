using ATM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.BAL
{
    public class AccountBAL
    {
        public bool ValidatePIN(string cardNumber, int atmPIN)
        {
            AccountDAL transactionDAL = new AccountDAL();
            return transactionDAL.ValidatePIN(cardNumber, atmPIN);
        }

        public bool ValidateCardNumber(string cardNumber)
        {
            AccountDAL transactionDAL = new AccountDAL();
            return transactionDAL.ValidateCardNumber(cardNumber);
        }

        public float GetAccountBalance(string cardNumber)
        {
            AccountDAL transactionDAL = new AccountDAL();
            return transactionDAL.GetAccountBalance(cardNumber);
        }

        public string WithDrawalAmount(string cardNumber, float amount, out float accountBalanace)
        {
            AccountDAL transactionDAL = new AccountDAL();
            return transactionDAL.WithDrawalAmount(cardNumber, amount, out accountBalanace);
        }

        public void ChangePIN(string cardNumber, int firstPin)
        {
            AccountDAL transactionDAL = new AccountDAL();
            transactionDAL.ChangePIN(cardNumber, firstPin);
        }
    }
}
