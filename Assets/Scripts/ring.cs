using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ring : MonoBehaviour {


    public GameObject Ring;
    private GameObject endPoint;
    private void Start()
    {
        Ring = this.gameObject;
        endPoint = GameObject.FindGameObjectWithTag("End");
    }



    public void Collect()
    {
        //frodo
        Destroy(Ring);
    }
}
