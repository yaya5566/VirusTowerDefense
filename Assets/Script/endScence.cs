using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endScence : MonoBehaviour
{
    [SerializeField]
    private Button btnEnd;
    [SerializeField]
    private Button btnRe;
    // Start is called before the first frame update
    void Start()
    {
        btnEnd.onClick.AddListener(delegate() {
            Application.Quit();
        });
        btnRe.onClick.AddListener(delegate() {
            SceneManager.LoadScene("StartScene");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
