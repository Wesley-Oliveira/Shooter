using UnityEngine;
using System.Collections;

public class onTimer : MonoBehaviour
{
    public float tempoVida;
    private float tempTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        tempTime += Time.deltaTime;
        if(tempTime >= tempoVida)
        {
            Destroy(this.gameObject);
        }
	}
}
