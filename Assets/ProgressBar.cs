using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
    //HP條的Image組件
    public Image hpBar;
    //最大生命值
    public float MaxHp = 0;
    //當前生命值
    private float nowHP;

    void Start()
    {
        nowHP = MaxHp;
    }


    void Update()
    {
        //每秒扣5 HP 歸0後自動回滿
        nowHP -= Time.deltaTime * 5;
        /*if (nowHP > 0)
        {
            nowHP = MaxHp;
        }*/

        //更新畫面顯示
        updateHPBar();
    }
    void updateHPBar()
    {
        hpBar.fillAmount = 1-(nowHP / MaxHp);
    }
}

