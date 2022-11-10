using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveScript : MonoBehaviour
{
    //Enables us to assign which gameobjects we want to work with from the editor
    public GameObject HandGun;
    public GameObject BordGun;
 

void Start () 
    {
        //Disables one gameobject and enables another
        HandGun.SetActive(false);
        BordGun.SetActive(true);
    }
 
void OnTriggerEnter(Collider _col){
    if (_col.gameObject.CompareTag ("Player")) 
        {
            //if player has collided with the object, it dissappears and the other one appears
            HandGun.SetActive(true);
            BordGun.SetActive(false);
        }
    }
}
