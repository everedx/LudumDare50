using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] float baseSpeed;


    private float speed;
    private Rigidbody2D rBody2D;

    // Start is called before the first frame update
    void Start()
    {
        //for now
        speed = baseSpeed;

        rBody2D = GetComponent<Rigidbody2D>();
        rBody2D.velocity = Vector2.right * speed;
    }

    private void FixedUpdate()
    {
        if (rBody2D.velocity.x < speed)
        {
            rBody2D.velocity = Vector2.right *speed;
        }
    }
}
