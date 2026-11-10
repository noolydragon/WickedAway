using UnityEngine;

[ExecuteInEditMode] // This makes it work inside the Scene View too!
public class ExpandWaterBounds : MonoBehaviour
{
    private MeshFilter meshFilter;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        FixBounds();
    }

    void Update()
    {
        FixBounds();
    }

    void FixBounds()
    {
        if (meshFilter != null && meshFilter.sharedMesh != null)
        {
            meshFilter.sharedMesh.bounds = new Bounds(Vector3.zero, new Vector3(1000f, 200f, 1000f));
        }
    }
}