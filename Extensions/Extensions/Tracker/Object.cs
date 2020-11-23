using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Extensions.Tracker
{
    public class Object<T>
    {
        public DateTime CreatedAt { get; set; }
        public string ObjectId { get; set; }
        public List<Obj> Objs { get; set; }
        public T OldState { get; set; }
        public T NewState { get; set; }
    }
}