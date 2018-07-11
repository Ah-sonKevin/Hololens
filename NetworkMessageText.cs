using HoloToolkit.Sharing;
using UnityEngine;

public class NetworkMessageText : MonoBehaviour {
    private TextMesh textMesh;

    // Use this for initialization
    void Start () {
        textMesh = gameObject.GetComponentInChildren<TextMesh>();
    }

   
    public void LogMessage(NetworkInMessage message)
    {
        Debug.Log("NetworkMessage");
        if (textMesh.text.Length > 3000)
        {
            textMesh.text = message.ToString() + "\n";
        }
        else
        {
            textMesh.text += message.ToString() + "\n";
        }
    }

    public void LogMessage(string message)
    {
        Debug.Log("NetworkMessage");
        if (textMesh.text.Length > 3000)
        {
            textMesh.text = message + "\n";
        }
        else
        {
            textMesh.text += message +"\n";
        }
    }
}
