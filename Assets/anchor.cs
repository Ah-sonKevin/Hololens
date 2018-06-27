using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anchor : MonoBehaviour {

	// Use this for initialization
	void Start () {
        WorldAnchorManager.Instance.AttachAnchor(this.gameObject, "table");		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
