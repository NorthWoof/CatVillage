using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

public class MainDataManager
{
    const string path = "Assets/Resources/Database/Data.xml";

    public static MainDataContainer Load()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(MainDataContainer));

        FileStream stream = new FileStream(path, FileMode.Open);

        MainDataContainer dataContainer = serializer.Deserialize(stream) as MainDataContainer;

        stream.Close();

        return dataContainer;
    }

    public static void Save(MainDataContainer data)
    {
        Encoding encoding = Encoding.GetEncoding("UTF-16");

        XmlSerializer serializer = new XmlSerializer(typeof(MainDataContainer));

        FileStream fileStream = new FileStream(path, FileMode.Create);

        StreamWriter writer = new StreamWriter(fileStream, encoding);

        serializer.Serialize(writer, data);

        writer.Close();
    }
}
