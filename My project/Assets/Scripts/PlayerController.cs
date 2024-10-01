using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private float Move;
    private float TopDown;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxisRaw("Horizontal");
        TopDown = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(TopDown * speed, rb.velocity.y);
        rb.velocity = new Vector2(Move * speed, rb.velocity.x);
    }
}
