using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public RaycastHit lastRaycastHit;
    private int timeCounter = 0;
    private string currentFocus = "";


    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        
    }

    /*private GameObject GetLookedAtObject(){
        Vector3 origin = transform.position;
        Vector3 direction = Camera.main.transform.forward;
        float range = 1000;
        if (Physics.Raycast (origin,direction,out lastRaycastHit)){
            return lastRaycastHit.collider.gameObject;
        }
        else {
            return null;
        }
    }*/

    /*private void TeleportToLookAt() {
        transform.position = lastRaycastHit.point + lastRaycastHit.normal * 5;
    }*/

    private void changeCamera(Vector3 position, Vector3 angle){
        Camera.main.transform.position = position;
        Camera.main.transform.eulerAngles = angle;
        timeCounter = 0;
    }

    private void recognizePlanet(string name){
        if (name != currentFocus) {
            if (name == "Mercury") changeCamera(new Vector3(-432, 168, 265), new Vector3(6,8,2));
            else if (name == "Venus") changeCamera(new Vector3(-317, 168, 324), new Vector3(6,8,2));
            else if (name == "Clouds") changeCamera(new Vector3(-432,169,422), new Vector3(6,8,2));
            else if (name == "Mars") changeCamera(new Vector3(-571, 168, 559), new Vector3(6, 31, 2));
            else if (name == "Jupiter") changeCamera(new Vector3(-340, 172, 572), new Vector3(6,4,2));
            else if (name == "Saturn") changeCamera(new Vector3(-772, 190, 591), new Vector3(31,5,4));
            else if (name == "Uranus") changeCamera(new Vector3(-246, 169, 625), new Vector3(3,4,2));
            else if (name == "Neptune") changeCamera(new Vector3(-103, 169, 705), new Vector3(6,8,2));
            else if (name == "Pluto") changeCamera(new Vector3(-599, 168, 815), new Vector3(3,-22,2));
            currentFocus = name;
        } 
    }

    // Update is called once per frame
    void Update() {
        /*if (Input.GetMouseButtonDown(0)){
            if (GetLookedAtObject() != null){
                TeleportToLookAt();
            }
        }*/

        RaycastHit hit;
        float thickness = 50f;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position,forward, Color.green);

        if(Physics.Raycast(transform.position, forward, out hit)){
            timeCounter++;
            print(" Object: " + hit.collider.gameObject.name);
            string hitObject = hit.collider.gameObject.name;

            if (timeCounter == 500){
                recognizePlanet(hitObject);
            }
        }
        else {
            timeCounter = 0;
        }
    }
}

/*
Merkur
(-432, 168.4, 265)
(6,8,2)
Venusa
(-317, 168.5, 324)
(6,8,2)
Zem
(-432,169,422)
(6,8,2)
Mars
(-571.5, 168.5, 559)
(6, 31, 2)
Jupiter
(-340, 172, 572)
(6,4,2)
Saturn
(-772, 190, 591)
(31.5.4)
Uran
(-246, 169, 625)
(3,4,2)
Neptun
(-103, 169, 705)
(3,4,2)
Pluto
(-599.5, 168.2, 815)
(3, -22, 2)
*/


