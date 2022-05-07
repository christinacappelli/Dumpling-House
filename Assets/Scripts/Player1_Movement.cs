using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_Movement : MonoBehaviour
{
    Vector3 movement;
    public float Speed = 10f;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       //animations
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        transform.Translate(movement * Speed * Time.deltaTime);
    }
}
