using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class UIMANAGER : MonoBehaviour {

    public static UIMANAGER instance;

    public Text desafio;

    public Text numBolas;

    public Toggle desafioT;

    public Button iniciarBtn;

    public Text txtWL;
    public Button avancarBtn;
        
    public Button voltarBtn, novamenteBtn;


    void Awake()  {

        desafioT = GameObject.FindWithTag("togg").GetComponent<Toggle>();

        desafio = desafioT.GetComponentInChildren<Text>();

        //desafio = GameObject.FindWithTag("desf").GetComponent<Text>();



        

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += Carrega;
    }
    void Carrega(Scene cena, LoadSceneMode moda) {

        txtWL = GameObject.FindWithTag("txtWL").GetComponent<Text>();
        avancarBtn = GameObject.FindWithTag("btnAvancar").GetComponent<Button>();

        voltarBtn = GameObject.FindWithTag("btnVoltar").GetComponent<Button>();
        novamenteBtn = GameObject.FindWithTag("btnNovamente").GetComponent<Button>();
      


        iniciarBtn = GameObject.FindWithTag("iniciarbtn").GetComponent<Button>();

        numBolas = GameObject.FindWithTag("numBolas").GetComponent<Text>();

        numBolas.text = GAMEMANAGER.instance.numJogadas.ToString();

        desafioT = GameObject.FindWithTag("togg").GetComponent<Toggle>();

        desafio = desafioT.GetComponentInChildren<Text>();

        //desafio = GameObject.FindWithTag("desf").GetComponent<Text>();

    

    }

    // Use this for initialization
    void Start () {

        numBolas.text = GAMEMANAGER.instance.numJogadas.ToString();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}


