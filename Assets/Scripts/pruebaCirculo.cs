using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class pruebaCirculo : MonoBehaviour
{
    private enum Distance
    {
        //valor default 0,1
        Space,XYPlane
    }
    [SerializeField]
    private GameObject objeto1;
    [SerializeField]
    private GameObject objeto2;
    [SerializeField]
    private TextMesh distanceIndicator;
    [SerializeField]
    private Distance distanceType;

    private float distance;
    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, objeto1.transform.position);
        lineRenderer.SetPosition(1, objeto2.transform.position);

        switch(distanceType)
        {
            case Distance.Space:
                distance = CalculateDistanceInSpace();
                distanceIndicator.text = "Distance en" + distance.ToString();
                break;
            case Distance.XYPlane:
                distance = CalculateDistanceXYPlane();
                distanceIndicator.text = "Distance en xy" + distance.ToString();
                break;
        }
        
    }
    private float CalculateDistanceInSpace()
    {
        return Vector3.Distance(objeto1.transform.position, objeto2.transform.position);
    }
    private float CalculateDistanceXYPlane()
    {
        Vector2 v1 = new Vector2(objeto1.transform.position.x, objeto1.transform.position.y);
        Vector2 v2 = new Vector2(objeto2.transform.position.x, objeto2.transform.position.y);
        return Vector2.Distance(v1, v2);
    }
}
