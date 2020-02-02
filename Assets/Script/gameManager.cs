
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager {
    private static gameManager m_Instance = null;

    public static gameManager Instance {
        get {
            if(m_Instance == null) {
                m_Instance = new gameManager();
            }
            return m_Instance;
        }
    }

    private int iEnergy=0;
    private int iWave=0;
    private int iHP=10;
    public int IEnergy {
        get {
            return iEnergy;
        }
    }
    public int IWave {
        get {
            return iWave;
        }
    }
    public int IHP {
        get {
            return iHP;
        }
    }

    public bool addIEnergy(int value) {
        if(value + iEnergy >= 0) {
            iEnergy += value;
            return true;
        } else {
            return false;
        }  
    }

    public void addIWave(int value) {
        iEnergy += value;
    }

    public bool addIHP(int value) {
        if(value + iHP > 0) {
            iHP += value;
            return true;
        } else {
            Debug.LogError("game over");
            SceneManager.LoadScene("EndScene");
            return false;
        }  
    }

}
