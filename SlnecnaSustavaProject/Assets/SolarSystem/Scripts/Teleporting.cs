using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public RaycastHit lastRaycastHit;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        
    }

    private GameObject GetLookedAtObject(){
        Vector3 origin = transform.position;
        Vector3 direction = Camera.main.transform.forward;
        float range = 1000;
        if (Physics.Raycast (origin,direction,out lastRaycastHit)){
            return lastRaycastHit.collider.gameObject;
        }
        else {
            return null;
        }
    }

    private void TeleportToLookAt() {
        transform.position = lastRaycastHit.point + lastRaycastHit.normal * 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            if (GetLookedAtObject() != null){
                TeleportToLookAt();
            }
        }
        
    }
}
