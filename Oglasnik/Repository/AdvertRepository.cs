using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Common;
using DAL;
using AutoMapper;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Http;
using Models.Common;
using Oglasnik.Common;

namespace Repository
{
    public class AdvertRepository : IAdvertRepository
    {
        private static readonly string myConnectionString = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
        private static readonly SqlConnection myConnection = new SqlConnection(myConnectionString);
        private static SqlDataReader reader;

        private readonly IMapper mapper;

        public AdvertRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<List<IAdvert>> AllAdverts(ISortingAdverts howToSort, IFilteringAdverts howToFilter, IPaging advertPaging)
        {
            List<AdvertEntity> adverts = new List<AdvertEntity>();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * FROM Advert ";
            if (howToFilter.HowToFilter() != "")
            {
                sqlCmd.CommandText += howToFilter.HowToFilter();
            }
            if (howToSort.Sort())
            {
                sqlCmd.CommandText += " ORDER BY " + howToSort.SortBy + " " + howToSort.SortOrder;
            }
            if (advertPaging == null)
            {
                sqlCmd.CommandText += "";
            }
            else
            {
                if (howToSort.SortBy != "")
                    if (advertPaging.DataPerPage != 0 && advertPaging.Page != 0)
                    {
                        sqlCmd.CommandText += " OFFSET " + advertPaging.DataPerPage * (advertPaging.Page - 1) + " ROWS FETCH NEXT " + advertPaging.DataPerPage + " ROWS ONLY ";
                    }
            }
            try
            {
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                reader = sqlCmd.ExecuteReader();
                AdvertEntity advert = null;
                while (reader.Read())
                {
                    advert = new AdvertEntity();
                    advert.AdvertID = Convert.ToInt32(reader.GetValue(0));
                    advert.Title = reader.GetValue(1).ToString();
                    advert.Price = Convert.ToInt32(reader.GetValue(2));
                    advert.Condition = reader.GetValue(3).ToString();
                    advert.Description = reader.GetValue(4).ToString();
                    advert.CategoryID = Convert.ToInt32(reader.GetValue(5));
                    advert.DeliveryID = Convert.ToInt32(reader.GetValue(6));
                    advert.UserID = Convert.ToInt32(reader.GetValue(7));
                    adverts.Add(advert);
                }
            }
            finally
            {
                myConnection.Close();
            }

            await Task.Delay(20);
            return mapper.Map<List<IAdvert>>(adverts);

        }

        public async Task<IAdvert> AdvertById(int id)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * FROM Advert WHERE AdvertID=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            AdvertEntity advert = null;
            while (reader.Read())
            {
                advert = new AdvertEntity();
                advert.AdvertID = Convert.ToInt32(reader.GetValue(0));
                advert.CategoryID = Convert.ToInt32(reader.GetValue(5));
                advert.Title = reader.GetValue(1).ToString();
                advert.Price = Convert.ToInt32(reader.GetValue(2));
                advert.Condition = reader.GetValue(3).ToString();
                advert.Description = reader.GetValue(4).ToString();
                advert.DeliveryID = Convert.ToInt32(reader.GetValue(6));
                advert.UserID = Convert.ToInt32(reader.GetValue(7));
            }
            myConnection.Close();
            await Task.Delay(20);
            return mapper.Map<IAdvert>(advert);
        }
        public async Task AddAdvert([FromBody] IAdvert advert)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO Advert(AdvertID, Title, Price, Condition, Description, CategoryID, DeliveryID, UserID) " +
                "VALUES(@AdvertID, @Title, @Price, @Condition, @Description, @CategoryID, @DeliveryID, @UserID); ";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            sqlCmd.Parameters.AddWithValue("@AdvertID", advert.AdvertID);
            sqlCmd.Parameters.AddWithValue("@Title", advert.Title);
            sqlCmd.Parameters.AddWithValue("@Price", advert.Price);
            sqlCmd.Parameters.AddWithValue("@Condition", advert.Condition);
            sqlCmd.Parameters.AddWithValue("@Description", advert.Description);
            sqlCmd.Parameters.AddWithValue("@CategoryID", advert.CategoryID);
            sqlCmd.Parameters.AddWithValue("@DeliveryID", advert.DeliveryID);
            sqlCmd.Parameters.AddWithValue("@UserID", advert.UserID);
            await Task.Delay(20);
            sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }
        public async Task UpdateAnAdvert(int id, [FromBody] IAdvert advert)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE Advert SET  Title = @Title, Price= @Price, Condition = @Condition, Description = @Description, CategoryID = @CategoryID," +
                " DeliveryID = @DeliveryID WHERE AdvertID=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            
            sqlCmd.Parameters.AddWithValue("@Title", advert.Title);
            sqlCmd.Parameters.AddWithValue("@Price", advert.Price);
            sqlCmd.Parameters.AddWithValue("@Condition", advert.Condition);
            sqlCmd.Parameters.AddWithValue("@Description", advert.Description);
            sqlCmd.Parameters.AddWithValue("@Category", advert.CategoryID);
            sqlCmd.Parameters.AddWithValue("@DeliveryID", advert.DeliveryID);
            await Task.Delay(20);
            sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }
        public async Task DeleteAnAdvert(int id)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "DELETE FROM Advert WHERE AdvertID=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            await Task.Delay(20);
            sqlCmd.ExecuteReader();
            myConnection.Close();
        }
    }
}
