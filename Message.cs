using HoloToolkit.Sharing;
using HoloToolkit.Sharing.Tests;
using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Message :  Singleton<Message>
{

   

    // Use this for initialization
    void Start () {
        Debug.LogError("StartMessage");
        CustomMessages.Instance.MessageHandlers[CustomMessages.TestMessageID.Flags] = this.OnGameObjIdRcv;
    }
	
     void OnGameObjIdRcv(NetworkInMessage msg) {
            Debug.LogError("It work");
            this.GetComponent<MeshRenderer>().material.color = Color.black;
            }

    // Update is called once per frame
    void Update () {
		
	}
}
