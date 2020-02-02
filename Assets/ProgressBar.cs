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
    private float nowEnergy = 0f;


    void Start()
    {
        MaxEnergy = gameManager.Instance.maxSchedule;
        nowEnergy = MaxEnergy;
    }


    void Update()
    {
        MaxEnergy = gameManager.Instance.maxSchedule;
        nowEnergy  = gameManager.Instance.nowSchedule;

        updateHPBar();
    }
    void updateHPBar()
    {
        EnergyBar.fillAmount = (nowEnergy / MaxEnergy);
    }
}

