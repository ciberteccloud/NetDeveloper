using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data.SqlClient;
using Models;
using System.Data;
using System.Transactions;

namespace DataAccess.DapperRepo
{
    public class PlaylistRepository
    {
        private readonly string _connectionString;
        public PlaylistRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Count()
        {
            var query = "SELECT Count(PlaylistId) FROM dbo.Playlist";
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.QueryFirst<int>(query);
                return result;
            }
        }

        public Playlist GetPlaylistById(int id)
        {
            var storeName = "dbo.PlaylistById";
            using (var connection = new SqlConnection(_connectionString))
            {
                var playlist = connection.Query<Playlist>(storeName, new { PlaylistId = 1 },
                                                      commandType: CommandType.StoredProcedure
                                                      ).SingleOrDefault();
                return playlist;
            }
        }

        public IEnumerable<Playlist> GetListPlaylist()
        {
            var storeName = "dbo.GetListOfPlaylist";
            var artistList = new List<Playlist>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var playlist = connection.Query<Playlist>(storeName,
                                                      commandType: CommandType.StoredProcedure);
                return playlist;
            }
        }
        public int InsertArtist(string name)
        {
            var storeName = "dbo.InsertPlaylist";
            using (var connection = new SqlConnection(_connectionString))
            {
                var playlistId = connection.Query<int>(storeName,
                                                   new { Name = name },
                                                   commandType: CommandType.StoredProcedure
                                                   )
                                                  .SingleOrDefault();
                return playlistId;
            }
        }

        public int InsertArtistByTransaction(string name)
        {
            var storeName = "dbo.InsertPlaylist";
            using (var connection = new SqlConnection(_connectionString))
            {
                int playlistId = 0;
                using (var transaction = new TransactionScope())
                {

                    playlistId = connection.Query<int>(storeName,
                                                 new { Name = name },
                                                 commandType: CommandType.StoredProcedure
                                                 )
                                                 .SingleOrDefault();
                    transaction.Complete();                    
                }
                return playlistId;
            }
        }
        public int DeletePlaylistById(int id)
        {
            var storeName = "dbo.DeletePlaylist";
            using (var connection = new SqlConnection(_connectionString))
            {

                var playlistId = connection.Query<int>(storeName,
                                                   new { playlistId = id },
                                                   commandType: CommandType.StoredProcedure)
                                                  .SingleOrDefault();
                return playlistId;
            }
        }
    }
}
