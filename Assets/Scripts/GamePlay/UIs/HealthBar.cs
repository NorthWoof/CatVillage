using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform hpBar,manaBar;

    // Start is called before the first frame update
    void Start()
    {
        var newScale = this.hpBar.localScale;
        newScale.x = 1;
        this.hpBar.localScale = newScale;
    }

    public void SetHPBar(int hp,int maxHp)
    {
        float fillAmount = (float)hp / maxHp;

        // Make sure value is between 0 and 1
        fillAmount = Mathf.Clamp01(fillAmount);

        // Scale the fillImage accordingly
        var newScale = this.hpBar.localScale;
        //newScale.y = this.fullFillImage.localScale.y * fillAmount;
        newScale.x = fillAmount;
        this.hpBar.localScale = newScale;
    }

    public void SetManaBar(int mana)
    {
        float fillAmount = (float)mana / 100;

        // Make sure value is between 0 and 1
        fillAmount = Mathf.Clamp01(fillAmount);

        // Scale the fillImage accordingly
        var newScale = this.manaBar.localScale;
        //newScale.y = this.fullFillImage.localScale.y * fillAmount;
        newScale.x = fillAmount;
        this.manaBar.localScale = newScale;
    }
}
