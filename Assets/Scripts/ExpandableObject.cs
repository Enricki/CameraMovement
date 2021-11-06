using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandableObject : MonoBehaviour, I_Expandable
{
    [HideInInspector]
    public Vector3 CenterPoint;
    [HideInInspector]
    public Vector3 boundSize;

    private void Awake()
    {
        boundSize = this.GetComponent<MeshFilter>().mesh.bounds.size * this.transform.localScale.x;
        boundSize.y = 0.1f;
        Debug.Log(boundSize);
        CenterPoint = boundSize / 2;
    }

    public void Expand(float scaleFactor)
    {
        this.transform.position = new Vector3(scaleFactor * boundSize.x / 2,
            transform.position.y,
            transform.position.z);
        this.transform.localScale = new Vector3(
            scaleFactor * boundSize.x, boundSize.y, boundSize.z);
    }
}
