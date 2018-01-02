using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public GameObject coin;
    private GameObject endPoint;
    private void Start()
    {
        endPoint = GameObject.FindGameObjectWithTag("End");
    }

    // Update is called once per frame
    void Update () {
        if (this.transform.position.x <= endPoint.transform.position.x)
        {
            Destroy(coin);
        }
      
        this.transform.Translate(-.025f, 0, 0);
    }
    
    public void Collect()
    {
        Destroy(coin);
    }
}
