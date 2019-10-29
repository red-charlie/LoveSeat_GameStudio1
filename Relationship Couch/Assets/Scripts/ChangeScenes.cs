using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public string sceneName;
    public GameObject BlackScreen;
    //public Animation fadeOut;
    

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))

        {   //this plays the fadeout animation
            Animator fadeOut = BlackScreen.GetComponent<Animator>();
            fadeOut.Play("FadeOut");
            StartCoroutine(sceneLoad());
           

            
        }
    }
    IEnumerator sceneLoad() {
        //This waits for the animation to finish before switching scenes
            //yield return null;
            yield return new WaitForSeconds(2);
            print("Loading next scene");
            SceneManager.LoadScene(sceneName);
             
            }

}
