using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private GC scriptGC;

    private Rigidbody2D playerRb;
    private Animator playerAnimator;

    public float velocidade;
    private int direcao;

    public float hp, HpMax;
    public Transform BarraHP;
    private float percVida;

    public GameObject explosaoPrefab;

    public GameObject[] armas;
    public int powerUpColetados;

    private Transform top, bottom, left, right;

	// Use this for initialization
	void Start ()
    {
        scriptGC = FindObjectOfType(typeof(GC)) as GC;
        top = GameObject.Find("Top").transform;
        bottom = GameObject.Find("Bottom").transform;
        left = GameObject.Find("Left").transform;
        right = GameObject.Find("Right").transform;

        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

        BarraHP = GameObject.Find("Barra_Vida").transform;
        BarraHP.localScale = new Vector3(1, 1, 1);

        hp = HpMax;
        percVida = hp / HpMax;

        armas[powerUpColetados].SetActive(true);
	}
	
	// Update is called once per frame
	void Update ()
    {        
        //GetAxis sensivel ao analogico, ou seja se colocar só um pouco de força vai ser pego um valor pequeno e caso coloque muita força vai pegar a um valor maior
        //GetAxisRaw não é sensivel

        float movimentoX = Input.GetAxisRaw("Horizontal");
        float movimentoY = Input.GetAxisRaw("Vertical");      

        if(movimentoX < 0)
        {
            direcao = 1;
        }
        else if(movimentoX == 0)
        {
            direcao = 0;            
        }
        else if(movimentoX > 0)
        {
            direcao = -1;            
        }

        playerRb.velocity = new Vector2(movimentoX * velocidade, movimentoY * velocidade);
        playerAnimator.SetInteger("Direcao", direcao);

        if (transform.position.x < left.position.x)
        {
            transform.position = new Vector3(left.position.x, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > right.position.x)
        {
            transform.position = new Vector3(right.position.x, transform.position.y, transform.position.z);
        }

        if (transform.position.y > top.position.y)
        {
            transform.position = new Vector3(transform.position.x, top.position.y, transform.position.z);
        }
        else if (transform.position.y < bottom.position.y)
        {
            transform.position = new Vector3(transform.position.x, bottom.position.y, transform.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch(col.gameObject.tag)
        {
            case "TiroInimigo":
                TomarDano(1);
            break;

            case "PowerUp":
                PowerUp();
                Destroy(col.gameObject);
            break;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Inimigo":
                TomarDano(1);
                break;
        }
    }

    void TomarDano(int danoTomado)
    {
        hp -= danoTomado;

        percVida = hp / HpMax;
        Vector3 theScale = BarraHP.localScale;
        theScale.x = percVida;
        BarraHP.localScale = theScale;

        if (hp <= 0)
        {
            explodir();
        }
    }

    void explodir()
    {
        GameObject tempPrefab = Instantiate(explosaoPrefab) as GameObject;
        tempPrefab.transform.position = transform.position;
        scriptGC.Morreu();
        Destroy(this.gameObject);
    }

    void PowerUp()
    {
        powerUpColetados += 1;
        if(powerUpColetados <= armas.Length - 1)
        {
            armas[powerUpColetados].SetActive(true);
        }
        scriptGC.pontos += 100 * powerUpColetados;   
    }
}
