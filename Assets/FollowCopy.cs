using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCopy : MonoBehaviour
{

    public GameObject copie;
    public Transform copyTransform;
    // Use this for initialization
    void Start()
    {
        copie = GameObject.Find("Copie");

        // meeple = copie.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (copie.transform.childCount >0 && copie.transform.GetChild(0) != null)
        {
            copyTransform = copie.transform.GetChild(0);

            this.gameObject.transform.rotation = copyTransform.rotation;
            this.gameObject.transform.localScale = copyTransform.localScale;
        }
    }
}