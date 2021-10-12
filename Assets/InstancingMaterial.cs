using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancingMaterial : MonoBehaviour
{
    public Color color;

    static private MaterialPropertyBlock props;

    // Start is called before the first frame update
    void Start()
    {
        if (props == null)
            props = new MaterialPropertyBlock();
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        props.SetColor("_Color", color);
        renderer.SetPropertyBlock(props);
    }
}
