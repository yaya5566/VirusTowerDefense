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
    private SpriteRenderer sprite;
    [SerializeField]
    private List<Sprite> ListSprTowerFull;
    [SerializeField]
    private List<Sprite> ListSprTowerDie;
    // Start is called before the first frame update
    private TOWER_ITEM_TYPE eTIT = TOWER_ITEM_TYPE.NONE; 

    void Start()
    {
        // gameObject.GetComponent<Button>().onClick.AddListener(delegate{
        //     onClick();
        // });
        gameObject.tag = "Type1";
    }

    void onClick() {
        switch(eTIT) {
            case TOWER_ITEM_TYPE.NONE:
                eTIT = TOWER_ITEM_TYPE.RED;
                sprite.sprite = ListSprTowerFull[0];
                // sprite.color = new Color(255, 0, 0);
            break;
            case TOWER_ITEM_TYPE.RED:
                eTIT = TOWER_ITEM_TYPE.GREEN;
                sprite.sprite = ListSprTowerFull[1];
                // sprite.color = new Color(0, 255, 0);
            break;
            case TOWER_ITEM_TYPE.GREEN:
                eTIT = TOWER_ITEM_TYPE.BLUE;
                sprite.sprite = ListSprTowerFull[0];
                // sprite.color = new Color(0, 0, 255);
            break;
            case TOWER_ITEM_TYPE.BLUE:
                eTIT = TOWER_ITEM_TYPE.NONE;
                sprite.sprite = ListSprTowerFull[1];
                // sprite.color = new Color(255, 255, 255);
            break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0)) {
            onClick();
        }
    }
}
