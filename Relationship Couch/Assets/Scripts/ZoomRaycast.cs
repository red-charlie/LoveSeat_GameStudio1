using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoomRaycast : MonoBehaviour
{
    public Camera cam;
    public GameObject BlackScreen;
    public string sceneName;
    bool audioPlaying;
    public AudioSource audioHit = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
        if (audioHit != null)
        {
            if (!audioHit.isPlaying)
            {
                audioPlaying = false;
                audioHit = null;
                Debug.Log("sound can play again");
            }

            else 
            {
                audioPlaying = true;
                Debug.Log("It's playing no shooty");
            }
        }


        if (!audioPlaying)
        {
            if (Input.GetButton("Fire2"))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                // Does the ray intersect any objects excluding the player layer
                if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
                {
                    if (hit.collider.isTrigger)
                    {


                        Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
                        Debug.Log("Did Hit");

                        GameObject thingHit = hit.collider.gameObject;
                        thingHit.GetComponent<AudioSource>().Play();
                        audioHit = thingHit.GetComponent<AudioSource>();
                        Collider hitAgain = thingHit.GetComponent<Collider>();
                        hitAgain.isTrigger = false;


                        Debug.Log("is playing? " + thingHit.GetComponent<AudioSource>().isPlaying);

                        //if it's the end of the game. Go back to beginning.
                        if (thingHit.name == "EndGame")
                        {
                            print("The Game will end here");

                            Animator fadeOut = BlackScreen.GetComponent<Animator>();
                            fadeOut.Play("FadeOut");
                            StartCoroutine(sceneLoad());


                        }


                    }

                }
            }
        }
    }



        IEnumerator sceneLoad() {
            //This waits for the animation to finish before switching scenes
            //yield return null;
            yield return new WaitForSeconds(3.5f);
            print("Loading next scene");
            SceneManager.LoadScene(sceneName);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
    }



