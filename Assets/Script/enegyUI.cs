using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class enegyUI : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Sprite> numImg;
    public List<Sprite> waveImg;
    public GameObject wave;
    public GameObject thousand;
    public GameObject houndred;
    public GameObject ten;
    public GameObject one;
    private int enegy;

    private int nowWave;
    private int thousandDigit;
    private int houndredDigit;

    private int tenDigit;
    private int oneDigit;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enegy = gameManager.Instance.IEnergy;
        // nowWave = gameManager.Instance.IWave;
        // ChangeImage(wave,waveImg[nowWave]);
        thousandDigit = enegy/1000;
        houndredDigit = (enegy%1000)/100;
        tenDigit = (enegy%100)/10;
        oneDigit = enegy%10; 
        ChangeImage(thousand, numImg[thousandDigit]);
        ChangeImage(houndred, numImg[houndredDigit]);
        ChangeImage(ten, numImg[tenDigit]);
        ChangeImage(one, numImg[oneDigit]);
    }

    void ChangeImage(GameObject target, Sprite src){
        target.GetComponent<Image>().sprite = src;
    }
}
