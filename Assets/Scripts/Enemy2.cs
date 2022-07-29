using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public int health=100;
    public float minSpeed;//minimun speed for enemy
    public float maxSpeed;//maximun speed for enemy
    private float speed;
    private bool ifRight=false;//if the enemy is facing right
    public Transform t1;//first bounding point for enemy
    public Transform t2;//second bounding point for enemy
    FrogMovement frogScript;
    private SpriteRenderer renderer;
    public float startTimeBetween;//at start of game, how long it takes to spawn a new enemy
    private float timeForSpawn;//timer between the time the enemy dies and needs to respawn 
    private bool ifDead=true;

    // Start is called before the first frame update
    void Start(){
        speed=Random.Range(minSpeed,maxSpeed);
        frogScript=GameObject.FindGameObjectWithTag("Player").GetComponent<FrogMovement>();//gets the component of thegameobject with the tag of player 
        renderer= GetComponent<SpriteRenderer>();
        timeForSpawn=startTimeBetween;
    }

    // Update is called once per frame
    void Update(){      
        if(ifRight){
            // Debug.Log("going to the right");
            transform.Translate(Vector2.right*speed*Time.deltaTime);
        }else{
            // Debug.Log("going to the left");
            transform.Translate(Vector2.left*speed*Time.deltaTime); 
        }

        if(gameObject.transform.position.x<=t1.position.x){
            // Debug.Log("hit the left side");
            renderer.flipX = true;
            ifRight=true;
        }else if(gameObject.transform.position.x>=t2.position.x){
            // Debug.Log("hit the right side");
            renderer.flipX = false;
            ifRight=false;
        }

        if(ifDead){
            if(timeForSpawn <=0){
                gameObject.transform.position = new Vector3(t2.position.x, t2.position.y, t2.position.z);
                timeForSpawn=startTimeBetween;
                ifDead=false;
            }else{
                timeForSpawn -=Time.deltaTime;                        

            }
        }
    }

        //when the enemy takes damages from the bullet
        //need this function to be public becuase it needs to be acessed by the 'BulletProp' script
        public void TakeDamage(int damage){
            health-=damage;
            if(health<=0){
                Destroy(gameObject);
            }
        }

     //collision detection
    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.tag=="Player"){
            frogScript.takeLife();
            transform.position = new Vector3(-15.5f, 6.2f, -20.8f);
            ifDead=true;
        }
    }   

    //when the enemy dies
    void Die(){
        Destroy(gameObject);
    }
}
