using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShootScript : MonoBehaviour
{

    private float forca = 2.0f;

    private Vector2 startPos;
    private bool tiro = false;
    private bool mirando = false;
    [SerializeField]
    private GameObject dotsGo;
    private List<GameObject> caminho;

    [SerializeField]
    private Rigidbody2D myRBody;
    [SerializeField]
    private Collider2D myCollider;

    private Vector2 vel;

    //public int x = 0;

    //Variaveis aux 
    [SerializeField]
    private float valorX, valorY;

    // Tipo de jogada 

    private bool bateuAro = false;
    private bool bateuTabela = false;

    // Marcou ponto 
    public static int fez3ponto;
    private bool liberaSky;

    [SerializeField]
    private Animator anim;

    // Variaveis Morte
    

    // Use this for initialization
    void Start()
    {
        anim = GameObject.FindWithTag("RimTxt").GetComponent<Animator>();

        liberaSky = false;
        fez3ponto = 0;
        dotsGo = GameObject.FindWithTag("dots");
        myRBody.isKinematic = true;
        myCollider.enabled = false;
        startPos = transform.position;
        caminho = dotsGo.transform.Cast<Transform>().ToList().ConvertAll(t => t.gameObject);
        for (int x = 0; x < caminho.Count; x++)
        {

            caminho[x].GetComponent<Renderer>().enabled = false;

        }

    }
    void FixedUpdate() {
        if (GAMEMANAGER.instance.jogoExecutando == true)
        {
            if (!myRBody.gameObject.CompareTag("bolaclone"))
            {
                Mirando();
            }
        }

    }

    void Update()
    {
        if (GAMEMANAGER.instance.jogoExecutando == true)
        {


            if (myRBody.isKinematic)
            {
               

                // Fez 3 pontos
                if ( fez3ponto + GAMEMANAGER.instance.pontos==3)
                {
                    GAMEMANAGER.instance.pontos3 = true;
                    print("fez 3 pontos");

                    GAMEMANAGER.instance.desafioNum--;
                    GAMEMANAGER.instance.DesafioDaFase(OndeEstou.instance.fase); 
                }



                //anim.Play("RimShot");
            }
            // SwishShot

        }

    }       
            
        
        //Metodos 

        void MostraCaminho()
        {
            for (int x = 0; x < caminho.Count; x++)
            {
                caminho[x].GetComponent<Renderer>().enabled = true;

            }

        }
        void EscondeCaminho()
        {
            for (int x = 0; x < caminho.Count; x++)
            {
                caminho[x].GetComponent<Renderer>().enabled = false;

            }

        }
        Vector2 PegaForca(Vector3 mouse)
        {
            return (new Vector2(startPos.x + valorX, startPos.y + valorY) - new Vector2(mouse.x, mouse.y)) * forca;
        }

        Vector2 CaminhoPonto(Vector2 posInicial, Vector2 velInicial, float tempo)
        {
            return posInicial + velInicial * tempo + 0.5f * Physics2D.gravity * tempo * tempo;
        }

        void CalculoCaminho()
        {
            Vector2 vel = PegaForca(Input.mousePosition) * Time.fixedDeltaTime / myRBody.mass;

            for (int x = 0; x < caminho.Count; x++)
            {
                caminho[x].GetComponent<Renderer>().enabled = true;
                float t = x / 20f;
                Vector3 point = CaminhoPonto(transform.position, vel, t);
                point.z = 1.0f;
                caminho[x].transform.position = point;

            }
        }
        void Mirando()
        {
            if (tiro == true)
                return;

            if (Input.GetMouseButton(0))  {

                if (GAMEMANAGER.instance.primeiraVez == 0) {
                    GAMEMANAGER.instance.DesligaTuto();
                }

                if (mirando == false) {
                    mirando = true;
                    startPos = Input.mousePosition;
                    CalculoCaminho();
                    MostraCaminho();

                }
                else
                {
                    CalculoCaminho();
                }
            }
            else if (mirando == true && tiro == false)
            {
                myRBody.isKinematic = false;
                myCollider.enabled = true;
                tiro = true;
                mirando = false;
                myRBody.AddForce(PegaForca(Input.mousePosition));
                EscondeCaminho();
                // Update is called once per frame

            }
        }

        void OnBecameInvisible()
        {
            SegueBola.alvoInvisivel = true;
        }
        void OnBecameVisible()
        {
            SegueBola.alvoInvisivel = false;
        }

    void OnCollisionEnter2D(Collision2D col)    {


        if (col.gameObject.CompareTag("Aro"))
        {
            bateuAro = true;
        }
        if (col.gameObject.CompareTag("Tabela"))
        {
            bateuTabela = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("sky"))
            {
                liberaSky = true;
            }
        }
    }


    

