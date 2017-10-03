using System;
using System.Data.SqlClient;

namespace PurchaseList.Models
{
    public static class DbService
    {

        #region Private Procedures

        private static bool UserExists(string email)
        {
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Email=@mail", con))
                {
                    cmd.Parameters.AddWithValue("@mail", email);

                    con.Open();

                    return ((int)cmd.ExecuteScalar()) > 0;
                }
            }
        }

        #endregion

        public static bool AddUser(User u)
        {
            if (UserExists(u.Email))
            {
                throw new AccessViolationException("User with this email is already registered");
            }

            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Users VALUES(@name, @surname, @country, @age, @email)", con))
                {

                    cmd.Parameters.AddWithValue("@name", u.Name);
                    cmd.Parameters.AddWithValue("@surname", u.Surname);
                    cmd.Parameters.AddWithValue("@country", u.Country);
                    cmd.Parameters.AddWithValue("@age", u.Age);
                    cmd.Parameters.AddWithValue("@email", u.Email);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }
    }
}
