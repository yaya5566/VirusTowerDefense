using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletItem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    private float fMoveTmp = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null){
            fMoveTmp += (1f / 2f) * Time.deltaTime;
            transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y,0), new Vector3(target.transform.position.x, target.transform.position.y, 0), fMoveTmp);
        }
        if(fMoveTmp >= 1) {
            target.GetComponent<patientItem>().HP -= 4;
            target = null;
            fMoveTmp = 0;
            Destroy(gameObject);
        }
    }
}
