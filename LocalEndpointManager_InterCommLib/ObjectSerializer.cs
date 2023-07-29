using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace LocalEndpointManager_InterCommLib
{
    public class ObjetSerializer
    {
        public static byte[] Serialize(object data)
        {
            using (var stream = new System.IO.MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, data);
                return stream.ToArray();
            }
        }
        public static T Deserialize<T>(byte[] data)
        {
            using (var stream = new System.IO.MemoryStream(data))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                return (T)serializer.Deserialize(stream);
            }
        }
    }
}
