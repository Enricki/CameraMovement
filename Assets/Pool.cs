using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public int poolSize;
    public float ItemHight;
    public Item ItemPrefab;
    List<GameObject> Items = new List<GameObject>();
    public GeneratedMesh generatedMesh;
    Vector3 spawnPosition;
    float itemDistance;



    private void Start()
    {

        generatedMesh = this.GetComponent<GeneratedMesh>();

        generatedMesh.GenerateMesh(1);
        spawnPosition = generatedMesh.CenterPoint;
        spawnPosition.y = ItemHight;

        generatedMesh.GenerateMesh(poolSize);

        itemDistance = generatedMesh.GetComponent<MeshFilter>().mesh.bounds.size.x;

        for (int i = 0; i < poolSize; i ++)
        {
            SpawnItems(i);
        }
    }

    private void SpawnItems(int i)
    {
        Items.Add(Instantiate(ItemPrefab).gameObject);
        Items[i].transform.parent = this.transform;
        Items[i].transform.position = spawnPosition;
        Items[i].name = "Item " + i;
        spawnPosition.x += itemDistance / poolSize;
    }
}
