using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class Draw : MonoBehaviour
{

    private GestureRecognizer recognizer;

    // Use this for initialization
    void Start()
    {
        this.recognizer = new GestureRecognizer();
        recognizer.SetRecognizableGestures(GestureSettings.Tap);
        this.recognizer.TappedEvent += OnTapped;
        this.recognizer.StartCapturingGestures();
    }


    void Update()
    {
        
    }


    // Update is called once per frame
    void OnTapped(InteractionSourceKind source, int tapCount, Ray headRay)
    {

        //Need to be ported to get gazeinput.
        if (((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            || Input.GetMouseButtonDown(0)))
        {

            Plane objPlane = new Plane(Camera.main.transform.forward * -1, this.transform.position);

            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (objPlane.Raycast(mRay, out rayDistance))
                this.transform.position = mRay.GetPoint(rayDistance);

        }

    }
}