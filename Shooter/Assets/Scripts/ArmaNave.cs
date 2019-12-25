using UnityEngine;
using System.Collections;

public class ArmaNave : MonoBehaviour
{
    public Transform arma;
    public GameObject tiroPrefab;
    public float forcaTiro;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Atirar();
        }
    }

    void Atirar()
    {
        GameObject tempPrefab = Instantiate(tiroPrefab) as GameObject;
        tempPrefab.transform.position = arma.position;
        tempPrefab.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forcaTiro));
    }
}
