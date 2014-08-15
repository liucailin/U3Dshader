using UnityEngine;
using System.Collections;

public class GLTest : MonoBehaviour
{

	public Material mat;

	bool flagTex = true;

	void Awake()
	{
		CreateMaterial();

	}

	void CreateMaterial() 
	{
		if( !mat ) 
		{
			mat = new Material( "Shader \"Lines/Colored Blended\" {" +
			                            "SubShader { Pass { " +
			                            "    Blend SrcAlpha OneMinusSrcAlpha " +
			                            "    ZWrite Off Cull Off Fog { Mode Off } " +
			                            "    BindChannels {" +
			                            "      Bind \"vertex\", vertex Bind \"color\", color }" +
			                            "} } }" );
			mat.hideFlags = HideFlags.HideAndDontSave;
			mat.shader.hideFlags = HideFlags.HideAndDontSave;
		}
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Space))
			if (flagTex)
				flagTex = false;
		else
			flagTex = true;
		
	}

	void OnPostRender ()
	{
		if (!mat) 
		{
			Debug.LogError ("Please Assign a material on the inspector");
			return;
		}

		GL.PushMatrix();
		mat.SetPass(0);
		GL.LoadOrtho();
		GL.Begin(GL.QUADS);
		if (flagTex)
			GL.MultiTexCoord(0, new Vector3(0, 0, 0));
		else
			GL.MultiTexCoord(1, new Vector3(0, 0, 0));
		GL.Vertex3(0.25F, 0.25F, 0);
		if (flagTex)
			GL.MultiTexCoord(0, new Vector3(0, 1, 0));
		else
			GL.MultiTexCoord(1, new Vector3(0, 1, 0));
		GL.Vertex3(0.25F, 0.75F, 0);
		if (flagTex)
			GL.MultiTexCoord(0, new Vector3(1, 1, 0));
		else
			GL.MultiTexCoord(1, new Vector3(1, 1, 0));
		GL.Vertex3(0.75F, 0.75F, 0);
		if (flagTex)
			GL.MultiTexCoord(0, new Vector3(1, 0, 0));
		else
			GL.MultiTexCoord(1, new Vector3(1, 0, 0));
		GL.Vertex3(0.75F, 0.25F, 0);
		GL.End();
		GL.PopMatrix();
	}

}
