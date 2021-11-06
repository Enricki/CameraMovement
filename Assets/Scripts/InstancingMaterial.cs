using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancingMaterial : MonoBehaviour
{
    static private MaterialPropertyBlock props;

    public void SetMaterialProps(Color color, float metallicRatio, float glossiness)
    {
        if (props == null)
            props = new MaterialPropertyBlock();
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        props.SetColor("_Color", color);
        props.SetFloat("_Glossiness", glossiness);
        props.SetFloat("_Metallic", metallicRatio);
        renderer.SetPropertyBlock(props);
    }
}
