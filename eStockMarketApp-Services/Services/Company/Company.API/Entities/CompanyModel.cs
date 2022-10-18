using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.API.Entities
{
    public class CompanyModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Company_Code { get; set; }
        [BsonElement("CompanyName")]
        public string Company_Name { get; set; }
        public string Company_CEO { get; set; }
        public int Company_Turnover { get; set; }
        public string Company_Website { get; set; }
        public string Company_Listing { get; set; }
    }
}
