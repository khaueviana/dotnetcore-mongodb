using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Data
{
    public interface IDocument
    {
        [BsonId]
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        Guid Id { get; set; }

        DateTime CreatedAt { get; set; }
    }
}