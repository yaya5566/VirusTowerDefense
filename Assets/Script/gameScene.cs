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

    private List<List<GameObject>> listListMapGO;
    private List<List<int>> listListITmp = new List<List<int>>();

    // Start is called before the first frame update
    void Start()
    {
        List<int> listTmpI;
        for(int i = 0;i < 160;i++) {
            listTmpI = new List<int>();
            for(int j = 0;j < 90;j++) {
                if((j >= 41 && j <= 42) || (j >= 48 && j <= 49)) {
                    listTmpI.Add(2);
                } else if (j >= 43 && j <= 47){
                    listTmpI .Add(1);
                } else {
                    listTmpI.Add(0);
                }
            }
            listListITmp.Add(listTmpI);
        }

        for(int i = 0;i < listListITmp.Count;i++) {
            for(int j = 0;j < listListITmp[i].Count;j++) {
                GameObject Go = UnityEngine.Object.Instantiate<GameObject>( listMap[listListITmp[i][j]], bg.transform);
                Go.transform.localPosition = new Vector3(i * 10 + 5 - 800, j * 10 + 5 - 450);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
