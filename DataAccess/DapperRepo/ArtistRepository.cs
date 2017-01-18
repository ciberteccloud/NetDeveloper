using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Models;
using System.Data;
using System.Transactions;

namespace DataAccess.DapperRepo
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
                var result = connection.QueryFirst<int>(query);
                return result;
            }
        }

        public Artist GetArtistById(int id)
        {
            var storeName = "dbo.ArtistById";
            using (var connection = new SqlConnection(_connectionString))
            {
                var artist = connection.Query<Artist>(storeName, new { artistId = 1 },
                                                      commandType: CommandType.StoredProcedure
                                                      ).SingleOrDefault();
                return artist;
            }
        }

        public IEnumerable<Artist> GetListArtist()
        {
            var storeName = "dbo.GetListOfArtist";
            var artistList = new List<Artist>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var artist = connection.Query<Artist>(storeName,
                                                      commandType: CommandType.StoredProcedure);
                return artist;
            }
        }
        public int InsertArtist(string name)
        {
            var storeName = "dbo.InsertArtist";
            using (var connection = new SqlConnection(_connectionString))
            {
                var artist = connection.Query<int>(storeName,
                                                   new { Name = name },
                                                   commandType: CommandType.StoredProcedure
                                                   )
                                                  .SingleOrDefault();
                return artist;
            }
        }

        public int InsertArtistByTransaction(string name)
        {
            var storeName = "dbo.InsertArtist";
            using (var connection = new SqlConnection(_connectionString))
            {
                int artistId = 0;
                using (var transaction = new TransactionScope())
                {

                    artistId = connection.Query<int>(storeName,
                                                 new { Name = name },
                                                 commandType: CommandType.StoredProcedure
                                                 )
                                                 .SingleOrDefault();
                    transaction.Complete();                    
                }
                return artistId;
            }
        }
        public int DeleteArtistById(int id)
        {
            var storeName = "dbo.DeleteArtist";
            using (var connection = new SqlConnection(_connectionString))
            {

                var artist = connection.Query<int>(storeName,
                                                   new { artistId = id },
                                                   commandType: CommandType.StoredProcedure)
                                                  .SingleOrDefault();
                return artist;
            }
        }
    }
}
