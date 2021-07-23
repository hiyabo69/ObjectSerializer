using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Obysoft.Serializer
{
    public class BinarySerializer : IDisposable
    {
        private string _path;
        private SerializerType _stype;


        public BinarySerializer(string path,SerializerType stype)
        {
            _path = path;
            _stype = stype;
        }


        public void Serialize(object obj)
        {
            if (_stype == SerializerType.FILE)
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (Stream stream = File.Create(_path))
                {
                    bf.Serialize(stream, obj);
                }
            }
            else
            {
                if (!Directory.Exists(_path))
                    Directory.CreateDirectory(_path);
                String fileName = obj.GetType().Name;
                string fullPath = _path + $"/{fileName}.bin";
                BinaryFormatter bf = new BinaryFormatter();
                using (Stream stream = File.Create(fullPath))
                {
                    bf.Serialize(stream, obj);
                }
            }
        }
        public T Deserialize<T>()
        {
            Object obj = null;
            if (_stype == SerializerType.FILE)
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (Stream stream = File.OpenRead(_path))
                {
                    obj = bf.Deserialize(stream);
                }
            }
            else
            {
                if (Directory.Exists(_path))
                {
                    String fileName = typeof(T).Name;
                    string fullPath = _path + $"/{fileName}.bin";
                    BinaryFormatter bf = new BinaryFormatter();
                    using (Stream stream = File.OpenRead(fullPath))
                    {
                        obj = bf.Deserialize(stream);
                    }
                }
            }
            return (T)obj;
        }



        public void Dispose()
        {
            _path = String.Empty;
        }
        
        public static BinarySerializer CreateFile(string path)
        {
            return new BinarySerializer(path, SerializerType.FILE);
        }
        public static BinarySerializer CreateDirectory(string path)
        {
            return new BinarySerializer(path, SerializerType.NAMEOBJECT);
        }
    }
}
