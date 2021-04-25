using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayerMask; //Máscara de lo que es suelo.

    public bool isGrounded; //Comprueba si se esta tocando el suelo o no.


    /*
     * Cuando el jugador esta tocando una Layer del tipo que asociemos desde el Inspectos en Unity devolverá true al isGrounded.
     */
    private void OnTriggerStay2D(Collider2D collider)
    {
        isGrounded = collider != null && (((1 << collider.gameObject.layer) & groundLayerMask) != 0); //Esta tocando el suelo.
    }

    /*
     * Una vez que el jugador salga de estar en contacto, la variable isGrounded devolverá false.
     */
    private void OnTriggerExit2D(Collider2D collider)
    {
        isGrounded = false; //Ya no esta tocando el suelo.
    }
}
