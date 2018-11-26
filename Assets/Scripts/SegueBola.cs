using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SegueBola : MonoBehaviour {

    public Image seta;
    public Transform alvo;
    public static bool alvoInvisivel = false;

    // Use this for initialization
    void Start() {

        alvo = GameObject.FindWithTag("bola").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update() {

        if (GAMEMANAGER.instance.bolaEmCena == true && alvo == null)
        {
            alvo = GameObject.FindWithTag("bola").GetComponent<Transform>();
            print("peguei!");
        }

        if (alvoInvisivel == true)
        {
            Segue();
            VisualizaSeta(alvoInvisivel);
        }
        else
        {
            VisualizaSeta(alvoInvisivel);
        }
    
    }
        void Segue()
        {
            if (!alvo)

                return;
            Vector2 aux;
            aux = seta.rectTransform.position;
            aux.x = alvo.position.x;
            seta.rectTransform.position = aux;

        }
        void VisualizaSeta(bool condicao)
        {
            seta.enabled = condicao;
        }
    }

