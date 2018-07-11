using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sampleScript2 : MonoBehaviour {
    [SerializeField] Transform target;

    void Update()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);
       transform.rotation = target.rotation;
        transform.localPosition = target.localPosition;
    }
    // Use this for initialization
    void Start () {
		
	}

}
