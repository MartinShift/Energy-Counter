
using System.IO;
using System.Xml.Serialization;
namespace Energy_Counter.Models
{
    public class XmlHelper<T>
    {
        public static void Serialize(T obj, string file)
        {
            var taskSerializer = new XmlSerializer(typeof(T));

            using (FileStream fs = new FileStream(file, FileMode.Create))
            {
                taskSerializer.Serialize(fs, obj);
            }
        }
        public static T Deserialize(string file)
        {
            using (var sr = new FileStream(file, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(T));

                return (T)serializer.Deserialize(sr);

            }
        }
    }
}
