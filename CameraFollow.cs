using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform playerTransform;
    Transform cameraTransform;
    public Vector3 offset;

	// Use this for initialization
	void Start ()
    {
        cameraTransform = GetComponent<Transform>();
        //playerTransform =  GameObject.Find("Player").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        cameraTransform.position = playerTransform.position + offset;
	}
}
