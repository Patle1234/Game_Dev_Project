using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab; 

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown("f")){//when player presses the 'f' key 
            Shoot();
        }
    }

    //Creates a bullet on the screen at the players position
    private void Shoot(){
        Instantiate(bulletPrefab,firepoint.position,firepoint.rotation );
    }

}
