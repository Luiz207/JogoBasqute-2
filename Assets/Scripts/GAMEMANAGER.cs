using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GAMEMANAGER : MonoBehaviour {

    [System.Serializable]
    public class DesafioTxt
    {
        public int OndeEstou;
        public string desafio;
        public int desafioInt = 0;
        public int numeroJogadas;
    }

    public List<DesafioTxt> desafioList;

    void ListAdd()
    {
        foreach (DesafioTxt desaf in desafioList)
        {
            if (desaf.OndeEstou == OndeEstou.instance.fase)
            {
                UIMANAGER.instance.desafio.text = desaf.desafio;

                desafioNum = desaf.desafioInt;

                numJogadas = desaf.numeroJogadas;

                break;
            }
        }
    }
	public static GAMEMANAGER instance;

    public int desafioNum;

	public bool bolaEmCena;
	public int numJogadas;
    public GameObject bolaPrefab;
  

	[SerializeField]
	private Transform posDireita, posEsquerda, posCima, posBaixo;

	public bool jogoExecutando = true, win = false, lose = false;
    


	//Mão Bolinhas

	public GameObject mao, bolinhas;
	public int primeiraVez = 0;

    //Identifica_ponto
    public int pontos = 0;
    public bool pontos3 = false;
   



    //***********************************************************
    private Animator maoAnim, bolinhasAnim;

    [SerializeField]
    private GameObject fundo, tela, telaWL;
    [SerializeField]
    private Animator animCont;


    public void LiberaContagem()
    {
        fundo.gameObject.SetActive(false);
        tela.gameObject.SetActive(false);
        telaWL.SetActive(false);
        animCont.Play("ContadorAnim");
       

    }

	void Awake()
	{


		if(instance == null)
		{
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		}
		else
		{
			Destroy (gameObject);
		}

        if (PlayerPrefs.HasKey("PrimeiraVez") == false)
        {
            PlayerPrefs.SetInt("PrimeiraVez", 0);
            primeiraVez = PlayerPrefs.GetInt("PrimeiraVez");
        }
 

        SceneManager.sceneLoaded += Carrega;


    }

    void Carrega(Scene cena, LoadSceneMode modo)
	{
		StartGame();
        ListAdd();

        posDireita = GameObject.FindWithTag ("DIREITA_POS").GetComponent<Transform> ();
		posEsquerda = GameObject.FindWithTag ("ESQUERDA_POS").GetComponent<Transform> ();
		posCima = GameObject.FindWithTag ("CIMA_POS").GetComponent<Transform> ();
		posBaixo = GameObject.FindWithTag ("BAIXO_POS").GetComponent<Transform> ();

        fundo = GameObject.FindWithTag("fundoC");
        tela = GameObject.FindWithTag("teladesafio");
        animCont = GameObject.FindWithTag("contador").GetComponent<Animator>();

        telaWL = GameObject.FindWithTag("telaWL");
		
        //***************************************************************************************
        maoAnim = GameObject.FindWithTag("mao").GetComponent<Animator>();
        bolinhasAnim = GameObject.FindWithTag("bolinhas").GetComponent<Animator>();

        primeiraVez = PlayerPrefs.GetInt("PrimeiraVez");
        if (primeiraVez == 0 || primeiraVez == 1)
		{
			PegaSpritesTutorial ();

			if(primeiraVez == 1 )
			{
				Matador (mao.gameObject,bolinhas.gameObject);
			}
		}




    }

	// Use this for initialization
	void Start () {

        //PlayerPrefs.DeleteAll();


        StartGame();
        ListAdd();
        bolaEmCena = true;
        numJogadas = 8;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OndeEstou.instance.fase++;
            SceneManager.LoadScene(OndeEstou.instance.fase);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(OndeEstou.instance.fase);
        }

        // Vencer ou Perder 
   
        if (numJogadas <= 0 && desafioNum > 0) {

            YouLose();
        }

        else if (numJogadas > 0 && desafioNum <= 0)
        {
            YouWin(); 
        }
        

    }
   





	public void NascBolas() {
            //Codigo ajustado para achar a bola, forma mais complexa
            Instantiate(bolaPrefab, new Vector2(Random.Range(posEsquerda.position.x, posDireita.position.x), Random.Range(posCima.position.y, posBaixo.position.y)), Quaternion.identity);
            bolaEmCena = true;


    }

	public void DesligaTuto()
	{
		Matador (mao.gameObject,bolinhas.gameObject);
		PlayerPrefs.SetInt ("PrimeiraVez",1);
       
	}

	void Matador(GameObject obj, GameObject obj2)
	{
		Destroy (obj);
		Destroy (obj2);
	}

	void PegaSpritesTutorial()
	{
		mao = GameObject.FindWithTag ("mao");
		bolinhas = GameObject.FindWithTag ("bolinhas");
	}


	void Novamente() {

		SceneManager.LoadScene (OndeEstou.instance.fase);
	}

	void Avancar()
	{
		OndeEstou.instance.fase++;
		SceneManager.LoadScene (OndeEstou.instance.fase);
	}

	void Voltar()
	{
		SceneManager.LoadScene ("Menu_Fases");
	}


    void StartGame()
    {
        UIMANAGER.instance.novamenteBtn.onClick.AddListener(Novamente);
        UIMANAGER.instance.avancarBtn.onClick.AddListener(Avancar);
        UIMANAGER.instance.voltarBtn.onClick.AddListener(Voltar);

        UIMANAGER.instance.iniciarBtn.onClick.AddListener(LiberaContagem);
        jogoExecutando = false;
        pontos = 0;
        win = false;
        lose = false;

    }
    public void DesafioDaFase(int fase)
    {
        if (OndeEstou.instance.fase == fase)
        {
            if (desafioNum == 0)
            {
                UIMANAGER.instance.desafioT.isOn = true;
                print("Desafio Completo");
            }
        }
    }
        void YouWin()
        {
            if (jogoExecutando == true)
            {
                win = true;
                jogoExecutando = false;
                print("Voce Ganhou");
            telaWL.SetActive(true);
            UIMANAGER.instance.txtWL.text = "YOU WIN!";
            }

        }
        void YouLose() {
            if (jogoExecutando == true)
            {
                lose = true;
                jogoExecutando = false;
                print("Voce Perdeu");
               telaWL.SetActive(true);
            UIMANAGER.instance.txtWL.text = "YOU LOSE!";
            UIMANAGER.instance.avancarBtn.gameObject.SetActive(false);
        }

        }      
    //***********************************************

    public void PrimeiraJogada()
    {
        //*********************************************************************************************
        if (jogoExecutando == true && primeiraVez == 0)
        {
            if (mao != null && bolinhas != null)
            {
                maoAnim.Play("iconehand");
                bolinhasAnim.Play("bolinhas");
                print("animando");
            }
            print(primeiraVez);

        }
    }

}
