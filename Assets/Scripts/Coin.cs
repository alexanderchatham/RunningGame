using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public GameObject coin;
    private GameObject endPoint;
    public bool stationary = true;
    private void Start()
    {
        endPoint = GameObject.FindGameObjectWithTag("End");
        coin = this.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (this.transform.position.y < -5f)
            Destroy(this.gameObject);
        if(stationary)
            this.transform.Translate(GameMaster.groundMoveSpeed, 0, 0);
    }
    
    public void Collect()
    {
        GameObject.FindGameObjectWithTag("CoinSfx").GetComponent<AudioSource>().Play();
        Destroy(coin);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(coin);
        }
    }
}
