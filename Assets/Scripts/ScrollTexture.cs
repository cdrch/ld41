using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    public Vector2 scrollSpeed = Vector2.one;

    private Material mat;
    private Renderer renderer;

	// Use this for initialization
	void Start ()
    {
        renderer = GetComponent<Renderer>();
        mat = renderer.material;
	}
	
	// Update is called once per frame
	void Update ()
    {
        mat.mainTextureOffset += scrollSpeed * Time.deltaTime;
	}
}
