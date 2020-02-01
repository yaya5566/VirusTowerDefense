
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private int iEnergy;
    private int iWave;
    private int iHP;
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

    public bool addIEergy(int value) {
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
        if(value + iEnergy > 0) {
            iEnergy += value;
            return true;
        } else {
            Debug.LogError("game over");
            return false;
        }  
    }

}
