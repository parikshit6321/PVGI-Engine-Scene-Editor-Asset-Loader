using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// Number of vertices

// Number of Indices

// Vertex Data Start
// ..
// ..
// Vertex Data End

// Index Data Start
// ..
// ..
// Index Data End

public class PVGIMeshExporter : MonoBehaviour {

	public void ExportMesh () {

		string name = GetComponent<MeshRenderer> ().sharedMaterial.name.Split (' ')[0];

		StreamWriter writer = new StreamWriter(("Assets/Resources/" + name + "Mesh.txt"), false);

		Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
		long numberOfVertices = mesh.vertexCount;

		writer.Write (numberOfVertices + " ");

		long numberOfIndices = 0;

		for (int i = 0; i < mesh.subMeshCount; ++i) {
			numberOfIndices += mesh.GetIndexCount (i);
		}

		writer.Write (numberOfIndices + " ");

		Vector3[] vertexPositions = mesh.vertices;
		Vector3[] vertexNormals = mesh.normals;
		Vector4[] vertexTangents = mesh.tangents;
		Vector2[] vertexUV = mesh.uv;

		for (int i = 0; i < numberOfVertices; ++i) {
			writer.Write (vertexPositions [i].x + " " + vertexPositions [i].y + " " + vertexPositions [i].z + " ");
			writer.Write (vertexNormals[i].x + " " + vertexNormals[i].y + " " + vertexNormals[i].z + " ");
			writer.Write (vertexTangents[i].x + " " + vertexTangents[i].y + " " + vertexTangents[i].z + " ");
			writer.Write (vertexUV[i].x + " " + (1.0f - vertexUV[i].y) + " ");
		}

		for (int i = 0; i < mesh.subMeshCount; ++i) {
			int[] indexData = mesh.GetIndices (i);
			for (int j = 0; j < indexData.Length; ++j) {
				writer.Write (indexData [j] + " ");
			}
		}

		writer.Close ();
	}

}
