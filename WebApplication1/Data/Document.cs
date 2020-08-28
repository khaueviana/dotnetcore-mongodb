using System;
using MongoDB.Bson;

namespace WebApplication1.Data
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}