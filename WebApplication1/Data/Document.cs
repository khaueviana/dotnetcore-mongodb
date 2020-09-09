using System;
using MongoDB.Bson;

namespace WebApplication1.Data
{
    public abstract class Document : IDocument
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}