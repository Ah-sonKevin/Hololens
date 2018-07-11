using Academy.HoloToolkit.Sharing;
using HoloToolkit.Sharing;
using HoloToolkit.Sharing.Tests;
using UnityEngine;

public class SendTransformScript : MonoBehaviour {

    /// <summary>
    /// Tracks if we have been sent a transform for the model.
    /// The model is rendered relative to the actual anchor.
    /// </summary>
    public bool GotTransform { get; private set; }
    public GameObject ShowText;


    // Use this for initialization
    void Start () {
        GotTransform = true;
        Debug.LogError("here is SendTrqnsfor,ScriptStqrt");
        ShowText.SendMessage("LogMessage", "StartSendTransformScript", SendMessageOptions.RequireReceiver);
        Debug.LogError("StartSendTransformScript");
        // We care about getting updates for the model transform.
        CustomMessages.Instance.MessageHandlers[CustomMessages.TestMessageID.StageTransform] = this.OnStageTransform;
        
        // And when a new user join we will send the model transform we have.
        SharingSessionTracker.Instance.SessionJoined += Instance_SessionJoined;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// When a new user joins we want to send them the relative transform for the model if we have it.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Instance_SessionJoined(object sender, SharingSessionTracker.SessionJoinedEventArgs e)
    {
        if (GotTransform)
        {
            CustomMessages.Instance.SendStageTransform(transform.localPosition, transform.localRotation);
            ShowText.SendMessage("LogMessage", "SendStageTransform",SendMessageOptions.RequireReceiver);
            Debug.LogError("SendStageTransform");
        }
    }


    /// <summary>
    /// When a remote system has a transform for us, we'll get it here.
    /// </summary>
    /// <param name="msg"></param>
    void OnStageTransform(NetworkInMessage msg)
    {
        // We read the user ID but we don't use it here.
        msg.ReadInt64();
        ShowText.SendMessage("LogMessage", msg, SendMessageOptions.RequireReceiver);
        Debug.LogError("StartNetworkMessage");
        Debug.LogError(msg);
        Debug.LogError(msg.ToString());
        Debug.LogError("EndNetworkMessage");
        transform.localPosition = CustomMessages.Instance.ReadVector3(msg);
        transform.localRotation = CustomMessages.Instance.ReadQuaternion(msg);
        GotTransform = true;
    }


    
}
