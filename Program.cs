using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Obysoft.Serializer;

namespace SerializerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Binary Serialization

            SerializeData data = new SerializeData();
            
            //Serializar en un archivo especifico
            using(BinarySerializer bs = BinarySerializer.CreateFile("data.bin"))
            {
                bs.Serialize(data);
            }

            //Serializar en una carpeta depende del nombre del Objeto
            using (BinarySerializer bs = BinarySerializer.CreateDirectory("datas"))
            {
                bs.Serialize(data);
            }

            //Binary Derialization

            SerializeData deserializedata = new SerializeData();

            using (BinarySerializer bs = BinarySerializer.CreateFile("data.bin"))
            {
                deserializedata = bs.Deserialize<SerializeData>();
            }

            //Serializar en una carpeta depende del nombre del Objeto
            using (BinarySerializer bs = BinarySerializer.CreateDirectory("datas"))
            {
                deserializedata = bs.Deserialize<SerializeData>();
            }

            //Xml Serialization
            //Serializar en un archivo especifico
            using (XmlSerializer bs = XmlSerializer.CreateFile("data.xml"))
            {
                bs.Serialize(data);
            }

            //Serializar en una carpeta depende del nombre del Objeto
            using (XmlSerializer bs = XmlSerializer.CreateDirectory("datas"))
            {
                bs.Serialize(data);
            }

            //Binary Derialization
            using (XmlSerializer bs = XmlSerializer.CreateFile("data.xml"))
            {
                deserializedata = bs.Deserialize<SerializeData>();
            }

            //Serializar en una carpeta depende del nombre del Objeto
            using (XmlSerializer bs = XmlSerializer.CreateDirectory("datas"))
            {
                deserializedata = bs.Deserialize<SerializeData>();
            }
            
            Console.ReadLine();
        }
    }
}
