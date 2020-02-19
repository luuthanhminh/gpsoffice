using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gpsoffice.Core.Data;
using Realms;

namespace gpsoffice.Core.Repositories
{
    public abstract class BaseRepository<T> where T : RealmObject
    {
        public const int SCHEMA_VERSION = 1;

        protected Realm _realmInstance;

        public BaseRepository()
        {
            var config = new RealmConfiguration() { SchemaVersion = SCHEMA_VERSION };
            _realmInstance = Realm.GetInstance(config);
        }

        public List<T> GetAll()
        {
            return _realmInstance.All<T>().ToList();
        }

        public T Get(string id)
        {
            return _realmInstance.Find<T>(id);
        }

        public void Add(T item)
        {
            _realmInstance.Write(() =>
            {
                _realmInstance.Add(item);
            });
        }

        public Task AddItems(IList<T> items)
        {
            return _realmInstance.WriteAsync((r) =>
             {
                 foreach (var item in items)
                 {
                     r.Add(item);
                 }
             });

        }

        public abstract Task AddOrUpdateItems(IList<T> items);


        public void Update(T item)
        {
            _realmInstance.Write(() => _realmInstance.Add(item, update: true));
        }

        public void Delete(T item)
        {
            using (var trans = _realmInstance.BeginWrite())
            {
                _realmInstance.Remove(item);
                trans.Commit();
            }
        }
    }
}
