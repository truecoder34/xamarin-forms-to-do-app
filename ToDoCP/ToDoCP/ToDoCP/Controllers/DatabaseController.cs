using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace ToDoCP.Data
{
    public class DatabaseController
    {
        readonly SQLiteAsyncConnection database;

        /*
         * Constructor 
         * Create connection with DB in ASYNC mode
         * And create DB table for Tasks
        */
        public DatabaseController(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<ToDoTask>().Wait();
        }

        // Get all TASKS from DB
        public Task<List<ToDoTask>> GetTasksAsync()
        {
            return database.Table<ToDoTask>().ToListAsync();
        }

        // Get all DONE tasks from DB
        public Task<List<ToDoTask>> GetTasksNotDoneAsync()
        {
            return database.Table<ToDoTask>().Where(b => b.Done == false).ToListAsync();
            // It can be done by QueryAsync . => Look at it
            // return database.QueryAsync<ToDoTask>("SELECT * FROM [ToDoTask] WHERE [DONE] == 0");
        }

        // Get current Item async
        public Task<ToDoTask> GetItemAsync(Guid id)
        {
            return database.Table<ToDoTask>().Where(b => b.NoteId == id).FirstOrDefaultAsync();
        }

        // Save item async
        // Use also for updating existing item
        public Task<int> SaveItemAsync(ToDoTask task)
        {
            if(task.NoteId != null)
            {
                return database.UpdateAsync(task);
            }
            else
            {
                return database.InsertAsync(task);
            }
        }

        //Delete item async
        public Task<int> DeleteItemAsync(ToDoTask task)
        {
            return database.DeleteAsync(task);
        }
    }
}
