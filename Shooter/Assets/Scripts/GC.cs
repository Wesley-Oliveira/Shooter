using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GC : MonoBehaviour
{
    public Text pontuacao;
    public int pontos;

    public int vidasExtras;
    public GameObject iconeVida;
    public Transform vidasExtrasIcones;
    public GameObject[] extras;

    public GameObject player;
    public Transform spawnPlayer;

    // Use this for initialization
    void Start ()
    {
        Vidas();
	}
	
	// Update is called once per frame
	void Update ()
    {
        pontuacao.text = pontos.ToString();	
	}

    void Vidas()
    {
        
        GameObject tempVida;
        float posXIco;

        foreach (GameObject v in extras)
        {
            if (v != null)
            {
                Destroy(v);
            }
        }

        for (int i = 0; i < vidasExtras; i++)
        {
            posXIco = vidasExtrasIcones.position.x + (0.7f * i);
            tempVida = Instantiate(iconeVida) as GameObject;
            extras[i] = tempVida;
            tempVida.transform.position = new Vector3(posXIco, vidasExtrasIcones.position.y, vidasExtrasIcones.position.z);
        }

        GameObject tempPlayer = Instantiate(player) as GameObject;
        tempPlayer.transform.position = spawnPlayer.position;
        tempPlayer.name = "Player";
    }        

    public void Morreu()
    {
        vidasExtras -= 1;
        if (vidasExtras >= 0)
        {
            Vidas();
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
