
using HoloToolkit.Sharing;
using HoloToolkit.Sharing.Spawning;
using HoloToolkit.Sharing.SyncModel;
using HoloToolkit.Sharing.Tests;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class PlaceObjec : MonoBehaviour {


    private bool firstTap;
    GestureRecognizer recognizer;

    // Use this for initialization
    void Start () {
        firstTap = true;
        Debug.LogError(firstTap);
        // copyFolder = GameObject.Find("Copie");        
        this.recognizer = new GestureRecognizer();
        recognizer.SetRecognizableGestures(GestureSettings.DoubleTap | GestureSettings.Tap | GestureSettings.Hold);
        this.recognizer.TappedEvent += OnTapped;

        this.recognizer.StartCapturingGestures();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTapped(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        this.gameObject.transform.position = GazeManager.Instance.HitPosition + GazeManager.Instance.GazeNormal * 0.01f;
        // If we're networking...
        // if (SharingStage.Instance.IsConnected)
       


    }
}
