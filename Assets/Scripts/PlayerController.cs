using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour{
    #region Variables

    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] SpriteRenderer sr_outline;
    [SerializeField] GameObject patada;
    [SerializeField] GameObject outline;

    [SerializeField] Equipos equipo;
    [SerializeField] float velocidad; 
    [SerializeField] float salto;

    private Vector2 direccion_movimiento;
    private bool accion;
    private float velocidad_inicial;
    private Color color_inicial;

    #endregion

    private void Awake(){
        var player_input = GetComponent<PlayerInput>();

        if (player_input.defaultControlScheme == "Jugador1"){
            player_input.SwitchCurrentControlScheme("Jugador1", Keyboard.current);
        
        }else if(player_input.defaultControlScheme == "Jugador2"){
            player_input.SwitchCurrentControlScheme("Jugador2", Keyboard.current);

        }

        //Asignar color
        if (equipo == Equipos.EquipoAzul){
            ColorUtility.TryParseHtmlString("#9EB7FF", out color_inicial);

        }else if (equipo == Equipos.EquipoRojo){
            ColorUtility.TryParseHtmlString("#FF715B", out color_inicial);

        }

        sr.color = color_inicial;
        velocidad_inicial = velocidad;

    }

    private void FixedUpdate(){
        rb.AddForce(direccion_movimiento * velocidad, ForceMode2D.Force);
        //rb.velocity = direccion_movimiento.normalized * velocidad;

        if (accion){
            velocidad = velocidad_inicial * 0.5f;
            sr_outline.color = Color.white;
            patada.SetActive(true);
        
        }else{
            velocidad = velocidad_inicial;
            sr_outline.color = Color.black;
            sr.color = color_inicial;
            patada.SetActive(false);

        }

    }

    public void Movimiento(InputAction.CallbackContext context){
        direccion_movimiento = context.ReadValue<Vector2>();

    }

    public void Acciones(InputAction.CallbackContext context){
        if (context.started){
            accion = true;

        }
        else if (context.canceled){
            accion = false;

        }

    }

}
