using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{

    //HP條的Image組件
    public Image EnergyBar;
    //最大生命值
    public float MaxEnergy = 100;
    //當前生命值
    private float nowEnergy;
    public gameManager gm;

    void Start()
    {
        MaxEnergy = gm.IEnergy;
        nowEnergy = MaxEnergy;
    }


    void Update()
    {
        nowEnergy  = gm.IEnergy;

        updateHPBar();
    }
    void updateHPBar()
    {
        EnergyBar.fillAmount = 1-(nowEnergy / MaxEnergy);
    }
}

