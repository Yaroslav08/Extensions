using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Extensions
{
    public interface IEntityBase<T> where T: IComparable<T>
    {
        public T Id { get; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public string CreatedFromIP { get; set; }


        public DateTime? UpdatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public string UpdatedFromIP { get; set; }
    }

    public class EntityBase<T> : IEntityBase<T> where T : IComparable<T>
    {
        public T Id { get; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string CreatedBy { get; set; }

        public string CreatedFromIP { get; set; }


        public DateTime? UpdatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public string UpdatedFromIP { get; set; }
    }
}