using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;


public class GestureManager : MonoBehaviour
{

    
    
    GestureRecognizer recognizer;

    void Start()
    {

        recognizer = new GestureRecognizer();

        recognizer.Tapped += tappedDetected;

        recognizer.StartCapturingGestures();

    }

   

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dropObject();
        }
    }
   
    void dropObject()
    {
        if (GazeManager.currentFocused != null)
        {
            Rigidbody rb = GazeManager.currentFocused.GetComponent<Rigidbody>();
            rb.useGravity = true;

        }

    }

    private void tappedDetected(TappedEventArgs obj)
    {
        dropObject();

        

    }
}