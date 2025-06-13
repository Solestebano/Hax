using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CanchaController : MonoBehaviour{
    public static event Action OnAnotar;

    /*
    private void Update(){
        if (game_manager.ganar && !ya_gano){
            ya_gano = true;
            StartCoroutine(Ganar());

        }
    }
    */

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Bola"){
            OnAnotar?.Invoke();

        }

    }

}
