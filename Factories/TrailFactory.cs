using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using LostInTheWoods.Models;
using Microsoft.Extensions.Options;

namespace LostInTheWoods.Factory
{
    public class TrailFactory : IFactory<Trail>
    {
        private readonly IOptions<MySqlOptions> MySqlConfig;

        public TrailFactory()
        {
        }

        public TrailFactory(IOptions<MySqlOptions> config)
        {
            MySqlConfig = config;
        }
        internal IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(MySqlConfig.Value.ConnectionString);
            }
        }
        public void AddTrail(Trail t)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "INSERT INTO trails (Name, Description, Length, Elevation, Latitude, Longitude) VALUES (@Name, @Description, @Length, @Elevation, @Latitude, @Longitude)";
                dbConnection.Open();
                dbConnection.Execute(query, t);
            }
        }

        public IEnumerable<Trail> GetAllTrails()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "SELECT * FROM trails";
                dbConnection.Open();
                return dbConnection.Query<Trail>(query).ToList();
            }
        }
    }
}