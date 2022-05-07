using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumpling : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject explosionPrefab;
    public LayerMask levelMask;
    private bool exploded = false;
    private bool colliderIsOn = false;


    
    void Start()
    {
        Invoke("Explode", 3f);
        GetComponent<CircleCollider2D>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Explode()
    {
        audioSource.Play();
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        StartCoroutine(CreateExplosions(Vector3.up));
        StartCoroutine(CreateExplosions(Vector3.right));
        StartCoroutine(CreateExplosions(Vector3.down));
        StartCoroutine(CreateExplosions(Vector3.left)); 
        
        GetComponent<SpriteRenderer>().enabled = false;
        exploded = true;
        GetComponent<CircleCollider2D>().enabled = false;
        //transform.Find("Collider").gameObject.SetActive(false);
        Destroy(gameObject, .3f);
    }
    
    private IEnumerator CreateExplosions(Vector3 direction)
    {
        for (int i = 1; i < 2; i++) 
        { 
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, i, levelMask);
            //Physics.Raycast(transform.position + new Vector3(0,.5f,0), direction, out hit, i, levelMask);
            if (!hit.collider) 
            { 
                Instantiate(explosionPrefab, transform.position + (i * direction),explosionPrefab.transform.rotation);
            } 
            else 
            {
            break; 
            }
            yield return new WaitForSeconds(.05f); 
        }
    }
    public void OnTriggerEnter2D(Collider2D other) 
    {
        if (!exploded && other.CompareTag("Explosion"))
        {
            CancelInvoke("Explode");
            Explode(); // 3
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if(!colliderIsOn && (other.CompareTag("PlayerRed")||other.CompareTag("PlayerBlue")))
        {
            GetComponent<CircleCollider2D>().isTrigger = false;
            colliderIsOn = true;
        }
    }

}
