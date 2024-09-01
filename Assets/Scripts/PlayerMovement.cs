using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 direction;
    private Vector2 movement;
    private bool isMoving = false;
    private Rigidbody2D playerRb;
    private Animator playerAnim;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>(); 
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //direction.x = Input.GetAxis("Horizontal");
        //direction.y = Input.GetAxis("Vertical");
        //Move by Mouse
        if(Input.GetMouseButtonDown(0))
        {
            direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            movement = (direction - playerRb.position).normalized;
            isMoving = true;
        }

    }
    private void FixedUpdate()
    {
        if(isMoving)
        {
            playerRb.MovePosition(playerRb.position + movement * speed * Time.fixedDeltaTime);
        }
        if(Vector2.Distance(direction, playerRb.position)  <=0.1f)
        {
            isMoving = false;
        }
    }
}
