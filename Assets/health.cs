using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public List<GameObject> hearts;

    private int HP;
    public gameManager gm;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        HP = gm.IHP;
        for(int i = 10; i > HP; i--)
        {
            hearts[i-1].SetActive(false);
        }

    }
}
