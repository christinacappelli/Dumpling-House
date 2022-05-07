using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    SpriteRenderer sprite;
    List<GameObject> heartsObjects;
    public Animator animator;
    public AudioSource audioSource;
    private GameManager gcscript;
    int life = 3;
   
    void Start()
    {
        gcscript = GameObject.FindObjectOfType<GameManager>();
        sprite = GetComponent<SpriteRenderer>();
        Transform[] hearts = GetComponentsInChildren<Transform>();
        heartsObjects = new List<GameObject>();
        foreach (Transform child in hearts)
        { 
            heartsObjects.Add(child.gameObject);
        }
    }
    
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Explosion"))
        {
            StartCoroutine(flash());
            if(life>0){
                Destroy(heartsObjects[life]);
            }
            life--;
            if(life <=0)
            {
                //StartCoroutine(flash());
                animator.SetTrigger("Death");
                audioSource.Play();
                Debug.Log ("dead");
                PlayerPrefs.SetString("playerDead",gameObject.tag);
                gcscript.GameOver();
            }
        }
    }

    IEnumerator flash()
    {
        for(int i = 0; i<3;i++){
            sprite.color = new Color (.2f,.2f,.2f,1);
            yield return new WaitForSeconds(.1f);
            sprite.color = new Color (1,1,1,1);
            yield return new WaitForSeconds(.1f);
        }  
    }
}
