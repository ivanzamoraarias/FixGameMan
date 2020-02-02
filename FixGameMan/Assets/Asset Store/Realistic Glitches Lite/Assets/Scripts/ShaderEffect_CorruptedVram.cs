using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class ShaderEffect_CorruptedVram : MonoBehaviour {

	public float shift = 10;
	private Texture texture;
	private Material material;

	void Awake ()
	{
		material = new Material( Shader.Find("Hidden/Distortion") );
		texture = Resources.Load<Texture>("Checkerboard-big");
		InvokeRepeating("Flicker",3.0f,2.0f);
	}
		
	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		material.SetFloat("_ValueX", shift);
		material.SetTexture("_Texture", texture);
		Graphics.Blit (source, destination, material);
	}

	void Update()
	{
		if(shift > -0.5f)
		shift = Mathf.Lerp(shift,-0.5f, Time.deltaTime * 2f);
		//else if(shift < -1.9f)
		//shift = Mathf.Lerp(shift, 2f, Time.deltaTime * 1f);

	}

	void Flicker()
	{
		shift = 2f;
	}
}
