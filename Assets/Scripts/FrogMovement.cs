using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FrogMovement : MonoBehaviour{
    private Rigidbody2D rb;//rigidbody component
    private Animator anim;//animator component
    private SpriteRenderer renderer;// SpriteRender component
    private float dirX=0f;//checks for right & left arrow key presses
    public float moveSpeed=8f;//defined player movement speed
    public float jumpHeight;//defined player jump height
    public int lives=3;
    public bool playerIsRight=true;//checks if the player is facing right or left
    public TextMeshProUGUI text;//variable for lives text(display)
    public string sceneName;//variable for end game scene
    private bool isGrounded=true;//checks if the player is touching the ground

    // Start is called before the first frame update 500
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
        renderer= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX= Input.GetAxisRaw("Horizontal");
        rb.velocity= new Vector2(dirX*moveSpeed ,rb.velocity.y);

        if(Input.GetKeyDown("space") && isGrounded==true){
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            isGrounded=false;
        }
        updateAnimation(); 
    }

    //Collision detection 
    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.tag=="Ground"){
            isGrounded=true;
        }else if(coll.gameObject.tag=="Box"){
            isGrounded=true;
        }
    }

    //Switches between the different player animations
    private void updateAnimation(){
        if(dirX > 0f){
            anim.SetBool("isRunning", true);
            renderer.flipX = false;
            playerIsRight=true;
        }else if(dirX <  0f){
            anim.SetBool("isRunning", true);
            renderer.flipX = true;
            playerIsRight=false;
        }else{
            anim.SetBool("isRunning", false);
        } 
    }
    //manages the players lives 
    public void takeLife(){
        lives-=1;
        text.text = "Lives: " + lives;  
        Debug.Log(lives);
        if(lives<1){
            SceneManager.LoadScene(sceneName);  
        }
    } 
}


