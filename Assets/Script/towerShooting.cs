using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerShooting : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int Range;
    public string TowerName;
    public GameObject enemyGenerator;

    private GameObject CurrentTarget;
    void Start()
    {
        
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
            }
        }
    }

    void SearchTarget() 
    {
        foreach (var enemy in enemyGenerator.GetComponent<enemyGenerator>().Enemies){
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
