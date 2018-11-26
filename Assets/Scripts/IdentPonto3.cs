using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentPonto3 : MonoBehaviour
{

    

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("bola") || col.gameObject.CompareTag("bolaclone"))
        {
            
            ShootScript.fez3ponto = 0;

        }

    }
}
