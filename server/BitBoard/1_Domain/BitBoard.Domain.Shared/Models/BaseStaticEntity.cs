using System;

namespace BitBoard.Domain.Shared.Models
{
    public class BaseStaticEntity<T> : BaseEntity
    {
        public string Type = typeof(T).Name;
        public string Partition => this.Type;

        public BaseStaticEntity() : base() { }
    }
}