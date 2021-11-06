using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ExpandableUI : MonoBehaviour, I_Expandable
{
    public ExpandableObject expandbalePool;
    RectTransform transformer;
    public void Expand(float scaleFactor)
    {
        //this.transformer.position = new Vector3(
        //    scaleFactor * boundSize.x / 2,
        //    transform.position.y,
        //    transform.position.z);
        //this.transform.localScale = new Vector3(
        //    scaleFactor * boundSize.x, boundSize.y, boundSize.z);
    }
}
