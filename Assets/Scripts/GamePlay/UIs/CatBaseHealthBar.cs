using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatBaseHealthBar : MonoBehaviour
{
    public static CatBaseHealthBar Instance {get; private set;}
    public Image hpBar;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        hpBar.fillAmount = 1;
    }

    public void SetHPBar(int hp, int maxHp)
    {
        float fillAmount = (float)hp / maxHp;

        // Make sure value is between 0 and 1
        fillAmount = Mathf.Clamp01(fillAmount);

        hpBar.fillAmount = fillAmount;
    }
}
