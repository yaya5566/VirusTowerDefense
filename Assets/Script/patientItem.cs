using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patientItem : MonoBehaviour
{
    private int HP = 10;
    private int attributes = 1;
    private float fSec = 10;
    private float fMoveTmp = 0;
    private bool isMove = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Go() {
        isMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMove == true) {
            transform.Translate((new Vector3(0, transform.position.y, 0) - transform.position) * Time.deltaTime * fSec);
            fMoveTmp += (1f / fSec) * Time.deltaTime;

            transform.position = Vector3.Lerp(new Vector3(1600, transform.position.y,0), new Vector3(0, transform.position.y, 0), fMoveTmp);
        }
        if(fMoveTmp >= 1) {
            isMove = false;
            fMoveTmp = 0;
        }
        
    }
}
