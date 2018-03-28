using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateonhit : MonoBehaviour {



    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Animator>().SetBool("hit", true);
    }
}
