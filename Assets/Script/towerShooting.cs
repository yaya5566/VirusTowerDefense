using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerShooting : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int Range;
    public string TowerName;
    public enemyGenerator eg;

    private GameObject CurrentTarget;
    public GameObject bulletObj;
    private bool CD = true;
    void Start()
    {
        eg = FindObjectOfType<enemyGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentTarget == null) {
            SearchTarget();
        }
        else if(CurrentTarget != null) {
            Vector3 targetPosition = new Vector3(CurrentTarget.transform.position.x, transform.position.y, transform.position.z);
            if (Vector3.Distance(transform.position, targetPosition) > Range || CurrentTarget.tag == "Repaired") {
                CurrentTarget = null;
                return;
            }else{
                Shooting();
            }
        }
    }

    void RunCD()
    {
        CD = true;
    }
    void Shooting()
    {
        if(CD == true) {
            GameObject bullet = UnityEngine.Object.Instantiate<GameObject>(bulletObj, transform);
            bullet.GetComponent<bulletItem>().target = CurrentTarget;
            CD = false;
            Invoke("RunCD", 0.7f);
        }
    }
    void SearchTarget() 
    {
        foreach (var enemy in eg.Enemies){
            Vector3 target = new Vector3(enemy.transform.position.x, enemy.transform.position.y, 0);
            if (enemy.tag != gameObject.tag) {
                continue;
            }
            if (Vector3.Distance(transform.position, target) <= Range) {
                CurrentTarget = enemy;
            }
        }
    }
}
