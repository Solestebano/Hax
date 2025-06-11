using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Draggable : MonoBehaviour{
    SpriteRenderer sr;
    Transform tf;
    AudioSource aud;

    [SerializeField] private ParticleSystem particulas;
    ParticleSystem instancia_particulas;

    private Sprite sprite_original;
    public Sprite sprite;
    private void Start(){
        sr = GetComponent<SpriteRenderer>();
        tf = GetComponent<Transform>();
        aud = GetComponent<AudioSource>(); 
        sprite_original = sr.sprite;

    }
    private void OnMouseDown(){
        sr.sprite = sprite;
        sr.color = Color.red;
        tf.DOScale(new Vector3(1.25f, 1.25f, 1), 0.25f);
        aud.Play();
        SpawnParticles();

    }
    private void OnMouseUp(){
        sr.sprite = sprite_original;
        sr.color = Color.white;
        tf.DOScale(Vector3.one, 0.25f);

    }
    private void SpawnParticles(){
        instancia_particulas = Instantiate(particulas, transform.position, Quaternion.identity);

    }

}
