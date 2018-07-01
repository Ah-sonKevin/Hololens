using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.Receivers;
using UnityEngine;

public class CubeToSphere : InteractionReceiver
{
    public  void TappedEvent() {
        Debug.LogError("Tapped");
        //this.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    protected override void InputDown(GameObject obj, InputEventData eventData)
    {
        
        Debug.Log(obj.name + " : InputDown");
      //  txt.text = obj.name + " : InputDown";
    }



}
