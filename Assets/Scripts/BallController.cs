using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour{

    [SerializeField] TimerManager timer;
    private Rigidbody2D rb;

    [SerializeField] float fuerza;
    private Vector2 direccion;
    
    private void Awake(){
        rb = GetComponent<Rigidbody2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.collider.CompareTag("Patada")){
            ComprobarPrimerMovimiento();

            direccion = (rb.position - (Vector2)collision.transform.position).normalized;
            rb.AddForce(direccion * fuerza, ForceMode2D.Impulse);


        }
     
        if (collision.collider.CompareTag("Player")){
            ComprobarPrimerMovimiento();

        }

    }
    private void ComprobarPrimerMovimiento(){
        if (timer.GetPrimerMovimiento() == false && timer.GetPausa() == false){
            timer.EmpezarContador();

        }

    }

}
