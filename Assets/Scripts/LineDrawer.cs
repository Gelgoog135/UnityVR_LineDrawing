using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineDrawer : MonoBehaviour
{
	private LineRenderer lineRenderer;

	[SerializeField]
	private GameObject controller;

	[SerializeField]
	private Text txtDistance;
	private double distance;

	private bool isDrawing;
	private int lineCount = 1;

    // Start is called before the first frame update
    void Start()
    {
    	// Use the current Line Renderer in the GameObject
        // lineRenderer = GetComponent<LineRenderer>();
        // lineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
        {
    		var controllerPos = controller.transform.position;
        	if(!isDrawing)
        	{
        		isDrawing = true;
        		GameObject go = new GameObject("LineRenderer_" + lineCount.ToString());
        		lineCount++;

		        lineRenderer = go.AddComponent<LineRenderer>();
		        lineRenderer.startWidth = 0.02F;
		        lineRenderer.endWidth = 0.02F;
            	lineRenderer.useWorldSpace = true;
		        lineRenderer.positionCount = 2;

        		lineRenderer.SetPosition(0, controllerPos);
        	}
        	else
        	{
        		isDrawing = false;
        	}

        }

        if(isDrawing)
        {
    		var controllerPos = controller.transform.position;
    		lineRenderer.SetPosition(1, controllerPos);
    		var pos = lineRenderer.GetPosition(0);
			var pos2 = lineRenderer.GetPosition(1);
    		// txtDistance.text = pos.x.ToString("F2") + ", " + pos.y.ToString("F2") + ", " + pos.z.ToString("F2") + "\n" + pos2.x.ToString("F2") + ", " + pos2.y.ToString("F2") + ", " + pos2.z.ToString("F2");
        	txtDistance.text = (pos2 - pos).magnitude.ToString("F2");
        }
    }
}
