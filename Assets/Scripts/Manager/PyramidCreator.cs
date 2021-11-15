using UnityEngine;

namespace ColoredGeometry
{
    internal sealed class PyramidCreator : MonoBehaviour
    {
        void Start()
        {
            Mesh mesh = GetComponent<MeshFilter>().mesh;
            Vector3[] vertices = mesh.vertices;

            for (var i = 0; i < vertices.Length; i++)
            {
                if (vertices[i].y > 0)
                {
                    vertices[i].x = 0;
                    vertices[i].z = 0;
                }
            }
            
            mesh.vertices = vertices;
        }
    }
}