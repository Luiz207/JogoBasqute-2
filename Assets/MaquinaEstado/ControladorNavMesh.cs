using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControladorNavMesh : MonoBehaviour {

    [HideInInspector]
    public Transform FindObjet;
    private NavMeshAgent navMeshAgent;

	// Use this for initialization
	void Awake () {
        navMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	
	public void ActulizarPontoDestinoNavMeshAgent (Vector3 pontoDestino) {

        navMeshAgent.destination = pontoDestino;
        navMeshAgent.Resume();

    }
    public void ActulizarPontoDestinoNavMeshAgent()
    {
        ActulizarPontoDestinoNavMeshAgent(FindObjet.position);
    }

    public void StopNavMeshAgent()
    {
        navMeshAgent.Stop();

    }
    public bool TemosChegado()
    {
        return navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending;
    }
}
