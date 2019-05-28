using UnityEngine;
using UnityEditor;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using UnityEditorInternal;


[CustomEditor(typeof(CatData))]
public class CatDataEditor : EditorWindow
{
    public List<CatData> catDatas;
    ReorderableList reorderlist;

    SerializedObject serializedObject;

    private void Awake()
    {
        catDatas = new List<CatData>();
        //LoadCats();

        
    }

    [MenuItem("Window/CatData")]
    public static void ShowWindow()
    {
        GetWindow<CatDataEditor>("CatData");
    }

    private void OnEnable()
    {
        
    }

    private void OnGUI()
    {
        if(GUILayout.Button("Apply Change"))
        {
            TestCat();
            SaveCats(catDatas);
        }

        GUILayout.Label("Base Settings", EditorStyles.boldLabel);

        for (int i = 0; i < catDatas.Count; i++)
        {
            GUILayout.Label(catDatas[i].unitName, EditorStyles.boldLabel);
        }

    }

    public void TestCat()
    {
        CatData cat1 = new CatData();
        cat1.id = "meow";
        cat1.unitName = "WEEEOW";
        cat1.cost = 10;

        catDatas.Add(cat1);

        CatData cat2 = new CatData();
        cat2.id = "bark";
        cat2.unitName = "Barker";
        cat2.cost = 20;

        catDatas.Add(cat2);

    }

    /*public void LoadCats()
    {
        catDatas = LoadXML();
    }

    public List<CatData> LoadXML()
    {
        CatDataContainer cdc = CatDataManager.Load();

        return cdc.cats;
    }*/

    public void SaveCats(List<CatData> catDatas)
    {
        CatDataContainer cdc = new CatDataContainer();
        
        MainDatabase.mainDB.catData.cats = catDatas;

        MainDataManager.Save(MainDatabase.mainDB);
    }
}
