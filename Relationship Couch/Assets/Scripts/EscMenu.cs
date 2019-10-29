using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour
{
    bool Paused = false;
    public GameObject EscMenu_1;
    
    

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape")){
           if (Paused == true) {
               
                 EscMenu_1.gameObject.SetActive (false);
               
                 Cursor.visible = false;
                 Cursor.lockState = CursorLockMode.None;
                 Time.timeScale = 1.0f;

                 Paused = false;
             } else {
                 
                 EscMenu_1.gameObject.SetActive (true);
                 
                 Cursor.visible = true;
                 Cursor.lockState = CursorLockMode.None;
                 Time.timeScale = 0.0f;
                 
                 Paused = true;

           }
        }
    }
}
