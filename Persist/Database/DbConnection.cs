using Microsoft.Extensions.Configuration;
using Persist.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persist.Database
{
    public class DbConnection : IConnection
    {
        protected readonly SQLiteAsyncConnection db;
        public DbConnection(IConfiguration config)
        {
            string dataDir = config.GetValue("Persist:DataFolder", "./data"); // TODO make sure folder location
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }
            string dbFileName = config.GetValue("Persist:DbFileName", "database.db");
            string databasePath = Path.Combine(dataDir, dbFileName);
            db = new SQLiteAsyncConnection(databasePath);
        }


        public async Task CreateDatabase(Type[] tables)
        {
            await db.CreateTablesAsync(CreateFlags.ImplicitPK | CreateFlags.AutoIncPK, tables);
            // TODO: how to create indexes?
        }

        public async Task<TModel> Get<TModel>(int id) where TModel : IPersistModel, new()
        {
            TModel record = await db.GetAsync<TModel>(id);
            return record;
        }

        public async Task<List<TModel>> GetAll<TModel>() where TModel : IPersistModel, new()
        {
            AsyncTableQuery<TModel> query = db.Table<TModel>(); // TODO how to return queriable
            return await query.ToListAsync();
        }

        public async Task<TModel> Insert<TModel>(TModel record) where TModel : IPersistModel, new()
        {
            await db.InsertAsync(record);
            return record;
        }

        public async Task<TModel> Update<TModel>(TModel record) where TModel : IPersistModel, new()
        {
            await db.UpdateAsync(record);
            return record;
        }

        public async Task<TModel> Delete<TModel>(TModel record) where TModel : IPersistModel, new()
        {
            await db.DeleteAsync<TModel>(record.Id);
            return record;
        }

        public async Task Delete<TModel>(int id) where TModel : IPersistModel, new()
        {
            await db.DeleteAsync<TModel>(id);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db?.CloseAsync().Wait();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}
