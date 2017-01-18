using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.AdoNet
{
    public class ArtistRepository
    {
        private readonly string _connectionString;
        public ArtistRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public int Count()
        {
            var query = "SELECT Count(ArtistId) FROM dbo.Artist";
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(query, connection);
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        public Artist GetArtistById(int id)
        {           
            var storeName = "dbo.ArtistById";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(storeName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@artistId", SqlDbType.Int).Value = id;

                var reader = command.ExecuteReader();
                Artist artist = new Artist();
                while (reader.Read())
                {
                    artist.ArtistId = Convert.ToInt32(reader["ArtistId"]);
                    artist.Name = reader["Name"].ToString();
                }
                return artist;
            }
        }

        public IEnumerable<Artist> GetListArtist()
        {
            var storeName = "dbo.GetListOfArtist";
            var artistList = new List<Artist>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(storeName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };                

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    artistList.Add(new Artist
                    {
                        ArtistId = Convert.ToInt32(reader["ArtistId"]),
                        Name = reader["Name"].ToString()
                    });
                }
                return artistList;
            }
        }
        public int InsertArtist(string name)
        {
            var storeName = "dbo.InsertArtist";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(storeName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                return (int)command.ExecuteScalar(); ;
            }
        }

        public int InsertArtistByTransaction(string name)
        {
            var storeName = "dbo.InsertArtist";
            int result = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var sqlTransaction = connection.BeginTransaction();
                var command = new SqlCommand(storeName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Transaction = sqlTransaction;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                try
                {
                    result= (int)command.ExecuteScalar();
                    sqlTransaction.Commit();
                }
                catch (Exception)
                {
                    sqlTransaction.Rollback();
                    result = 0;
                }                
                return result;
            }
        }
        public int DeleteArtistById(int id)
        {
            var storeName = "dbo.DeleteArtist";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(storeName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@artistId", SqlDbType.Int).Value = id;                
                return (int)command.ExecuteScalar(); ;
            }
        }
    }
}
