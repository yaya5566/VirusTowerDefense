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
    [SerializeField]
    private List<GameObject> ListSelectTower;
    [SerializeField]
    private GameObject selectTowerNode;
    // Start is called before the first frame update
    private TOWER_ITEM_TYPE eTIT = TOWER_ITEM_TYPE.NONE; 

    void Start()
    {

        // gameObject.GetComponent<Button>().onClick.AddListener(delegate{
        //     onClick();
        // });
        gameObject.tag = "Type1";
    }

    void onClick(TOWER_ITEM_TYPE _eTIT) {
        eTIT = _eTIT;
        switch(eTIT) {
            case TOWER_ITEM_TYPE.NONE:
                eTIT = TOWER_ITEM_TYPE.RED;
                // sprite.sprite = ListSprTowerFull[0];
                // sprite.color = new Color(255, 0, 0);
            break;
            case TOWER_ITEM_TYPE.RED:
                eTIT = TOWER_ITEM_TYPE.GREEN;
                sprite.sprite = ListSprTowerFull[0];
                // sprite.color = new Color(0, 255, 0);
            break;
            case TOWER_ITEM_TYPE.GREEN:
                eTIT = TOWER_ITEM_TYPE.BLUE;
                sprite.sprite = ListSprTowerFull[1];
                // sprite.color = new Color(0, 0, 255);
            break;
            case TOWER_ITEM_TYPE.BLUE:
                eTIT = TOWER_ITEM_TYPE.NONE;
                sprite.sprite = ListSprTowerFull[2];
                // sprite.color = new Color(255, 255, 255);
            break;
        }

    }

    // private void OnMouseDown() {
    //     sprite.transform.localScale = new Vector3(0.2f, 0.2f, 1);
    // }
    // private void OnMouseUp() {
    //     sprite.transform.localScale = new Vector3(0.1f, 0.1f, 1);
    //     onClick();
    // }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0)) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(sprite.GetComponent<BoxCollider2D>().OverlapPoint(mousePosition))
            {
                sprite.transform.localScale = new Vector3(0.1f, 0.1f, 1);
                selectTowerNode.SetActive(true);
                // if(selectTowerNode.activeSelf == true) {
                //     selectTowerNode.SetActive(false);
                // } else {
                //     selectTowerNode.SetActive(true);
                // }
                // onClick();
            } else {
                for(int i = 0;i < ListSelectTower.Count;i++) {
                    if(ListSelectTower[i].GetComponent<BoxCollider2D>().OverlapPoint(mousePosition)) {
                        ListSelectTower[i].transform.localScale = new Vector3(0.1f, 0.1f, 1);
                        onClick((TOWER_ITEM_TYPE)(i + 1));
                    }
                }
                selectTowerNode.SetActive(false);
            }
        }
        if(Input.GetMouseButtonDown(0)) {Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(sprite.GetComponent<BoxCollider2D>().OverlapPoint(mousePosition))
            {
                sprite.transform.localScale = new Vector3(0.2f, 0.2f, 1);
            } else {
                for(int i = 0;i < ListSelectTower.Count;i++) {
                    if(ListSelectTower[i].GetComponent<BoxCollider2D>().OverlapPoint(mousePosition)) {
                        ListSelectTower[i].transform.localScale = new Vector3(0.2f, 0.2f, 1);
                    }
                }
            }
        }
    }
}
