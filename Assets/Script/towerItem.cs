using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TOWER_ITEM_TYPE {
    NONE,
    RED,
    GREEN,
    BLUE
}

public class towerItem : MonoBehaviour
{
        [SerializeField]
    private GameObject patientItem;
    // Start is called before the first frame update
    private TOWER_ITEM_TYPE eTIT = TOWER_ITEM_TYPE.NONE; 

    void Start()
    {
        // GameObject GoPatitentItem = UnityEngine.Object.Instantiate<GameObject>(patientItem, transform);
        // GetComponent<Button>().onClick.AddListener(delegate{
        //     onClick();
        // });
    }

    public void onClick() {
        GameObject GoPatitentItem = UnityEngine.Object.Instantiate<GameObject>(patientItem, transform);
        switch(eTIT) {
            case TOWER_ITEM_TYPE.NONE:
                eTIT = TOWER_ITEM_TYPE.RED;
                GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
            break;
            case TOWER_ITEM_TYPE.RED:
                eTIT = TOWER_ITEM_TYPE.GREEN;
                GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
            break;
            case TOWER_ITEM_TYPE.GREEN:
                eTIT = TOWER_ITEM_TYPE.BLUE;
                GetComponent<SpriteRenderer>().color = new Color(0, 0, 255);
            break;
            case TOWER_ITEM_TYPE.BLUE:
                eTIT = TOWER_ITEM_TYPE.NONE;
                GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
