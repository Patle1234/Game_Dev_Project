using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProp : MonoBehaviour
{
    public int damage=20;//the damage that a bullet deals to an enemy
    public float speed=20f;//the speed at which the bullet will move
    public Rigidbody2D rb;
    FrogMovement frogScript;

    // Start is called before the first frame update
    void Start(){
        frogScript=GameObject.FindGameObjectWithTag("Player").GetComponent<FrogMovement>();//gets the gameobject with the tag of player 
        bulletSide();
    }

    //collision detection
    public void  OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Enemy")){
            Enemy enemy = other.GetComponent<Enemy>();
            if(enemy !=null){
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }else if (other.CompareTag("Enemy2")){
            Enemy2 enemy = other.GetComponent<Enemy2>();
            if(enemy !=null){
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }else if (other.CompareTag("Enemy3")){
            Enemy3 enemy = other.GetComponent<Enemy3>();
            if(enemy !=null){
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
    
    //finds the direction that the bullet has to go
    public void bulletSide(){
        if(frogScript.playerIsRight){
            rb.velocity = transform.right*speed;
        }else{
            rb.velocity = -transform.right*speed;
        }
    }
}
