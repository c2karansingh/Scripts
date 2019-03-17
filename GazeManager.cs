using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeManager : MonoBehaviour {

    public Vector3 cameraPosition;
    public Vector3 cameraDirection;
    public RaycastHit hitInfo;
    public Transform cameraTrans;


    static public GameObject currentFocused;
    private GameObject oldFocused;
    //flow of getting object values/components

    //get reference to the object
    //get reference of the component
    //fetch value

    // Use this for initialization
    void Start ()
    {

        cameraTrans = GetComponent<Transform>();

    }
	
	// Update is called once per frame
	void Update ()
    {

        //Get direction and origin of the user

        

        cameraPosition = cameraTrans.position;
        cameraDirection = cameraTrans.forward;
        //cameraTrans.forward vs Vector3.forward



        Debug.DrawRay(cameraPosition,cameraDirection,Color.red);

        //check if it hits an object
        if( Physics.Raycast(cameraPosition,cameraDirection,out hitInfo) )
        {
            // if it does, print object's name
            //Debug.Log("Hit object ");
            //Debug.Log(hitInfo.collider.gameObject.name );
            currentFocused = hitInfo.collider.gameObject;
            
        }
        else
        {
            currentFocused = null;
        }




        
    }
}
