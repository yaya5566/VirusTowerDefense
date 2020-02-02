using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endScence : MonoBehaviour
{
    [SerializeField]
    private Button btnEnd;
    // Start is called before the first frame update
    void Start()
    {
        btnEnd.onClick.AddListener(delegate() {
            Application.Quit();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
