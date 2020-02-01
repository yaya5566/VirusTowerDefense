using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endTrigger : MonoBehaviour
{

    void Start(){
        Debug.Log("start");
    }


    void OnTriggerEnter2D(Collider2D Coll){
        Debug.Log("OnTrigger"+Coll.gameObject.ToString());
        Destroy(Coll.gameObject);
    }

}
