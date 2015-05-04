﻿using MongoDB.Bson;
using MongoDB.Driver;
using Spark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Search.Mongo
{
    public class MongoIndexStore
    {
        MongoDatabase database;
        public MongoCollection<BsonDocument> Collection;

        public MongoIndexStore(MongoDatabase database)
        {
            this.database = database;
            this.Collection = database.GetCollection(Spark.Search.Mongo.Config.MONGOINDEXCOLLECTION);
        }

        public void Save(BsonDocument document)
        {
            string keyvalue = document.GetValue(InternalField.ID).ToString();
            IMongoQuery query = MongoDB.Driver.Builders.Query.EQ(InternalField.ID, keyvalue);

            // todo: should use Update: collection.Update();
            Collection.Remove(query);
            Collection.Save(document);
        }

        public void Delete(Interaction entry)
        {
            string location = entry.Key.ToRelativeUri().ToString();
            string id = entry.Key.RelativePath();
            IMongoQuery query = MongoDB.Driver.Builders.Query.EQ(InternalField.ID, id);
            Collection.Remove(query);
        }

        public void Clean()
        {
            Collection.RemoveAll();
        }

    }
}
