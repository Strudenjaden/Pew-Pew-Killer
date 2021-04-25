using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10f;
    public float runningSpeed = 15f;
    public float jumpForce = 30f;

    [Header("Sonidos")]
    [Tooltip("Sonido de salto")]
    public AudioSource jump;



    //Physics
    private void FixedUpdate()
    {

    }

    //No physics
    private void Update()
    {
        Movement();
    }

    /**
     * Movimiento del jugador
     * El juegador puede correr
     *
     * Salto del jugador
     */
    private void Movement()
    {

        float horizontal = Input.GetAxisRaw("Horizontal"); //Movimiento horizontal

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); //Movimiento derecha e izquierda de nuestro player.

        //Correr

        if (Input.GetButton("Run"))
        {
            rb.velocity = new Vector2(horizontal * runningSpeed, rb.velocity.y); //Aumentamos la velocidad del player si el jugador pulsa el boton de correr.
        }

        //Salto
        if (Input.GetButton("Jump") && isGrounded()) //El jugador saltará cuando se pulse el botón de salto y esté sobre el suelo
        {
            jump.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);



        }
    }

    private bool isGrounded()
    {
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded; //Devuelve true o false en función de si el jugador esta tocando el suelo o no.
    }
}
