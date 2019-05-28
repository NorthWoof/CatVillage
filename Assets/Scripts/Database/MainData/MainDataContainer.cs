using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;


[XmlRoot("Database")]
public class MainDataContainer 
{
    [XmlElement("CatDataCollection")]
    public CatDataContainer catData = new CatDataContainer();
    [XmlElement("SimpleString")]
    public string simple = "simple";
}
