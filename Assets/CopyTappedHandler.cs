using HoloToolkit.Sharing;
using HoloToolkit.Sharing.Spawning;
using HoloToolkit.Sharing.SyncModel;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class CopyTappedHandler : MonoBehaviour
{
   
    private GestureRecognizer recognizer;
    private SyncSpawnedObject original;
 //   public GameObject originalFolder;  
   public PrefabSpawnManager spawnManager;




    void Start()
    {
        this.original = null;
        recognizer = new GestureRecognizer();
        recognizer.SetRecognizableGestures(GestureSettings.Tap);
        
        this.recognizer.StartCapturingGestures();
    }

    private void Update()
    {
        if (true)
        {
            Debug.LogError(original);
            //Script to recognize Double tap                          
            //   originalFolder.SendMessage("PlaceObject", this.gameObject.transform.GetChild(0).gameObject, SendMessageOptions.RequireReceiver);
            if (original != null)
            {
                Debug.LogError("work");
               // original.GameObject.transform.rotation = this.transform.rotation;
                //original.GameObject.transform.rotation = this.gameObject.transform.rotation;
                //original.GameObject.transform.localScale = this.transform.localScale;
                //original.GameObject.transform.localScale = this.gameObject.transform.localScale;
                original.Transform.Rotation.Value = this.transform.rotation;
                original.Transform.Scale.Value = this.transform.localScale;

                
                
            }
            else
            {
             //   Debug.LogError("original is null");
            }
        }
    }

    public void SetOriginal(SyncSpawnedObject go)
    {

        Debug.LogError("SettingOriginal");
        this.original = go;
        Debug.LogError(original);
        
    }

    
}

