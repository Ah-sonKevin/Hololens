using UnityEngine;

public class RotateProxy : MonoBehaviour {
    /*public class UserRotationInfo
    {
        public long UserID;
        public GameObject proxy;
        public Transform proxyRotations;
    }
    // Use this for initialization
    void Start () {
        CustomMessages.Instance.MessageHandlers[CustomMessages.TestMessageID.StageTransform] = OnStageTransform;
     }

    private Dictionary<long, UserRotationInfo> remoteHeads = new Dictionary<long, UserRotationInfo>();

    public UserRotationInfo GetUserRotationInfo(long userId)
    {
        UserRotationInfo rotationInfo;

        // Get the rotation info if its already in the list, otherwise add it
        if (!remoteHeads.TryGetValue(userId, out rotationInfo))
        {
            rotationInfo = new UserRotationInfo();
            rotationInfo.UserID = userId;
            rotationInfo.proxy = this.gameObject;
            //headInfo.secCamera = headInfo.secCamera = GameObject.Find("HololensScondaryCamera").GetComponent<InverseProxy>().secCamera;
            remoteHeads.Add(userId, rotationInfo);
        }

        return rotationInfo;
    }


    void OnStageTransform(NetworkInMessage msg)
    {

        long userID = msg.ReadInt64();
        //msg.ReadInt64();

        UserRotationInfo rotationInfo = GetUserRotationInfo(userID);
        Quaternion rotation = CustomMessages.Instance.ReadQuaternion(msg);
        rotationInfo.proxy.transform.rotation = rotation;
    }
    */




    }
