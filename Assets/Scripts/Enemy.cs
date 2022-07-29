using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    public int health=100;
    public float minSpeed;
    public float maxSpeed;
    private float speed;
    public Transform t1;
    public Transform t2;
    private bool ifDead=false;
    public float startTimeBetween;//at start of game, how long it takes to spawn a new enemy
    private float timeForSpawn; 
    FrogMovement frogScript;

    // Start is called before the first frame update
    void Start(){
        speed=Random.Range(minSpeed,maxSpeed);
        frogScript=GameObject.FindGameObjectWithTag("Player").GetComponent<FrogMovement>();//gets the component of thegameobject with the tag of player 
        timeForSpawn=startTimeBetween;
    }
    // Update is called once per frame
    void Update(){
        transform.Translate(Vector2.left*speed*Time.deltaTime);
        if(gameObject.transform.position.x<=t1.position.x){
            ifDead=true;
        }
        if(ifDead){
            if(timeForSpawn <=0){
                health=100;
                gameObject.transform.position = new Vector3(t2.position.x, t2.position.y, t2.position.z);
                timeForSpawn=startTimeBetween;
                ifDead=false;
            }else{
                gameObject.transform.position = new Vector3(-15.5f, 6.2f, -20.8f);
                timeForSpawn -=Time.deltaTime;                        
            }
        }
    }
    //Collision Detection
    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.tag=="Player"){
            frogScript.takeLife();
            ifDead=true;
        }
    }   



    //need this function to be public becuase it needs to be acessed by the 'BulletProp' script
    public void TakeDamage(int damage){
        health-=damage;
        if(health<=0){
            Die();
        }
    }

    //call when the enemy dies
    void Die(){
        ifDead=true;
        transform.position = new Vector3(-15.5f, 6.2f, -20.8f);
    }

}
