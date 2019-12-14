using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

	float movement = 0f;
	Rigidbody2D rb;
	public float speed = 10f;
    SpriteRenderer spRender;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
        spRender = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		movement = Input.GetAxis ("Horizontal") * speed;
        if (movement < 0)
            spRender.flipX = true;
        else if (movement > 0)
            spRender.flipX = false; 
	}

	void FixedUpdate() {
		Vector2 velocity = rb.velocity;
		velocity.x = movement;
		rb.velocity = velocity;
	}
}
