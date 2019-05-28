using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class MainDatabase : MonoBehaviour
{
    public static MainDataContainer mainDB = new MainDataContainer();

    private void Awake()
    {
        MainDatabase.mainDB = MainDataManager.Load();

        foreach(CatData cat in MainDatabase.mainDB.catData.cats)
        {
            Debug.Log(cat.unitName);
        }
    }
}
