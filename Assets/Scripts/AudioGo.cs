﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGo : MonoBehaviour {

    [SerializeField]
    private AudioSource audioS;
    [SerializeField]
    private AudioClip clip;

     void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("bola") || col.gameObject.CompareTag("bolaclone"))
        {
            TocaAudio.TocadordeAudio(audioS, clip);
        }
    }


}
