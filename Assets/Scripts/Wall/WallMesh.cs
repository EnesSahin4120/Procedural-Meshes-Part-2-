using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class WallMesh : MonoBehaviour
{
    private const float deformFactor = 0.0075f;
    private const int wallSize = 30;
    private const int frameCount = 30;

    private List<Vector3> vertices = new List<Vector3>();
    private List<Vector3> normals = new List<Vector3>();
    private List<int> triangles = new List<int>();
    private List<Vector2> uvs = new List<Vector2>();

    private MeshFilter meshFilter;
    private InteractableWall interactableWall;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        interactableWall = GetComponent<InteractableWall>();
    }

    private void OnEnable()
    {
        interactableWall.onIndicateDeform += Deforming;
    }

    private void OnDisable()
    {
        interactableWall.onIndicateDeform -= Deforming;
    }

    private void Start()
    {
        CreateWall();
    }

    private void Update()
    {
        UpdateMesh();
    }

    private void CreateWall() 
    {
        float frame = wallSize / frameCount;
        for (int i = 0; i < frameCount + 1; i++)
        {
            for (int j = 0; j < frameCount + 1; j++)
            {
                vertices.Add(new Vector3(j * frame, i * frame, 0));
                normals.Add(-Vector3.forward);
                uvs.Add(new Vector2(i / (float)frameCount, j / (float)frameCount));
            }
        }


        for (int i = 0; i < frameCount; i++)
        {
            for (int j = 0; j < frameCount; j++)
            {
                int currentIndex = (i * frameCount) + i + j;

                //Triangle 1
                triangles.Add(currentIndex);
                triangles.Add(currentIndex + frameCount + 1);
                triangles.Add(currentIndex + frameCount + 2);

                //Triangle 2
                triangles.Add(currentIndex);
                triangles.Add(currentIndex + frameCount + 2);
                triangles.Add(currentIndex + 1);
            }
        }
    }

    private void Deforming(Ball targetBall, Vector3 targetContactPoint) 
    {
        float ballRadius = targetBall.transform.localScale.x / 2f;
        for (int i = 0; i < vertices.Count; i++)
        {
            Vector3 currentVertex = vertices[i];
            float distance = (currentVertex - targetContactPoint).magnitude;
            if (distance < ballRadius + 0.1f)
            {
                currentVertex += Vector3.forward * targetBall.throwingFactor * (deformFactor / distance);
                vertices[i] = currentVertex;
            }
        }
    }

    private void UpdateMesh()
    {
        meshFilter.mesh.SetVertices(vertices);
        meshFilter.mesh.SetTriangles(triangles, 0);
        meshFilter.mesh.SetNormals(normals);
        meshFilter.mesh.SetUVs(0, uvs);
    }
}
