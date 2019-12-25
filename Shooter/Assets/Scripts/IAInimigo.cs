using UnityEngine;
using System.Collections;

public class IAInimigo : MonoBehaviour
{
    private GC scriptGC;

    private Rigidbody2D inimigoRb;
    private Animator inimigoAnimator;

    public float velocidade;
    private int direcao;

    public Transform arma;
    public GameObject tiroPrefab;
    public float forcaTiro;

    private int movimentoX;
    private int movimentoY;

    public float tempoCurva;
    public int chanceMudanca;
    private float tempTime;
    private int rand;

    public int chanceTiro;
    public float tempoTiro;
    private float tempTimeTiro;

    public int hp;

    public GameObject explosaoPrefab;

    public int pontosGanhos;

    public GameObject loot;
    public float chanceDeDrop; 

	// Use this for initialization
	void Start ()
    {
        scriptGC = FindObjectOfType(typeof(GC)) as GC;

        inimigoRb = GetComponent<Rigidbody2D>();
        inimigoAnimator = GetComponent<Animator>();
        movimentoY = -1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        tempTime += Time.deltaTime;
        tempTimeTiro += Time.deltaTime;

        if(tempTime >= tempoCurva)
        {
            tempTime = 0;
            rand = Random.Range(0, 100); //0 - 99
            if(rand <= chanceMudanca)
            {
                rand = Random.Range(0, 100); //0 - 99
                if(rand < 50)
                {
                    movimentoX = -1;
                    direcao = 1;
                }
                else
                {
                    movimentoX = 1;
                    direcao = -1;
                }
            }
            else
            {
                movimentoX = 0;
                direcao = 0;
            }
        }

        if(tempTimeTiro >= tempoTiro)
        {
            tempTimeTiro = 0;
            rand = Random.Range(0, 100); //0 - 99
            if(rand <= chanceTiro)
            {
                Atirar();
            }
        }

        inimigoAnimator.SetInteger("Direcao", direcao);
        inimigoRb.velocity = new Vector2(movimentoX * velocidade, movimentoY * velocidade);
	}

    void Atirar()
    {
        GameObject tempPrefab = Instantiate(tiroPrefab) as GameObject;
        tempPrefab.transform.position = arma.position;
        tempPrefab.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forcaTiro));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch(col.gameObject.tag)
        {
            case "TiroPersonagem":
                TomarDano(1);
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Player":
                explodir();
                break;
        }
    }

    void TomarDano(int danoTomado)
    {
        hp -= danoTomado;

        if(hp <= 0)
        {
            explodir();
        }
    }

    void explodir()
    {
        GameObject tempPrefab = Instantiate(explosaoPrefab) as GameObject;
        tempPrefab.transform.position = transform.position;
        tempPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocidade * -1);
        scriptGC.pontos += pontosGanhos;

        chanceMudanca = Random.Range(0, 100);
        if(chanceMudanca <= chanceDeDrop)
        {
           GameObject tempLoot = Instantiate(loot) as GameObject;
           tempLoot.transform.position = transform.position;
        }

        Destroy(this.gameObject);
    }
}
