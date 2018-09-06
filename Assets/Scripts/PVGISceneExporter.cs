using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

// Scene Name 

// Camera Position

// Sun Light Direction

// Sun Light Strength = Color * Intensity

// Number of objects

// Object Mesh
// Object DiffuseOpacity Texture
// Object NormalRoughness Texture
// Object World Position
// Object World Rotation
// Object World Scaling

// Object Mesh
// Object DiffuseOpacity Texture
// Object NormalRoughness Texture
// Object World Position
// Object World Rotation
// Object World Scaling

// ..
// ..
// ..

public class PVGISceneExporter : MonoBehaviour {
	
	public void ExportScene() {

		string sceneName = SceneManager.GetActiveScene ().name;

		StreamWriter writer = new StreamWriter(("Assets/Resources/" + sceneName + ".txt"), false);

		GameObject camera = GameObject.FindGameObjectWithTag ("MainCamera");
		GameObject light = GameObject.FindGameObjectWithTag ("Light");
		GameObject[] renderObjects = GameObject.FindGameObjectsWithTag ("RenderObject");

		writer.Write (sceneName + " ");

		writer.Write (camera.transform.position.x + " " + camera.transform.position.y + " " + camera.transform.position.z + " ");

		writer.Write (light.transform.forward.x + " " + light.transform.forward.y + " " + light.transform.forward.z + " ");

		Vector3 lightStrength = Vector3.zero;
		lightStrength.x = (light.GetComponent<Light> ().color.r * light.GetComponent<Light> ().intensity);
		lightStrength.y = (light.GetComponent<Light> ().color.g * light.GetComponent<Light> ().intensity);
		lightStrength.z = (light.GetComponent<Light> ().color.b * light.GetComponent<Light> ().intensity);

		writer.Write (lightStrength.x + " " + lightStrength.y + " " + lightStrength.z + " ");

		writer.Write (renderObjects.Length + " ");

		string name = null;

		for (int i = 0; i < renderObjects.Length; ++i) {

			name = renderObjects[i].GetComponent<MeshRenderer> ().sharedMaterial.name.Split (' ')[0];
			writer.Write (name + "Mesh" + " ");
			writer.Write (name + "DiffuseOpacity" + " ");
			writer.Write (name + "NormalRoughness" + " ");
			writer.Write (renderObjects[i].transform.position.x + " " + renderObjects[i].transform.position.y + " " + renderObjects[i].transform.position.z + " ");
			writer.Write (renderObjects[i].transform.rotation.x + " " + renderObjects[i].transform.rotation.y + " " + renderObjects[i].transform.rotation.z + " " + renderObjects[i].transform.rotation.w + " ");
			writer.Write (renderObjects[i].transform.localScale.x + " " + renderObjects[i].transform.localScale.y + " " + renderObjects[i].transform.localScale.z + " ");
		
		}

		writer.Close ();

	}

}
