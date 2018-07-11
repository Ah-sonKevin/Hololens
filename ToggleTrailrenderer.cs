using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class ToggleTrailrenderer : MonoBehaviour {
    private GestureRecognizer recognizer;

    // Use this for initialization
    void Start () {
        this.recognizer = new GestureRecognizer();
        recognizer.SetRecognizableGestures(GestureSettings.DoubleTap | GestureSettings.Tap);
        this.recognizer.TappedEvent += OnTapped;
        this.recognizer.StartCapturingGestures();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTapped(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        // If we're networking...
        this.gameObject.GetComponent<TrailRenderer>().enabled = true;
    }
}
