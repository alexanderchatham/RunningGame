using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public GameObject coin;
    private GameObject endPoint;
    private void Start()
    {
        endPoint = GameObject.FindGameObjectWithTag("End");
        coin = this.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (this.transform.position.x <= endPoint.transform.position.x)
        {
            Destroy(coin);
        }
      
        this.transform.Translate(GameMaster.groundMoveSpeed, 0, 0);
    }
    
    public void Collect()
    {
        Destroy(coin);
    }
}
