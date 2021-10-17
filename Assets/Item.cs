using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Item : MonoBehaviour, IPointerClickHandler
{
    public Color defaultColor;
    public InstancingMaterial material;
    private Pool parentPool;

    public UnityEvent onItemSelected;
    public UnityEvent onItemDeselected;

    public void OnPointerClick(PointerEventData eventData)
    {
        parentPool.OnItemSelected(this);
    }

    public void Select()
    {
        if (onItemSelected != null)
        {
            onItemSelected.Invoke();
        }
    }

    public void Deselect()
    {
        if (onItemDeselected != null)
        {
            onItemDeselected.Invoke();
        }
    }


    private void Awake()
    {
        material = this.GetComponent<InstancingMaterial>();
        Color color = Random.ColorHSV();
        defaultColor = color;
        material.SetMaterialProps(color, 0, 0.5f);
    }

    private void Start()
    {
        parentPool = this.GetComponentInParent<Pool>();
        Debug.Log(parentPool);
    }





}
