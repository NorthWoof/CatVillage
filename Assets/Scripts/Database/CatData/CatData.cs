using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

[System.Serializable, XmlRoot("CatDatas")]
public class CatData
{
    [XmlAttribute("id")]
    public string id;

    [XmlAttribute("name")]
    public string unitName;

    [XmlElement("prefab")]
    public string prefab;

    [XmlElement("SpawnTime")]
    public float spawnTime;

    [XmlElement("Cost")]
    public float cost;


}
