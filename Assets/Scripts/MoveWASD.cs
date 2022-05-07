using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWASD : MonoBehaviour
{
    // PLAYER = WASD + RETURN FOR BOMBS
    public AudioSource audioSource;
    public float Speed; // speed (public) 

    float MovementX; // x direction
    float MovementY; // y direction

    Rigidbody2D Rb; // reference players rigid body

    //DumplingBombs
    [SerializeField]
    private GameObject dumpling;

    // animations
    Vector3 movement;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>(); // reference to access player
        // starting position
        MovementX = 0;
        MovementY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // changing sped of character each frome 
        Rb.velocity = new Vector2(MovementX * Speed * Time.deltaTime, MovementY * Speed * Time.deltaTime);

        // a place to store input
        if (Input.GetKeyDown(KeyCode.W)) //up 
        {
            MovementY = 1;
        }

        if (Input.GetKeyDown(KeyCode.S)) // down 
        {
            MovementY = -1;
        }

        if (Input.GetKeyDown(KeyCode.A)) //left 
        {
            MovementX = -1;
        }

        if (Input.GetKeyDown(KeyCode.D)) // right 
        {
            MovementX = 1;
        }

        // want the player to stop moving when up stop pressing the key
        if (Input.GetKeyUp(KeyCode.W) || (Input.GetKeyUp(KeyCode.S)))
        {
            MovementY = 0;
        }

        if (Input.GetKeyUp(KeyCode.A) || (Input.GetKeyUp(KeyCode.D)))
        {
            MovementX = 0;
        }

        if (Input.GetKeyDown("space"))
        {
            var collidersInRange = Physics2D.OverlapCircle(new Vector3(Mathf.RoundToInt(this.gameObject.transform.position.x), Mathf.RoundToInt(this.gameObject.transform.position.y)),0.5f);
            //make sure only one dumpling on one grid
            if (collidersInRange.tag == "Dumpling") 
            {
                print("foundDumpling");
            } else {
                // spot is empty, we can spawn
                audioSource.Play();
                DropBomb();
            }
            
        }

        //animations
        animator.SetFloat("Horizontal", MovementX);
        animator.SetFloat("Vertical", MovementY);
        //animator.SetFloat("Speed", movement.sqrMagnitude);
        //animator.SetFloat("Speed", Speed); // passes speed float into this parameter
    }

    void DropBomb()
    {
        //create bomb at player position
        int xP = Mathf.RoundToInt(this.gameObject.transform.position.x);
        int yP = Mathf.RoundToInt(this.gameObject.transform.position.y);
        if(yP>3){
            yP=3;
        }
        Instantiate(dumpling, new Vector3(xP, yP, 0), dumpling.transform.rotation);
        
        //Instantiate(dumpling,this.gameObject.transform.position, Quaternion.identity);
    }
}
