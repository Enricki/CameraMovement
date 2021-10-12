using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    InstancingMaterial material;

    private void Awake()
    {
        material = GetComponent<InstancingMaterial>();
        Color color = Random.ColorHSV();
        material.color = color;
    }

}
