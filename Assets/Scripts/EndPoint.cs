using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
        private Rigidbody2D rb;
        public string sceneName;//variable for end game scene

    //Collision detection
    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.tag=="Player"){
            SceneManager.LoadScene(sceneName);  
        }
    }   
}
