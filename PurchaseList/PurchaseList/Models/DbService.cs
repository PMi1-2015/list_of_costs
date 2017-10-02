using System.Data.SqlClient;

namespace PurchaseList.Models
{
    public static class DbService
    {
        public static bool AddUser(User u)
        {
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
