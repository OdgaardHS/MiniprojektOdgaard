
using UnityEngine;

public class Gun : MonoBehaviour
{
   public float dmg = 10f;
   public float range = 100f;

   public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        //if left click is pressed, the function shoot will be called. note that this script is only active if the gameobject gun(which is attached to the player) is active
        if(Input.GetButtonDown("Fire1"))
        {
            //shoot function is called from down below
            Shoot();


        }
    }




    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();
           // if (enemy != null)
           // {
                enemy.TakeDamage(dmg);
                
          //  }
        }
        
    }
}
