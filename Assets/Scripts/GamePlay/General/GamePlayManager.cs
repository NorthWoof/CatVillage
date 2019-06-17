using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager Instance { get; private set; }

    public float fishes;
    public Image fishGauge;
    public float fishGaugeSpeed = 0.25f;

    private void Awake()
    {
        //SpawnMapStage
    }

    void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        UpdateFishGuage();
    }


    public void UpdateFishGuage()
    {
        if(fishes < 7)
        {
            fishes += fishGaugeSpeed * Time.deltaTime;
            fishGauge.fillAmount = fishes / 7;
        }
        else
        {
            fishes = 7;
            fishGauge.fillAmount = 1;
        }
    }
  
}
