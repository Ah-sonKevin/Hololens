using System.Collections;
using System.Collections.Generic;



using HoloToolkit.Sharing;
using HoloToolkit.Sharing.Spawning;
using HoloToolkit.Sharing.Tests;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class CubeInitial : MonoBehaviour {

    SyncSpawnedObject obj = null;
    public PrefabSpawnManager spawnManager;

    // Use this for initialization
    void Start () {

        Debug.Log("********************* Spawn ***************************** Start");

        //if (SharingStage.Instance.IsConnected)
        if(true)
        {
            Debug.Log("********************* Spawn *****************************");

            // Make a new cube that is 2m away in direction of gaze but then get that position
            // relative to the object that we are attached to (which is world anchor'd across
            // our devices).
            var newCubePosition = this.gameObject.transform.position;
             


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

            Debug.Log(obj);

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
    }

    // Update is called once per frame
    void Update () {
		
	}
}
