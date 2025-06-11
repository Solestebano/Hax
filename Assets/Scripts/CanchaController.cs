using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CanchaController : MonoBehaviour{
    [SerializeField] GameObject bola;
    [SerializeField] GameObject contador;
    [SerializeField] GameObject jugador;
    [SerializeField] GameManager game_manager;
    
    SpriteRenderer sr;
    AudioSource aud;
    Rigidbody2D rb_bola;
    Rigidbody2D rb_jugador;

    [SerializeField] Sprite sprite;
    [SerializeField] TextMeshProUGUI texto_puntaje;
    [SerializeField] TextMeshProUGUI texto_ganador;
    [SerializeField] ParticleSystem particulas;
    private ParticleSystem instancia_particulas;

    private Sprite sprite_original;
    private float drag_original;
    private Vector3 posicion_original;
    private int puntaje;
    private bool ya_gano = false;


    private void Start(){
        sr = contador.GetComponent<SpriteRenderer>();
        aud = contador.GetComponent<AudioSource>();
        rb_bola = bola.GetComponent <Rigidbody2D>();
        rb_jugador = jugador.GetComponent<Rigidbody2D>();

        sprite_original = sr.sprite;
        drag_original = rb_bola.drag;
        posicion_original = jugador.transform.position;

        puntaje = 0;
        texto_puntaje.text = "Puntaje: " + puntaje;

    }

    private void Update()
    {
        if (game_manager.ganar && !ya_gano)
        {
            ya_gano = true;
            StartCoroutine(Ganar());
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Bola"){

            StartCoroutine(Anotar());

        }

    }
    private void SpawnParticles(){
        instancia_particulas = Instantiate(particulas, contador.transform.position, Quaternion.identity);

    }
    IEnumerator Anotar(){
        game_manager.PararContador(true);

        sr.sprite = sprite;
        sr.color = Color.red;

        aud.Play();
        SpawnParticles();

        yield return contador.transform.DOScale(new Vector3(1.25f, 1.25f, 1), 0.25f).WaitForCompletion();

        rb_bola.drag = 5f;

        puntaje += 1;
        game_manager.SumarPuntaje(1);
        texto_puntaje.text = "Puntaje: " + puntaje;

        if (game_manager.ganar == true){
            StartCoroutine(Ganar());

            yield break;
        
        }

        yield return new WaitForSeconds(2f);

        game_manager.PararContador(false);
        sr.sprite = sprite_original;
        sr.color = Color.white;
        contador.transform.DOScale(Vector3.one, 0.25f);

        bola.transform.position = Vector3.zero;
        rb_bola.drag = drag_original;
        rb_bola.velocity = Vector2.zero;

        jugador.transform.position = posicion_original;
        rb_jugador.velocity = Vector2.zero;

    }

    IEnumerator Ganar(){
        texto_ganador.DOFade(1f, 1f);
        yield return new WaitForSeconds(2f);

        game_manager.ReiniciarEscena();

    }

}
