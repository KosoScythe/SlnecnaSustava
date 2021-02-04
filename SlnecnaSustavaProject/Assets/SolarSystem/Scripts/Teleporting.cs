using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public RaycastHit lastRaycastHit;
    private int timeCounter = 0;
    private string currentFocus = "";
    private GameObject currentModal;

    private GameObject sun;
    private GameObject merkur;
    private GameObject venus;
    private GameObject clouds;
    private GameObject mars;
    private GameObject jupiter;
    private GameObject saturn;
    private GameObject uranus;
    private GameObject neptune;
    private GameObject pluto;
    private bool show = false;


    // Start is called before the first frame update
    void Start(){
        //Cursor.visible = false;
        sun     = GameObject.Find("Info-Sun");
        merkur  = GameObject.Find("Info-Merkur");
        venus   = GameObject.Find("Info-Venus");
        clouds  = GameObject.Find("Info-Clouds");
        mars    = GameObject.Find("Info-Mars");
        jupiter = GameObject.Find("Info-Jupiter");
        saturn  = GameObject.Find("Info-Saturn");
        uranus  = GameObject.Find("Info-Uranus");
        neptune = GameObject.Find("Info-Neptune");
        pluto   = GameObject.Find("Info-Pluto");

        sun.SetActive(false); merkur.SetActive(false); venus.SetActive(false); clouds.SetActive(false); mars.SetActive(false); jupiter.SetActive(false); saturn.SetActive(false); uranus.SetActive(false);
        neptune.SetActive(false); pluto.SetActive(false);
    }

    private void changeCamera(Vector3 position, Vector3 angle){
        Camera.main.transform.position = position;
        Camera.main.transform.eulerAngles = angle;
        timeCounter = 0;
    }

    private void showText(string name){
        print("Here ich bin");
        if (currentModal != null) currentModal.SetActive(false);
        if (name == "Sun")          {sun.SetActive(true);       currentModal = sun;}         
        else if (name == "Mercury") {merkur.SetActive(true);    currentModal = merkur;} 
        else if (name == "Venus")   {venus.SetActive(true);     currentModal = venus;}  
        else if (name == "Clouds")  {clouds.SetActive(true);    currentModal = clouds;}
        else if (name == "Mars")    {mars.SetActive(true);      currentModal = mars;}
        else if (name == "Jupiter") {jupiter.SetActive(true);   currentModal = jupiter;} 
        else if (name == "Saturn")  {saturn.SetActive(true);    currentModal = saturn;} 
        else if (name == "Uranus")  {uranus.SetActive(true);    currentModal = uranus;} 
        else if (name == "Neptune") {neptune.SetActive(true);   currentModal = neptune;}
        else if (name == "Pluto")   {pluto.SetActive(true);     currentModal = pluto;}  
    }

    private void recognizePlanet(string name){
        if (name == "Sun") changeCamera(new Vector3(-369, 168, 50), new Vector3(1,-34,0));
        else if (name == "Mercury") changeCamera(   new Vector3(-432, 168, 265), new Vector3(-5,-19, 0) );
        else if (name == "Venus") changeCamera(     new Vector3(-317, 169, 320), new Vector3(10,-22, 0) );
        else if (name == "Clouds") changeCamera(    new Vector3(-432, 169, 422), new Vector3(17,-23, 0) );
        else if (name == "Mars") changeCamera(      new Vector3(-571, 168, 559), new Vector3(-5, -6, 0) );
        else if (name == "Jupiter") changeCamera(   new Vector3(-340, 172, 572), new Vector3(2, -8, 0)  );
        else if (name == "Saturn") changeCamera(    new Vector3(-772, 190, 591), new Vector3(25, -20, 0));
        else if (name == "Uranus") changeCamera(    new Vector3(-246, 169, 625), new Vector3(0,-18, 0)  );
        else if (name == "Neptune") changeCamera(   new Vector3(-103, 169, 705), new Vector3(0, -21, 0) );
        else if (name == "Pluto") changeCamera(     new Vector3(-599, 168, 815), new Vector3(-5, -60, 2));
        currentFocus = name;
    }

    // Update is called once per frame
    void Update() {

        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;

        if(Physics.Raycast(transform.position, forward, out hit)){
            timeCounter++;
            string hitObject = hit.collider.gameObject.name;
            print("DONE DONE DONE");
            /*if (timeCounter == 100){
                //Ak idem prvy krat na planetu
                if (hitObject != currentFocus) {
                    recognizePlanet(hitObject);
                    showText(hitObject);
                }
            }*/
            if (hitObject != currentFocus) {
                    recognizePlanet(hitObject);
                    showText(hitObject);
                }
        }
        else {
            timeCounter = 0;
        }
        if (currentFocus != ""){
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(GameObject.Find(currentFocus).transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        if (onScreen) {
            currentModal.SetActive(true);
        }
        else {
            currentModal.SetActive(false);
        }
        }
    }
}


