
using HoloToolkit.Sharing;
using HoloToolkit.Sharing.Spawning;
using HoloToolkit.Sharing.SyncModel;
using HoloToolkit.Sharing.Tests;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class TappedHandler : MonoBehaviour
{
    public PrefabSpawnManager spawnManager;
  
    private bool firstTap;
    
    private bool firstCopy = true;
    public GameObject copyFolder;
    SyncSpawnedObject obj = null;


    void Start()
    {
        firstTap = true;
        Debug.LogError(firstTap);
        // copyFolder = GameObject.Find("Copie");        
        this.recognizer = new GestureRecognizer();
        recognizer.SetRecognizableGestures(GestureSettings.DoubleTap | GestureSettings.Tap | GestureSettings.Hold);
        this.recognizer.TappedEvent += OnTapped;
        recognizer.HoldCompletedEvent += OnHoldComplete;

        this.recognizer.StartCapturingGestures();





        //Script to recognize Double tap

        /*Debug.Log(tapCount);
        if (tapCount == 2 && obj != null)
        {
            Debug.Log(obj.GameObject);
        // this.spawnManager.Delete(obj);
        //  obj = null;
        Color col = obj.GameObject.GetComponent<MeshRenderer>().material.color;
        col.a = 0.2f;
        obj.GameObject.GetComponent<MeshRenderer>().material.color = col;
            firstTap = true;
            Debug.Log(firstTap);            
        }*/



    }
    void OnTapped(InteractionSourceKind source, int tapCount, Ray headRay)
    {
       
        // If we're networking...
        // if (SharingStage.Instance.IsConnected)
        if (firstTap == true)
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
                //  this.gameObject.transform.GetChild(0).GetChild(0).gameObject,
                //   this.gameObject,
                this.gameObject,
              "SyncSpawnedObject",
              false);

        }

        //Script to recognize Double tap

        /*Debug.Log(tapCount);
        if (tapCount == 2 && obj != null)
        {
            Debug.Log(obj.GameObject);
        // this.spawnManager.Delete(obj);
        //  obj = null;
        Color col = obj.GameObject.GetComponent<MeshRenderer>().material.color;
        col.a = 0.2f;
        obj.GameObject.GetComponent<MeshRenderer>().material.color = col;
            firstTap = true;
            Debug.Log(firstTap);            
        }*/

        obj.GameObject.SendMessage("OnSelect");

    }
    GestureRecognizer recognizer;



    void OnHoldComplete(InteractionSourceKind source, Ray headRay)
    {
        if (firstCopy == true)
        {
            Debug.LogError("Hold");
            // If we're networking...
            // if (SharingStage.Instance.IsConnected)
            if (true)
            {
                //  CustomMessages.Instance.SendFlag();
                // FlagScript.ToggleFlag();
                //   GameObject child = this.gameObject.transform.GetChild(0).gameObject;

                // GameObject copie = Instantiate(copyFolder, transform.position + Vector3.right  , transform.rotation );

                GameObject copie = Instantiate(obj.GameObject, this.gameObject.transform.GetChild(0).transform.position + Vector3.right, transform.rotation, copyFolder.transform);
                copie.GetComponent<MeshRenderer>().material.color = Color.green;

                // copie.SendMessage("SetOriginal",obj, SendMessageOptions.RequireReceiver);
                Debug.LogError("Hold2");
                Debug.LogError(copie);
                firstCopy = false;
                // Color col = this.gameObject.GetComponent<MeshRenderer>().material.color;
                //col.a = 0.2f;
                //   this.gameObject.GetComponent<MeshRenderer>().material.color = col;
                //obj.GameObject.GetComponent<MeshRenderer>().material.color = col;
                // copie.GetComponent<Renderer>().material.color = Color.blue;

            }
        }
    }

    public void PlaceObject(GameObject go)
    {

        Vector3 pos = go.transform.position;
        Quaternion rotation = go.transform.rotation;
        Vector3 scale = go.transform.localScale;
        GameObject.Destroy(go);
        obj.GameObject.transform.position = pos;
        obj.GameObject.transform.rotation = rotation;
        obj.GameObject.transform.localScale = scale;

        obj.GameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        obj.GameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }
}