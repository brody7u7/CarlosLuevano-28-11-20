using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ToDoListBertoni.Models;

namespace ToDoListBertoni.Services.Data
{
    public class DBContext
    {
        private const string DabaBaseName = "todo.db";
        private static readonly object DBLock = new object();

        private readonly SQLiteAsyncConnection _connection;

        public DBContext()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), DabaBaseName);
            _connection = File.Exists(path) ? new SQLiteAsyncConnection(path, SQLiteOpenFlags.ReadWrite) :
                new SQLiteAsyncConnection(path, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite);

            CreateTables();
        }

        private void CreateTables()
        {
            _connection.CreateTableAsync<ToDoItem>();
        }

        public Task<List<ToDoItem>> GetToDoItemsAsync()
        {
            return _connection.Table<ToDoItem>().ToListAsync();
        }

        public Task<ToDoItem> GetToDoItemAsync(int id)
        {
            return _connection.Table<ToDoItem>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveToDoItemAsync(ToDoItem item)
        {
            lock (DBLock)
            {
                if (item.Id != 0)
                {
                    return _connection.UpdateAsync(item);
                }
                else
                {
                    return _connection.InsertAsync(item);
                }
            }
        }

        public Task<int> DeleteToDoItemAsync(ToDoItem item)
        {
            return _connection.DeleteAsync(item);
        }
    }
}
