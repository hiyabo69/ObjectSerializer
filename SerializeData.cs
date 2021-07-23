using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializerTest
{
    [Serializable]
    public class SerializeData
    {
        public string data1 = "Data1";
        public int data2 = 100;
        public int[] data3 = {10,20310,40,50};
        public string[] data4 = { "data1", "data2","data3"};
        public SerializeData2 data5 = new SerializeData2();
    }
    [Serializable]
    public class SerializeData2
    {
        public string data1 = "Data1";
        public int data2 = 100;
    }
}
