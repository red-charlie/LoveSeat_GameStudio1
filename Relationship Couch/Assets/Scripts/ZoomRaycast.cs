using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomRaycast : MonoBehaviour
{
    public Camera cam;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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

                    Collider hitAgain = thingHit.GetComponent<Collider>();
                    hitAgain.isTrigger = false;


                    Debug.Log("is playing? " + thingHit.GetComponent<AudioSource>().isPlaying);

                }
               
            }
        }

    }
}

