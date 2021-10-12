using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class GeneratedMesh : MonoBehaviour
{
    public Vector3 Scale;
    [HideInInspector]
    public Vector3 CenterPoint;
    [HideInInspector]
    public Vector3 LocalCenterPoint;

    Vector3 scaleFactor
    {
        get
        {
            return Scale * 100;
        }
    }

//    const int scaleFactor = 100;

    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;


    public void GenerateMesh(int scaleMultiplier)
    {
        mesh = new Mesh();
        mesh.name = "Generated Mesh";
        this.GetComponent<MeshFilter>().mesh = mesh;
        Scale.x = scaleMultiplier;

        CreateShape();
        ScalingShape();
        UpdateMesh();

    }

    private void ScalingShape()
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = new Vector3(vertices[i].x * scaleFactor.x, vertices[i].y * scaleFactor.y, vertices[i].z * scaleFactor.z);
        }
    }

    private void CreateShape()
    {
        vertices = new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(0, 0, 1),
            new Vector3(1, 0, 0),
            new Vector3(1, 0, 1)
        };

        triangles = new int[]
        {
            0, 1, 2,
            1, 3, 2
        };
    }

    private void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        this.GetComponent<MeshCollider>().sharedMesh = mesh;
        mesh.RecalculateNormals();
        CenterPoint = this.GetComponent<MeshFilter>().mesh.bounds.size / 2;
    }
}
