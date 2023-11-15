using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vachamquai : MonoBehaviour
{
    public GameObject pauseMenuSreen;
    private Animator anim;
    [SerializeField] private AudioSource deathAudio;
    [SerializeField] private AudioSource bgmusic;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "quai")
        {
            deathAudio.Play();
            hpplayer.mau --;
            if(hpplayer.mau <= 0){
                Destroy(gameObject,2f);
                Time.timeScale = 0;
                pauseMenuSreen.SetActive(true);
            }else{
                StartCoroutine(GetHurt());
            }
        }
    }

    public void tatAm()
    {
        deathAudio.Pause();
        bgmusic.Pause();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "quai" || other.transform.tag == "fireball")
        {
            deathAudio.Play();
            hpplayer.mau --;
            if(hpplayer.mau <= 0){
                Destroy(gameObject,2f);
                Time.timeScale = 0;
                pauseMenuSreen.SetActive(true);
            }else{
                StartCoroutine(GetHurt());
            }
        }
    }

    IEnumerator GetHurt(){ 
        Physics2D.IgnoreLayerCollision(6,8);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(6,8, false);
    }
}
