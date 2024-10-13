using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Semiodesk.Trinity;
namespace materTestCore2.Repos
{
    public class ResourceRepository<T> : IDisposable where T : Resource
    {
        #region Members
        protected IStore Store;
        protected IModel Model;
        protected bool EnableInferencing = false;
        #endregion

        #region Constructor
        public ResourceRepository(Uri modelUri = null)
        {
            Type typeParameterType = typeof(T);
            Store = MyStoreFactory.GetStore();
            Model = MyStoreFactory.GetModel(Store, modelUri);
        }
        #endregion

        #region Destructor
        ~ResourceRepository()
        {
            Dispose(false);
        }
        #endregion

        #region Methods

        public T AddNew(Uri uri)
        {
            if (!Model.ContainsResource(uri))
            {
                return Model.CreateResource<T>(uri);
            }
            else
                return null;
        }

        public T Add(T item)
        {
            //Model.Clear();
            if (!Model.ContainsResource(item.Uri))
            {
                return Model.AddResource<T>(item);
            }
            else
                return Model.GetResource<T>(item.Uri);
        }

        public IEnumerable<T> List()
        {
            return Model.GetResources<T>(EnableInferencing);
        }

        public void Remove(T item)
        {
            Model.DeleteResource(item.Uri);
        }

        public void Update(T item)
        {
            item.Commit();
        }

        public T FindByUri(Uri u)
        {
            if (Model.ContainsResource(u))
                return Model.GetResource<T>(u);

            return null;
        }

        public void Clear()
        {
            Model.Clear();
        }

        public void Dispose(bool safeToFreeManagedObject)
        {
            if (safeToFreeManagedObject)
            {
                if (Store != null)
                {
                    Store.Dispose();
                    Store = null;
                }
            }
        }
        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}
