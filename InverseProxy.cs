using HoloToolkit.Sharing;
using HoloToolkit.Sharing.Tests;
using HoloToolkit.Unity;
using UnityEngine;


public class InverseProxy : MonoBehaviour
{

   public bool flag;
    public GameObject secCamera;
    public GameObject primaryCamera;


    // Use this for initialization
    void Start()
    {
        //flag = false;
        Debug.LogError("startInverseProxy");
        CustomMessages.Instance.MessageHandlers[CustomMessages.TestMessageID.CameraTransform] = UpdateCamera;
        flag = true;
    }

    private void UpdateCamera(NetworkInMessage msg)
    {
        Debug.LogError("UpdateCamera");
        Vector3 pos = CustomMessages.Instance.ReadVector3(msg);
        Quaternion rot = CustomMessages.Instance.ReadQuaternion(msg);
        //this.gameObject.transform.position = pos;
        //this.gameObject.transform.rotation = rot;
    }

    public void SetFlag() {
        Debug.LogError("SetFlag");
        flag = true; }
   

    public void Update()
    {


        if (flag) {
            //Debug.LogError("Update");
            //// Grab the current head transform and broadcast it to all the other users in the session
            //Transform cameraTranform = CameraCache.Main.transform;
            //// Transform the head position and rotation from world space into local space
            //Vector3 headPosition = transform.InverseTransformPoint(cameraTranform.position);
            //Quaternion headRotation = Quaternion.Inverse(transform.rotation) * cameraTranform.rotation;
            //CustomMessages.Instance.SendCameraTransform(headPosition, headRotation);

            Debug.LogError("Update");
            // Grab the current head transform and broadcast it to all the other users in the session
            Transform cameraTranform = CameraCache.Main.transform;
            // Transform the head position and rotation from world space into local space
            Vector3 headPosition = (cameraTranform.position);
            Quaternion headRotation = cameraTranform.rotation;
            //CustomMessages.Instance.SendCameraTransform(headPosition, headRotation);
        }

    }



}