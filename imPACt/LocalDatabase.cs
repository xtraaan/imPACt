using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using imPACt.Tables;
using System.Threading.Tasks;
using System.Linq;
using SQLite;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Extensions;

namespace imPACt
{
    public class LocalDatabase
    {
        readonly SQLiteAsyncConnection _database;

        //Creating path and creating Table for database
        public LocalDatabase(string path)
        {
            _database = new SQLiteAsyncConnection(path);
            _database.CreateTableAsync<RegisterUserTable>().Wait();
            _database.CreateTableAsync<Events>().Wait();

            
        }


        //Gets Specific user through Unique ID
        public Task<RegisterUserTable> GetUserAsync(int id)
        {
            return _database.GetAsync<RegisterUserTable>(id);
           // return _database.Table<RegisterUserTable>().ElementAtAsync(id);
        }

        //Recieves List of All Users
        public Task<List<RegisterUserTable>> GetUsersAsync()
        {
            return _database.Table<RegisterUserTable>().ToListAsync();
        }

        //Add user to database after completion or creation
        public Task<int> SaveUserAsync(RegisterUserTable user)
        {
            return _database.InsertAsync(user);
        }

        //Saving Event
        public Task<int> SaveEventAsync(Events user)
        {
            return _database.InsertAsync(user);
        }

        public Task<List<Events>> GetEventAsync()
        {
            return _database.Table<Events>().ToListAsync();
        }

        // Get Match list
        public List<RegisterUserTable> GetMatches()
        {
            return App.currentUser.Matches.ToList();
        }

        public Task<int> UpdateUser()
        {
            
            return _database.UpdateAsync(App.currentUser);
        }

        public Task<RegisterUserTable> QueryUserAsync(string username, string pass)
        {
            return _database.Table<RegisterUserTable>().Where(u => u.Username.Equals(username) && u.Password.Equals(pass)).FirstOrDefaultAsync();
        }



    }

    

}
