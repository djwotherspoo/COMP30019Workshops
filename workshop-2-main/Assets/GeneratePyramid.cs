// COMP30019 - Graphics and Interaction
// (c) University of Melbourne, 2022

using System.Linq;
using UnityEngine;

// Note: The attribute below specifies that this component must coexist with a
// MeshFilter component on the same game object. If it doesn't exist, the Unity
// engine will create one automatically.

[RequireComponent(typeof(MeshFilter))]
public class GeneratePyramid : MonoBehaviour
{


    public float height = 1f;
    public int points = 3;


    private void Start()
    {
        // First we'll get the MeshFilter attached to this game object, in the
        // same way that we got the MeshRenderer component last week.
        var meshFilter = GetComponent<MeshFilter>();
        
        // Now we can create a cube mesh and assign it to the mesh filter.
        meshFilter.mesh = CreateMesh();
    }

    private Mesh CreateMesh()
    {
        // Step 0: Create the mesh object. This contains various data structures
        // that allow us to define complex 3D objects. Recommended reading:
        // - https://docs.unity3d.com/ScriptReference/Mesh.html
        var mesh = new Mesh
        {
            name = "Pyramid"
        };

        int ava = 6;

        Vector3[] vertexs = new Vector3[points*ava];
        Color[] colours = new Color[points*ava];

        float offset = (3.14f*2)/points;

        for(int i = 0; i < points; i++){
            vertexs[i*ava] = new Vector3(0.0f, height, 0.0f);
            vertexs[i*ava + 1] = new Vector3(Mathf.Cos(offset*i), -1.0f, Mathf.Sin(offset*i));
            vertexs[i*ava + 2] = new Vector3(Mathf.Cos(offset*(i+1)), -1.0f, Mathf.Sin(offset*(i+1)));

            colours[i*ava] = Color.blue;
            colours[i*ava + 1] = Color.blue;
            colours[i*ava + 2] = Color.blue;

            vertexs[i*ava + 4] = new Vector3(Mathf.Cos(offset*i), -1.0f, Mathf.Sin(offset*i));
            vertexs[i*ava + 3] = new Vector3(0.0f, -1f, 0.0f);
            
            vertexs[i*ava + 5] = new Vector3(Mathf.Cos(offset*(i+1)), -1.0f, Mathf.Sin(offset*(i+1)));

            colours[i*ava + 3] = Color.blue;
            colours[i*ava + 4] = Color.blue;
            colours[i*ava + 5] = Color.blue;
        }

        mesh.SetVertices(vertexs);

        mesh.SetColors(colours);

        int[] indices = new int[mesh.vertices.Length];
        for(int i = 0; i < mesh.vertices.Length/3; i++){
            indices[i*3] = (i*3+1);
            indices[i*3+1] = (i*3);
            indices[i*3+2] = (i*3+2);
        }

        mesh.SetIndices(indices, MeshTopology.Triangles, 0);
        
        // Note that the topology argument specifies that we are in fact
        // defining *triangles* in our indices array. It is also possible to
        // define the mesh surface using quads (MeshTopology.Quads).

        return mesh;
    }
}
