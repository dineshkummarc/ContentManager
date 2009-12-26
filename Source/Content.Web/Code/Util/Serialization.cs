using System;
using System.IO;
//
using System.Xml.Serialization;

namespace ContentNamespace.Web.Code.Util
{
    public class Serialization
    {
        #region Methods...

        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <param name="type">The type of the object to serialize.</param>
        /// <returns></returns>
        public string Serialize(object obj, Type type)
        {
            string xml;
            var xmlSerializer = new XmlSerializer(type);

            using (var memoryStream = new MemoryStream())
            {
                xmlSerializer.Serialize(memoryStream, obj, null);
                memoryStream.Position = 0;

                using (var streamReader = new StreamReader(memoryStream))
                {
                    xml = streamReader.ReadToEnd();
                }
            }

            return xml;
        }

        /// <summary>
        /// Deserializes an object.
        /// </summary>
        /// <param name="xml">The XML to deserialize into an object.</param>
        /// <param name="typeName">The type of the resulting object.</param>
        /// <returns></returns>
        public object Deserialize(string xml, string typeName)
        {
            var type = Type.GetType(typeName);
            var xmlSerializer = new XmlSerializer(type);
            var stringReader = new StringReader(xml);

            var obj = xmlSerializer.Deserialize(stringReader);
            stringReader.Close();

            return obj;
        }

        #endregion
    }
}
