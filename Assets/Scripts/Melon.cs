using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Melon : MonoBehaviour{
    private static int score=0;//the total score during the game
    private Rigidbody2D rb;
    public TextMeshProUGUI text;//variable for score text(display) 

    // Start is called before the first frame update
    void Start(){
        rb= GetComponent<Rigidbody2D>();
        text.text = "Score: " + score;  
    }

    //Collision Detection
    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.name=="Player"){
            score++;
            text.text = "Score: " + score;
            Destroy(gameObject);  
        }
    }
}
