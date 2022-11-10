using UnityEngine;

public class Enemy : MonoBehaviour
{
   public float health = 50f;

   public void TakeDamage(float amount)
   {
        //A function that is called from another script, whenever the function is called, something takes health damage equals to the amount float. if amount of dmg taken is higher than health, the gameobject is destroyed.
        health -= amount;
        if (health <= 0.2f)
        {
            die();

        }


   }


    void die()
    {
        Destroy(gameObject);

    }

}
