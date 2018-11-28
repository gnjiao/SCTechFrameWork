using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Common
{
    public class XMLSerializeHelper
    {
        public static T DeserializeXML<T>(Stream stream)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                XmlTextReader reader = new XmlTextReader(stream);
                T obj = (T)xmlSerializer.Deserialize(reader);
                reader.Close();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception("[XMLhelper:DeserializeXML]" + e.Message, e);
            }
        }

        public static void SerializeXML<T>(T obj, Stream stream)
        {
            try
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");//不输出xmlns
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
                writer.Indentation = 4;
                writer.Formatting = Formatting.Indented;
                xmlSerializer.Serialize(writer, obj, ns);
                writer.Close();
            }
            catch (Exception e)
            {
                throw new Exception("[XMLhelper:SerializeXML]" + e.Message, e);
            }
        }

        public static T DeserializeXML<T>(string filepath)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                XmlTextReader reader = new XmlTextReader(filepath);
                T obj = (T)xmlSerializer.Deserialize(reader);
                reader.Close();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception("[XMLhelper:DeserializeXML]" + e.Message, e);
            }
        }

        public static void SerializeXML<T>(T obj, string filepath)
        {
            try
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");//不输出xmlns
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                XmlTextWriter writer = new XmlTextWriter(filepath, Encoding.UTF8);
                writer.Indentation = 4;
                writer.Formatting = Formatting.Indented;
                xmlSerializer.Serialize(writer, obj, ns);
                writer.Close();
            }
            catch (Exception e)
            {
                throw new Exception("[XMLhelper:SerializeXML]" + e.Message, e);
            }
        }
    }
}