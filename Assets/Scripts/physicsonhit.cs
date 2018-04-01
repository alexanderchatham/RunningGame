using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicsonhit : MonoBehaviour {

    Vector3 m_JumpForce;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = .5f ;
        m_JumpForce = new Vector3(0.0f, -1f, 1.0f);
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(m_JumpForce, ForceMode2D.Impulse);

    }
}
