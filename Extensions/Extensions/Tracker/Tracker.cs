using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace Extensions.Tracker
{
    public class Tracker<T> where T : class
    {
        private List<Object<T>> objects;
        public Tracker()
        {
            objects = new List<Object<T>>();
        }
        public Tracker(string content)
        {
            objects = new List<Object<T>>();
            objects = JsonSerializer.Deserialize<List<Object<T>>>(content);
        }

        public string Save()
        {
            return JsonSerializer.Serialize(objects);
        }
        public void Upload(string content)
        {
            objects = JsonSerializer.Deserialize<List<Object<T>>>(content);
        }

        public void Clear()
        {
            objects.Clear();
        }

        public void Add(Object<T> element)
        {
            if (element == null)
                throw new NullReferenceException(nameof(element));
            if (objects == null)
                throw new NullReferenceException(nameof(objects));
            objects.Add(element);
        }
        public void Remove(Object<T> element)
        {
            if (element == null)
                throw new NullReferenceException(nameof(element));
            if (objects == null)
                throw new NullReferenceException(nameof(objects));
            objects.Remove(element);
        }

        public async void ImportFromFile(string filePath)
        {
            using var sr = new StreamReader(filePath);
            Clear();
            objects = JsonSerializer.Deserialize<List<Object<T>>>(await sr.ReadToEndAsync());
            sr.Close();
            sr.Dispose();
        }
        public void ExportToFile(string path, string fileName)
        {
            using var sw = new StreamWriter(path + fileName);
            sw.WriteAsync(JsonSerializer.Serialize(objects));
            sw.Close();
            sw.Dispose();
        }
        public Object<T> GetFirstElement() => objects.FirstOrDefault();
        public Object<T> GetLastElement() => objects.LastOrDefault();
        public List<Object<T>> GetAllElements() => objects;
    }
}