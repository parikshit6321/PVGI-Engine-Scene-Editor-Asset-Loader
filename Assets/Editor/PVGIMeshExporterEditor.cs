using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PVGIMeshExporter))]
public class PVGIMeshExporterEditor : Editor {

	public override void OnInspectorGUI() {

		DrawDefaultInspector();

		if (GUILayout.Button ("Export Mesh")) {

			PVGIMeshExporter exporter = (PVGIMeshExporter)target;
			exporter.ExportMesh ();

		}

	}
}
