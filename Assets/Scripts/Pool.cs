using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField]
    private int poolSize;
    [SerializeField]
    private float ItemHight;
    [SerializeField]
    private Item ItemPrefab;
    [SerializeField]
    private CameraController Camera;
    [SerializeField]
    private ExpandableUI expandableSlider;

    public Item selectedItem;
    private GeneratedMesh generatedMesh;
    private ExpandableObject expandablePool; 

    private List<Item> Items = new List<Item>();
    private Vector3 spawnPosition;
    private float itemDistance;
    


    private void Start()
    {
        expandablePool = this.GetComponent<ExpandableObject>();
        

        expandablePool.Expand(poolSize);
        expandableSlider.Expand(poolSize);
        spawnPosition = new Vector3(expandablePool.CenterPoint.x, ItemHight, 0);
        itemDistance = expandablePool.boundSize.x * poolSize;
        Camera.RightBound = itemDistance;

        //        generatedMesh = this.GetComponent<GeneratedMesh>();
        //        generatedMesh.GenerateMesh(1);
        //        spawnPosition = generatedMesh.CenterPoint;
        //        generatedMesh.GenerateMesh(poolSize);
        //        itemDistance = generatedMesh.GetComponent<MeshFilter>().mesh.bounds.size.x;

        selectedItem = null;
        for (int i = 0; i < poolSize; i ++)
        {
            SpawnItems(i);
        }
    }

    private void SpawnItems(int i)
    {
        Items.Add(Instantiate(ItemPrefab));
        Items[i].transform.parent = this.transform;
        Items[i].transform.position = spawnPosition;
        Items[i].name = "Item " + i;
        spawnPosition.x += itemDistance / poolSize;
    }

    public void OnItemSelected(Item item)
    {
        OnItemDeselected(item);
        selectedItem = item;
        selectedItem.Select();
        selectedItem.material.SetMaterialProps(selectedItem.defaultColor, 1, 0.5f);
        Camera.ZoomingCamera(selectedItem.transform.position.x, -30, 175, -50);
        Camera.CanMove = false;
        Debug.Log(selectedItem.name);

    }

    public void OnItemDeselected(Item item)
    {
        if (selectedItem != null)
        {
            selectedItem.material.SetMaterialProps(selectedItem.defaultColor, 0, 0.5f);
            Camera.ZoomingCamera(selectedItem.transform.position.x, 0, 0, 0);
            selectedItem.Deselect();
            Camera.CanMove = true;
        }
    }

}
