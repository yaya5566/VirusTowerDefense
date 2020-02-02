using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameScene : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> listMap; 
    [SerializeField]
    private GameObject bg;
    [SerializeField]
    private GameObject patientItem;

    private List<List<GameObject>> listListMapGO;
    private List<List<int>> listListITmp = new List<List<int>>();

    // Start is called before the first frame update
    void Start()
    {
        List<int> listTmpI;
        for(int i = 0;i < 160;i++) {
            listTmpI = new List<int>();
            for(int j = 0;j < 90;j++) {
                if((j >= 21 && j <= 29) || (j >= 61 && j <= 69)) {
                    listTmpI.Add(2);
                } else if (j >= 30 && j <= 60){
                    listTmpI .Add(1);
                } else {
                    listTmpI.Add(0);
                }
            }
            listListITmp.Add(listTmpI);
        }

        // for(int i = 0;i < listListITmp.Count;i++) {
        //     for(int j = 0;j < listListITmp[i].Count;j++) {
        //         GameObject Go = UnityEngine.Object.Instantiate<GameObject>( listMap[listListITmp[i][j]], bg.transform);
        //         Go.transform.localPosition = new Vector3(i * 10 + 5 - 800, j * 10 + 5 - 450);
        //     }
        // }

        GameObject GoPatitentItem = UnityEngine.Object.Instantiate<GameObject>( patientItem, transform);
        GoPatitentItem.transform.position = new Vector3(0, 450, 0);
        GoPatitentItem.GetComponent<patientItem>().Go();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
