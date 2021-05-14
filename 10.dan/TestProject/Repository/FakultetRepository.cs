using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Threading.Tasks;
using Faks.Repository.Common;
using MyModels;
using FakultetInterface;



namespace Faks.Repository
{
    public class FakultetRepository : IFakultetRepository
    {
        private static readonly string myConnectionString = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
        private static readonly SqlConnection Connection = new SqlConnection(myConnectionString);
        private static SqlDataReader reader;

        public async Task<List<IFakultet>> GetAllFakultet()
        {
            //Get metoda
            SqlCommand sqlCmd = new SqlCommand("SELECT FakultetID AS \"ID\", Ime AS \"Ime fakulteta\" FROM Fakultet", Connection);

            await Connection.OpenAsync();
            reader = sqlCmd.ExecuteReader();
            IFakultet fakultet = null;
            List<IFakultet> fakultetList = new List<IFakultet>();
            while (reader.Read())
            {
                fakultet = new Fakultet();
                fakultet.FakultetID = Convert.ToInt32(reader.GetValue(0));
                fakultet.Ime = reader.GetValue(1).ToString();
                fakultetList.Add(fakultet);
            }

            Connection.Close();
            return fakultetList;
        }

        public async Task<IFakultet> GetFakultet(int id)
        {
            //Get by ID metoda
            SqlCommand sqlCmd = new SqlCommand("SELECT FakultetID AS \"ID\", Ime AS \"Ime fakulteta\" FROM Fakultet WHERE FakultetID =" + id + "", Connection);

            await Connection.OpenAsync();
            reader = sqlCmd.ExecuteReader();
            IFakultet fakultet = null;
            while (reader.Read())
            {
                fakultet = new Fakultet();
                fakultet.FakultetID = Convert.ToInt32(reader.GetValue(0));
                fakultet.Ime = reader.GetValue(1).ToString();
            }
            Connection.Close();

            return fakultet;
        }
        public async Task AddFakultet(IFakultet fakultet)
        {
            //Post metoda
            SqlCommand sqlCmd = new SqlCommand("INSERT INTO Fakultet (FakultetID, Ime) VALUES (@FakultetID, @Ime);", Connection);

            sqlCmd.Parameters.AddWithValue("@FakultetID", fakultet.FakultetID);
            sqlCmd.Parameters.AddWithValue("@Ime", fakultet.Ime);

            await Connection.OpenAsync();
            sqlCmd.ExecuteNonQuery();
            Connection.Close();
        }

        public async Task UpdateFakultet(int id, IFakultet fakultet)
        {
            //Put metoda
            SqlCommand sqlCmd = new SqlCommand("UPDATE Fakultet SET FakultetID = @FakultetID, Ime = @Ime WHERE FakultetID =" + id + ";", Connection);

            await Connection.OpenAsync();
            sqlCmd.Parameters.AddWithValue("@FakultetID", fakultet.FakultetID);
            sqlCmd.Parameters.AddWithValue("@Ime", fakultet.Ime);
            await sqlCmd.ExecuteNonQueryAsync();
            Connection.Close();

            return;
        }

        public async Task DeleteFakultet(int id)
        {

            SqlCommand sqlCmd = new SqlCommand("DELETE FROM Fakultet WHERE FakultetID=" + id + "", Connection);

            await Connection.OpenAsync();
            SqlDataReader reader = await sqlCmd.ExecuteReaderAsync();
            Connection.Close();

            return;
        }
    }
}
