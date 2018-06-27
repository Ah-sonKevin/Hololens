
using HoloToolkit.Sharing;
using HoloToolkit.Sharing.Spawning;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class DeleteandHoldHandler : MonoBehaviour
{
    public PrefabSpawnManager spawnManager;
    private bool firstTap = true;
    SyncSpawnedObject obj = null;
    

    void Start()
    {
       
        this.recognizer = new GestureRecognizer();
        recognizer.SetRecognizableGestures(GestureSettings.DoubleTap|GestureSettings.Tap | GestureSettings.Hold);
        this.recognizer.TappedEvent += OnTapped;
        this.recognizer.HoldCompletedEvent += OnHoldComplete;

        this.recognizer.StartCapturingGestures();
    }
    void OnTapped(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        // If we're networking...
        if (SharingStage.Instance.IsConnected && firstTap == true)
        {
            Debug.Log("********************* Spawn *****************************");
            firstTap = false;
            // Make a new cube that is 2m away in direction of gaze but then get that position
            // relative to the object that we are attached to (which is world anchor'd across
            // our devices).
            var newCubePosition =
              this.gameObject.transform.InverseTransformPoint(
                (GazeManager.Instance.GazeOrigin + GazeManager.Instance.GazeNormal * 2.0f));


            // Use the span manager to span a 'SyncSpawnedObject' at that position with
            // some random rotation, parent it off our gameObject, give it a base name (MyCube)
            // and do not claim ownership of it so it stays behind in the scene even if our
            // device leaves the session.
            obj = new SyncSpawnedObject();
            this.spawnManager.Spawn(
              obj,
              newCubePosition,
              Random.rotation,
              this.gameObject.transform.GetChild(0).gameObject,
              "SyncSpawnedObject",
              false);
        }
       
            //Script to recognize Double tap

            //Debug.Log(tapCount);
            if (tapCount == 2 && obj != null)
            {
                Debug.Log(obj.GameObject);
                this.spawnManager.Delete(obj);
                obj = null;
                firstTap = true;
                Debug.Log(firstTap);            
            }


    }
    GestureRecognizer recognizer;



    void OnHoldComplete(InteractionSourceKind source, Ray headRay)
    {
        // If we're networking...
        if (SharingStage.Instance.IsConnected)



        {
            Debug.Log(this.gameObject.name);
            GameObject child = this.gameObject.transform.GetChild(0).gameObject;
            
            GameObject copie = Instantiate(child, child.transform.position + Vector3.right  , child.transform.rotation );
            //GameObject copie = Instantiate(child);

            Color theColorToAdjust = Color.blue;
            theColorToAdjust.a = 0.5f; 
           


            this.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = theColorToAdjust;
           

            Debug.Log("Hold");
            Debug.Log(this.gameObject.transform.GetChild(0).gameObject.name);

        }
    }
}