using UnityEngine;
using System.Collections;

//SCRIPT PARA ROTACIONAR UMA TEXTURA E DAR IMPRESSÃO DE MOVIMENTO
public class MoveOffSet : MonoBehaviour
{
    private Material currentMaterial;
    public float speed;
    private float offSet;

	// Use this for initialization
	void Start ()
    {
        currentMaterial = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        offSet += speed * 0.001f;

        currentMaterial.SetTextureOffset("_MainTex", new Vector2(0, offSet));
	}
}
