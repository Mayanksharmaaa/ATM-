using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.DAL
{
    public class AccountDAL
    {
        public string ConString = "Data Source=(local); database = ATM;Integrated Security=True";
        DataTable dt = new DataTable();
        public DataTable Read(string cardNumber)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConString;
            if (ConnectionState.Closed == con.State)
                con.Open();
            SqlCommand cmd = new SqlCommand("select * from Account where CardNumber='" + cardNumber + "'", con);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                return dt;
            }
            catch
            {
                throw;
            }
        }
        public void Excecute(string query)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConString;
            if (ConnectionState.Closed == con.State)
                con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                throw;
            }
        }
        public bool ValidatePIN(string cardNumber, int atmPIN)
        {
            var dt = Read(cardNumber);
            DataRow dr = dt.Rows[0];
            var pin = Convert.ToInt32(dr["PIN"]);
            if (pin == atmPIN)
                return true;
            return false;
        }

        public bool ValidateCardNumber(string cardNumber)
        {
            var dt = Read(cardNumber);
            if (dt.Rows.Count == 0)
                return false;
            return true;
        }

        public float GetAccountBalance(string cardNumber)
        {
            var dt = Read(cardNumber);
            DataRow dr = dt.Rows[0];
            var amount = float.Parse(dr["Balance"].ToString());
            return amount;
        }

        public void ChangePIN(string cardNumber, int firstPin)
        {
            string query = "UPDATE ACCOUNT set PIN='" + firstPin + "' where cardNUmber='" + cardNumber + "'";
            Excecute(query);
        }

        public string WithDrawalAmount(string cardNumber, float amount, out float accountBalanace)
        {
            var dt = Read(cardNumber);
            DataRow dr = dt.Rows[0];
            var balance = float.Parse(dr["Balance"].ToString());
            accountBalanace = balance;
            if (accountBalanace > balance)
                return "Balance is low";
            balance = balance - amount;
            string query = "UPDATE ACCOUNT set Balance='" + balance + "' where cardNUmber='" + cardNumber + "'";
            accountBalanace = balance;
            Excecute(query);
            return "";
        }

    }
}
