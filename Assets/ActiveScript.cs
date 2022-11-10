using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveScript : MonoBehaviour
{
    //Enables us to assign which gameobjects we want to work with from the editor
    public GameObject HandGun;
    public GameObject BordGun;
    public GameObject RedLight;
    public GameObject WhiteLight;

    public GameObject Downstair1;
    public GameObject Downstair2;
    public GameObject Downstair3;
 
    public GameObject Horde;

void Start () 
    {
        //Disables one gameobject and enables another
        HandGun.SetActive(false);
        BordGun.SetActive(true);
        RedLight.SetActive(false);
        WhiteLight.SetActive(true);

        Downstair1.SetActive(true);
        Downstair2.SetActive(true);
        Downstair3.SetActive(true);

        Horde.SetActive(false);
    }
 
void OnTriggerEnter(Collider _col){
    if (_col.gameObject.CompareTag ("Player")) 
        {
            //if player has collided with the object, it dissappears and the other one appears
            HandGun.SetActive(true);
            BordGun.SetActive(false);
            RedLight.SetActive(true);
            WhiteLight.SetActive(false);

            Downstair1.SetActive(false);
            Downstair2.SetActive(false);
            Downstair3.SetActive(false);

            Horde.SetActive(true);
        }
    }
}
