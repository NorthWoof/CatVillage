﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager Instance { get; private set; }


    private void Awake()
    {
        //SpawnMapStage
    }

    void Start()
    {
        Instance = this;
    }

  
}
