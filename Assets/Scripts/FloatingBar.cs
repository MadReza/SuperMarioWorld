using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBar : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D otherObjectCollider)
    {
        if (otherObjectCollider.gameObject.tag == "Player")
        {
            otherObjectCollider.transform.parent = gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D otherObjectCollider)
    {
        if (otherObjectCollider.gameObject.tag == "Player")
        {
            otherObjectCollider.transform.parent = null;
        }
    }

}
