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

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x <= endPoint.transform.position.x)
        {
            Destroy(Ring);
        }
        
    }

    public void Collect()
    {
        //frodo
        Destroy(Ring);
    }
}
