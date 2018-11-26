using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinadeEstado : MonoBehaviour {

    public MonoBehaviour EstadoIdle;
    public MonoBehaviour EstadoJump;
    public MonoBehaviour EstadoDown;
    public MonoBehaviour EstadoPatrulha;
    public MonoBehaviour EstadoInicial;

    private MonoBehaviour EstadoAtual;

    // Use this for initialization
    void Start()
    {
        ActivarEstado(EstadoInicial);
    }
        public void ActivarEstado(MonoBehaviour novoEstado) {

        if (EstadoAtual != null) EstadoAtual.enabled = false; 
        EstadoAtual = novoEstado;
        EstadoAtual.enabled = true;
        }
        
	}


