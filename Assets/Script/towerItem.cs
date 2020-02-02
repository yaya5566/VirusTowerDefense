using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TOWER_ITEM_TYPE {
    NONE,
    RED,
    GREEN,
    YELLOW
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
    private int iBulletNum = 0;

    void Start()
    {

        // gameObject.GetComponent<Button>().onClick.AddListener(delegate{
        //     onClick();
        // });
        gameObject.tag = "";
    }

    void onClick(TOWER_ITEM_TYPE _eTIT) {
        eTIT = _eTIT;
        if(eTIT == _eTIT) {
            if(!gameManager.Instance.addIEnergy(iBulletNum - 10)) {
                return;
            } else {
                Debug.LogError("energy error");
            }
        } else {
            if(!gameManager.Instance.addIEnergy(-10)) {
                return;
            } else {
                 Debug.LogError("energy error");
            }
        }
        switch(eTIT) {
            case TOWER_ITEM_TYPE.NONE:
                gameObject.tag = "";
                // sprite.sprite = ListSprTowerFull[0];
                // sprite.color = new Color(255, 0, 0);
            break;
            case TOWER_ITEM_TYPE.RED:
                sprite.sprite = ListSprTowerFull[0];
                gameObject.tag = "RedSyringe";
                // sprite.color = new Color(0, 255, 0);
            break;
            case TOWER_ITEM_TYPE.GREEN:
                sprite.sprite = ListSprTowerFull[1];
                gameObject.tag = "BlueMask";
                // sprite.color = new Color(0, 0, 255);
            break;
            case TOWER_ITEM_TYPE.YELLOW:
                sprite.sprite = ListSprTowerFull[2];
                gameObject.tag = "YellowPill";
                // sprite.color = new Color(255, 255, 255);
            break;
        }
        iBulletNum = 10;

    }

    // private void OnMouseDown() {
    //     sprite.transform.localScale = new Vector3(0.2f, 0.2f, 1);
    // }
    // private void OnMouseUp() {
    //     sprite.transform.localScale = new Vector3(0.1f, 0.1f, 1);
    //     onClick();
    // }

    // Update is called once per frame
    public void subBullet() {
        iBulletNum--;
        if(iBulletNum == 0) {
            switch(eTIT) {
                case TOWER_ITEM_TYPE.NONE:
                break;
                case TOWER_ITEM_TYPE.RED:
                    sprite.sprite = ListSprTowerDie[0];
                break;
                case TOWER_ITEM_TYPE.GREEN:
                    sprite.sprite = ListSprTowerDie[1];

                break;
                case TOWER_ITEM_TYPE.YELLOW:
                    sprite.sprite = ListSprTowerDie[2];
                break;
            }
            gameObject.tag = "";
        }
    }
    public int getIBullet() {
        return iBulletNum;
    }
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
