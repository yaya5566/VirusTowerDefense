using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startScene : MonoBehaviour
{
    [SerializeField]
    private Button btnStart; 
    // Start is called before the first frame update

    void Start()
    {
        btnStart.onClick.AddListener(delegate() {
            SceneManager.LoadScene("HospitalScene");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}