using UnityEngine;
using UnityEditor;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

[XmlRoot("CatDataCollection")]
public class UnitDataEditor : EditorWindow
{
    public const string path = "Assets/Data/CatData.xml";

    public List<CatData> catDatas;

    [MenuItem("Window/CatData")]
    public static void ShowWindow()
    {
        GetWindow<UnitDataEditor>("CatData");
    }

    private void Update()
    {
        
    }

    private void OnGUI()
    {
        
    }

    public void LoadXML()
    {
        CatDataContainer cdc = CatDataManager.Load("Assets/Resources/Database/CatData.xml");

        Debug.Log(cdc.cats.Count);

        foreach (CatData cat in cdc.cats)
        {
            Debug.Log(cat.unitName);
        }
    }

    public void SaveXML()
    {
        CatDataContainer cdc = new CatDataContainer();
        cdc.cats = catDatas;

        CatDataManager.Save(cdc, "Assets/Resources/Database/CatData.xml");
    }
}
