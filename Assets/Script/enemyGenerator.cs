using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.Events;

public class enemyGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> Enemies;
    private float walkableFloor = 1.2f;
    private float walkableCiel = -1.2f;
    private int nowState = 1; // 0 = pause
    private int waveSec = 30;
    private int patientAmount = 0;
    [SerializeField]
    public float delayTime = 0.1f;

    [SerializeField]
    private GameObject patientItem;

    void Start()
    {
        InvokeRepeating("Generate",0,delayTime);
    }

    // Update is called once per frame

    void Init() 
    {
        InvokeRepeating("Generate", 0, delayTime);
        int tempState = nowState;
        patientAmount = 0;
        nowState = tempState + 1;
        foreach(var enemy in Enemies)
            Destroy(enemy);
        Enemies.Clear();
    }
    void Wait()
    {
        Invoke("Init", 10);
    }
    void Generate()
    {
        if(nowState != 0) {
            GameObject GoPatitentItem = UnityEngine.Object.Instantiate<GameObject>(patientItem, transform);
            float patientY = Random.Range(walkableFloor, walkableCiel);
            GoPatitentItem.tag = "Type1";
            GoPatitentItem.name = "P" + patientAmount;
            GoPatitentItem.transform.position = new Vector3(GoPatitentItem.transform.position.x, patientY, 0);
            Enemies.Add(GoPatitentItem);
            patientAmount += 1;
            if(patientAmount >= nowState * 3){
                CancelInvoke("Generate");
                Wait();
            }
        }
    }

    void Update()
    {
        
    }
}
