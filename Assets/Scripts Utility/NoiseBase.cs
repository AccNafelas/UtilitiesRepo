using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseBase : MonoBehaviour
{
	[Header("Noise")]
	public float amplitude = 5f;
	public float offset = 0f;
	public float NoiseSize = 500f;
	public float scale = 30f;

    private void Awake()
    {
		AwakeSingleton();    
    }

    public float GetXPerlin(float y)
	{
		float yCoord = (float)(y / NoiseSize * scale);

		float x = Mathf.PerlinNoise(0, yCoord) * amplitude;

		return x;
	}

	public static NoiseBase instance;
	void AwakeSingleton()
	{
		if (instance == null)
			instance = this;
		else
			Destroy(this.gameObject);
	}
}
