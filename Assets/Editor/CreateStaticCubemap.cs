using UnityEngine;
using UnityEditor;
using System.Collections;

public class CreateStaticCubemap : ScriptableWizard {

	public Transform renderPosition;
	public Cubemap cubeMap;

	void OnWizardUpdate()
	{
		helpString = "Select transform to render from and cubemap to render into";
		isValid = renderPosition && cubeMap;
	}

	void OnWizardCreate()
	{
		GameObject go = new GameObject("Cubecam", typeof (Camera));

		go.transform.position = renderPosition.position;
		go.transform.rotation = Quaternion.identity;

		go.camera.RenderToCubemap(cubeMap);

		DestroyImmediate(go);
	}

	[MenuItem("Shader/RenderCubeMap")]
	public static void RenderCubemap()
	{
		ScriptableWizard.DisplayWizard("Render Cubemao", typeof(CreateStaticCubemap), "Rendre");
	}
}
