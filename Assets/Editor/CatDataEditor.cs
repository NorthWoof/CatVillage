using UnityEngine;
using UnityEditor;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

[CustomEditor(typeof(CatData))]
public class CatDataEditor : EditorWindow
{
    public List<CatData> catDatas;

    private void Awake()
    {
        catDatas = new List<CatData>();
        LoadCats();
    }

    [MenuItem("Window/CatData")]
    public static void ShowWindow()
    {
        GetWindow<CatDataEditor>("CatData");
    }

    private void OnGUI()
    {
        if(GUILayout.Button("Apply Change"))
        {
            SaveCats();
        }

        GUILayout.Label("Base Settings", EditorStyles.boldLabel);

        for (int i = 0; i < catDatas.Count; i++)
        {
            GUILayout.Label(catDatas[i].unitName, EditorStyles.boldLabel);
        }

    }

    public void LoadCats()
    {
        catDatas = LoadXML();
    }

    public void SaveCats()
    {
        SaveXML(catDatas);
    }

    public List<CatData> LoadXML()
    {
        CatDataContainer cdc = CatDataManager.Load();

        return cdc.cats;
    }

    public void SaveXML(List<CatData> catDatas)
    {
        CatDataContainer cdc = new CatDataContainer();
        cdc.cats = catDatas;

        CatDataManager.Save(cdc);
    }
}
