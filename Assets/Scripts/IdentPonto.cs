using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentPonto : MonoBehaviour {

    [SerializeField]
    private AudioSource audioS;
    [SerializeField]
    private AudioClip clip;
    

    void OnTriggerExit2D (Collider2D col)
    {
        if (col.gameObject.CompareTag("bola") || col.gameObject.CompareTag("bolaclone")) {

            GAMEMANAGER.instance.pontos++;
           
            TocaAudio.TocadordeAudio(audioS, clip);
            
        }

    }
}