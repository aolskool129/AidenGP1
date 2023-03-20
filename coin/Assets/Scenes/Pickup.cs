using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //access our function from our player manager and call it
        PlayerManager manager = collision.GetComponent<PlayerManager>();
        if (collision.gameObject.CompareTag("Player"))
        {
            if (manager)
            {
                bool pickedUp = manager.PickupItem(gameObject);
                if (pickedUp)
                {
                    // create if statement for picked up
                    Destroy(gameObject);
                }
            }
        }
    }
}
