using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PVGISceneExporter))]
public class PVGISceneExporterEditor : Editor {

	public override void OnInspectorGUI() {

		DrawDefaultInspector();

		if (GUILayout.Button ("Export Scene")) {

			PVGISceneExporter exporter = (PVGISceneExporter)target;
			exporter.ExportScene ();

		}

	}
}
