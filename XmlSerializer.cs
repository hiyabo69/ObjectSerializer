using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;
using System.IO;

namespace Obysoft.Serializer
{
    public class XmlSerializer : IDisposable
    {
        private string _path;
        private SerializerType _stype;


        public XmlSerializer(string path, SerializerType stype)
        {
            _path = path;
            _stype = stype;
        }


        public void Serialize(object obj)
        {
            if (_stype == SerializerType.FILE)
            {
                System.Xml.Serialization.XmlSerializer xml = new System.Xml.Serialization.XmlSerializer(obj.GetType());
                using (Stream stream = File.Create(_path))
                {
                    xml.Serialize(stream, obj);
                }
            }
            else
            {
                if (!Directory.Exists(_path))
                    Directory.CreateDirectory(_path);
                String fileName = obj.GetType().Name;
                string fullPath = _path + $"/{fileName}.xml";
                System.Xml.Serialization.XmlSerializer xml = new System.Xml.Serialization.XmlSerializer(obj.GetType());
                using (Stream stream = File.Create(fullPath))
                {
                    xml.Serialize(stream, obj);
                }
            }
        }
        public T Deserialize<T>()
        {
            Object obj = null;
            if (_stype == SerializerType.FILE)
            {
                System.Xml.Serialization.XmlSerializer xml = new System.Xml.Serialization.XmlSerializer(typeof(T));
                using (Stream stream = File.OpenRead(_path))
                {
                    obj = xml.Deserialize(stream);
                }
            }
            else
            {
                if (Directory.Exists(_path))
                {
                    String fileName = typeof(T).Name;
                    string fullPath = _path + $"/{fileName}.xml";
                    System.Xml.Serialization.XmlSerializer xml = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    using (Stream stream = File.OpenRead(fullPath))
                    {
                        obj = xml.Deserialize(stream);
                    }
                }
            }
            return (T)obj;
        }



        public void Dispose()
        {
            _path = String.Empty;
        }

        public static XmlSerializer CreateFile(string path)
        {
            return new XmlSerializer(path, SerializerType.FILE);
        }
        public static XmlSerializer CreateDirectory(string path)
        {
            return new XmlSerializer(path, SerializerType.NAMEOBJECT);
        }
    }
}
