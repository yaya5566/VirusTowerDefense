
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class audioManager {
    private static audioManager m_Instance = null;
    private GameObject obj = Resources.Load("audioItem") as GameObject;   
    public static audioManager Instance {
        get {
            if(m_Instance == null) {
                m_Instance = new audioManager(); 
            }
            return m_Instance;
        }
    }

    public void createAudio(string name) {
        // obj = Resources.Load("Prefabs/audioItem") as GameObject;   

        GameObject audioGo = (GameObject) Object.Instantiate(obj,SceneManager.GetActiveScene().GetRootGameObjects()[0].transform);
        // audioGo.transform.parent = SceneManager.GetActiveScene().GetRootGameObjects()[0].transform;
        AudioClip audioClip = Resources.Load(name, typeof(AudioClip)) as AudioClip;
        audioGo.GetComponent<audioItem>().PlayAudio(audioClip);
        audioGo.GetComponent<AudioSource>().clip = audioClip; 
        audioGo.GetComponent<AudioSource>().Play();
    }
}
