using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;


public class CatDataContainer
{
    [XmlArray("CatDatas")]
    [XmlArrayItem("CatData")]
    public List<CatData> cats = new List<CatData>();
}
