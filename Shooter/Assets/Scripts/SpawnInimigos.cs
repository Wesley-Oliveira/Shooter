using UnityEngine;
using System.Collections;

public class SpawnInimigos : MonoBehaviour
{
    public GameObject inimigoPrefab;
    public float tempoSpawn;
    public Transform limiteEsquerdo, limiteDireito;
    
    private float minX, maxX, tempTime;

    // Use this for initialization
    void Start ()
    {
        minX = limiteEsquerdo.position.x;
        maxX = limiteDireito.position.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
        tempTime += Time.deltaTime;	

        if(tempTime >= tempoSpawn)
        {
            tempTime = 0;
            Spawn();
        }        
	}

    void Spawn()
    {
        GameObject tempPrefab = Instantiate(inimigoPrefab) as GameObject;

        float posX = Random.Range(minX, maxX);
        tempPrefab.transform.position = new Vector3(posX, transform.position.y,transform.position.z);
    }
}
