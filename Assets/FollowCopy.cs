using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCopy : MonoBehaviour {

    public GameObject copie;
    public Transform copie;
    // Use this for initialization
    void Start () {
        copie = GameObject.Find("Copie");
        meeple = copie.transform.GetChild(0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
