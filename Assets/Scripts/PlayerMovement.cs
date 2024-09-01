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
    public static bool mouseController;

    // Start is called before the first frame update
    void Start()
    {
        mouseController = true;
        playerRb = GetComponent<Rigidbody2D>(); 
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //Move by Mouse
        if(mouseController)
        {
            if (Input.GetMouseButtonDown(0))
            {
                direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                movement = (direction - playerRb.position).normalized;
                isMoving = true;
            }
            playerAnim.SetBool("IsMoving", isMoving);
            playerAnim.SetFloat("Horizontal", movement.x);
            playerAnim.SetFloat("Vertical", movement.y);
        }
        else
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
            playerAnim.SetBool("IsMoving", movement.sqrMagnitude > 0.1 ? true : false);
            playerAnim.SetFloat("Horizontal", movement.magnitude >0.1f ? movement.x : playerAnim.GetFloat("Horizontal"));
            playerAnim.SetFloat("Vertical", movement.magnitude >0.1f ? movement.y : playerAnim.GetFloat(("Vertical")));
        }
    }
    private void FixedUpdate()
    {
        if(mouseController)
        {
            if (isMoving)
            {
                playerRb.MovePosition(playerRb.position + movement * speed * Time.fixedDeltaTime);
            }
            if (Vector2.Distance(direction, playerRb.position) <= 0.1f)
            {
                isMoving = false;
            }
        }else
        {
            playerRb.MovePosition(playerRb.position + movement * speed * Time.fixedDeltaTime);
        }
        
    }
}
