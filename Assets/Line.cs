using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {


    public GameObject headObject;
    void AddLineRenderer(GameObject headObject)
    {
        var lineRenderer = headObject.AddComponent<LineRenderer>();
        lineRenderer.useWorldSpace = false;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.5f;
        lineRenderer.positionCount = 2;
        
        lineRenderer.SetPosition(0, Vector3.forward * 10.2f);
        var material = new Material(Shader.Find("Particles/Additive"));
        Color col = colors[this.colorIndex++ % colors.Length];
        lineRenderer.material = material;
        lineRenderer.startColor = col;
        lineRenderer.endColor = col; 

    }

    const float maxRayDistance = 55.0f;
    int colorIndex = 0;
    static Color[] colors =
    {
       Color.green,
      Color.red,      
      Color.blue,
      Color.cyan,
      Color.magenta,
      Color.yellow
    };
    // Use this for initialization
    void Start () {
        AddLineRenderer(headObject);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
