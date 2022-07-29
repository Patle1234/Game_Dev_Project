using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    private bool ifDead=false;
    public int health=100;
    public Transform t2;//the point at which the enemy will respawn
    public float startTimeBetween;//the interval between the enemy's death and respawn
    private float timeForSpawn;//timer between the time the enemy dies and needs to respawn
    FrogMovement frogScript;

    // Start is called before the first frame update
    void Start()
    {
        frogScript=GameObject.FindGameObjectWithTag("Player").GetComponent<FrogMovement>();//gets the component of thegameobject with the tag of player 
    }

    // Update is called once per frame
    void Update(){
        if(ifDead){
            if(timeForSpawn <=0){
                gameObject.transform.position = new Vector3(t2.position.x, t2.position.y, t2.position.z);
                timeForSpawn=startTimeBetween;
                ifDead=false;
            }else{
                gameObject.transform.position = new Vector3(-15.5f, 6.2f, -20.8f);
                timeForSpawn -=Time.deltaTime;                        
            }
        }
    }

    //collision detection
    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.tag=="Player"){
            frogScript.takeLife();
            ifDead=true;
        }
    }   

    //when the enemy dies
    void Die(){
        ifDead=true;
        transform.position = new Vector3(-15.5f, 6.2f, -20.8f);
    }

    //when the enemy takes damages from the bullet
    //need this function to be public becuase it needs to be acessed by the 'BulletProp' script
    public void TakeDamage(int damage){
        health-=damage;
        if(health<=0){
            Die();
        }
    }

}
