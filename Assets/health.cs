using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public GameObject heart10;
    public GameObject heart09;
    public GameObject heart08;
    public GameObject heart07;
    public GameObject heart06;
    public GameObject heart05;
    public GameObject heart04;
    public GameObject heart03;
    public GameObject heart02;
    public GameObject heart01;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(heart10, 1);
        Destroy(heart09, 2);
        Destroy(heart08, 3);
        Destroy(heart07, 4);
        Destroy(heart06, 5);
        Destroy(heart05, 6);
        Destroy(heart04, 7);
        Destroy(heart03, 8);
        Destroy(heart02, 9);
        Destroy(heart01, 10);

    }
}
