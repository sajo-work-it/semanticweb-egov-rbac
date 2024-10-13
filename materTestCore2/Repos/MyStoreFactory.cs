using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Semiodesk.Trinity;
using Semiodesk.Trinity.Store.Fuseki;

namespace materTestCore2.Repos
{
    public static class MyStoreFactory
    {
        static FusekiStoreProvider? provider;

        public static IStore GetStore()
        {
            string connectionString = "provider=fuseki;host=http://localhost:3030;dataset=EGOVDS";
            //string connectionString = "provider=fuseki;host=http://localhost:3030;dataset=draft-ontology";

            provider = new FusekiStoreProvider();
            StoreFactory.LoadProvider(provider);
            try
            {
                IStore Store = StoreFactory.CreateStore(connectionString);

                return Store;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private static Uri GetDefaultModelUri()
        {
            Uri defaultModelUri = new Uri("www.testmodel.com");

            return defaultModelUri;
        }



        public static IModel GetModel(IStore store = null, Uri modelUri = null)
        {
            if (modelUri == null)
            {
                modelUri = GetDefaultModelUri();
            }

            if (store == null)
                store = GetStore();

            if (store.ContainsModel(modelUri))
            {
                return store.GetModel(modelUri);
            }
            else
            {
                return store.CreateModel(modelUri);
            }
        }

    }
}
