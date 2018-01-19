using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float MovementSpeed = 10;
    public float JumpForce = 10;

    Rigidbody2D rigidbody2d;

	void Start () {
        rigidbody2d = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        float horizontal = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(horizontal, 0, 0) * MovementSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            rigidbody2d.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
	}
}
