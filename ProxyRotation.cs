
using HoloToolkit.Sharing;
using HoloToolkit.Sharing.Tests;
using UnityEngine;

public class ProxyRotation : MonoBehaviour {

    private GameObject original; 

	// Use this for initialization
	void Start () {
      // float angle =  Vector3.Angle(Camera.main.transform.rotation.eulerAngles, GameObject.Find("HololensScondaryCamera").transform.rotation.eulerAngles);
        //this.gameObject.transform.GetChild(0).gameObject.transform.Rotate(Vector3.Lerp(Camera.main.transform.rotation.eulerAngles, GameObject.Find("HololensScondaryCamera").transform.rotation.eulerAngles,0.5f).normalized * angle);
    }

    public void sendOriginal(GameObject obj) {
      //   float angle =  Vector3.Angle(Camera.main.transform.rotation.eulerAngles, GameObject.Find("HololensScondaryCamera").transform.rotation.eulerAngles);
        float angle = Vector3.Angle(Camera.main.transform.rotation.eulerAngles,
            this.gameObject.transform.GetChild(0).gameObject.transform.rotation.eulerAngles);

        this.gameObject.transform.GetChild(0).LookAt(GameObject.Find("HololensScondaryCamera").transform);

       this.gameObject.transform.GetChild(0).gameObject.transform.Rotate(
           Vector3.Lerp(Camera.main.transform.rotation.eulerAngles, GameObject.Find("HololensScondaryCamera").transform.rotation.eulerAngles,0.5f)
           .normalized * angle);


    }

    // Update is called once per frame
    void Update () {
    }
}
