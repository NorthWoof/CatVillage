using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

public class CatDataManager
{
    public static CatDataContainer Load(string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(CatDataContainer));

        FileStream stream = new FileStream(path, FileMode.Open);

        CatDataContainer catsContainer = serializer.Deserialize(stream) as CatDataContainer;

        stream.Close();

        return catsContainer;
    }

    public static void Save(CatDataContainer catsList, string path)
    {
        Encoding encoding = Encoding.GetEncoding("UTF-16");

        XmlSerializer serializer = new XmlSerializer(typeof(CatDataContainer));

        FileStream fileStream = new FileStream(path, FileMode.Truncate);

        StreamWriter writer = new StreamWriter(fileStream, encoding);

        serializer.Serialize(writer, catsList);

        writer.Close();
    }
}
