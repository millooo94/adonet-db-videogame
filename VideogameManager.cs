using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace adonet_db_videogame
{
    public class VideogameManager
    {
        string connStr;

        public VideogameManager(string connStr)
        {
            this.connStr = connStr;
        }

        public void AddVideogame(string name, string overview, DateOnly release_date, long software_house_id)
        {
            using var conn = new SqlConnection(connStr);

            try
            {
                conn.Open();
                var query = "INSERT INTO videogames (name, overview, release_date, software_house_id)" +
                            "VALUES ('@Name', '@Overview', '@ReleaseDate', @SoftwareHouseId)";

                DateTime dateTimeValue = dateOnlyValue.ToDateTime(DateTime.Now.TimeOfDay, DateTimeKind.Local);

                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Overview", overview);
                cmd.Parameters.AddWithValue("@ReleaseDate", release_date);
                cmd.Parameters.AddWithValue("@SoftwareHouseId", software_house_id);
                cmd.ExecuteNonQuery();
                Console.WriteLine("The videogame was successfully stored");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public Videogame GetVideogamebyId(long id)
        {
            using var conn = new SqlConnection(connStr);

            try
            {
                conn.Open();
                var query = "SELECT videogames.id, videogames.name, videogames.overview, videogames.release_date" +
                            "FROM videogames" +
                            "WHERE videogames.id = @id";

                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var idIdx = reader.GetOrdinal("id");
                    var _id = reader.GetInt64(0);
                    var nameIdx = reader.GetOrdinal("name");
                    var name = reader.GetString(1);
                    var overviewIdx = reader.GetOrdinal("overview");
                    var overview = reader.GetString(2);
                    var releaseDateIdx = reader.GetOrdinal("release_date");
                    var release_date = reader.GetDateTime(3);
                    var softwareHouseIdIdx = reader.GetOrdinal("software_house_id");
                    var software_house_id = reader.GetInt64(4);

                    var videogame = new Videogame(id, name, overview, release_date, software_house_id);
                }


            }
            catch (E)
            {

            }
        }

    }
}
