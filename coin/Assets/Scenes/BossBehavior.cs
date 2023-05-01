using System;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    //creates a box to store information(position, rotation, scale)
    Transform player;
    public float attackRange = .5f;
    public float speed;
    PlayerManager playerManager;
    //store if our boss is flipped or not

    //store if our boss is flipped or not setting the value of false
    public bool isFlipped = false;
    //create a variable for the health of our boss
    public int bossHealth = 10;
    //create a series of bools to check and set our phases
    public bool phase2 = false;
    public bool phase3 = false;
    public bool isDead = false;
    //reference the location for our position to create our projectile
    public Transform shotLocation;
    public GameObject projectile;
    public GameObject projectile2;
    //create a timer system to ensure that the boss is shooting regularly
    public float timer;
    public int waitingTime;
    //create a function that will clone and create a version of our prefabed projectile
    // Start is called before the first frame update
    void Start()
    {
        //set our reference for our PlayerManager
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void TakeDamage()
    {
        bossHealth -= 2;
    }
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z = -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = true;
        }
        timer += Time.deltaTime;
    }
    public void ProjectileShoot()
    {
        if(timer < waitingTime)
        {
            if (phase2)
            {//clone and create our projectile
                GameObject clone = Instantiate(projectile, shotLocation.position, Quaternion.identity);
                //reset our timer
                timer = 0f;
            }
            else if (phase3)
            {
                GameObject clone = Instantiate(projectile2, shotLocation.position, Quaternion.identity);
                //reset our timer
                timer = 0f;
            }
        }
    }
    private void Update()
    {
        //create a series of if else statements that will check to see 
        //if the boss is below 2 and above 3 ,  below 3 and above 1,
        //and is less or equal to 0
        if (bossHealth < 7 && bossHealth > 3)
        { 
            phase2 = true;
            speed = 3;
            attackRange = 5;
            Debug.Log("phase 2");
        }
        else if (bossHealth < 4 && bossHealth >= 1)
        {
            phase2 = false;
            speed = 1;
            attackRange = 8;
            Debug.Log("phase 3");
            phase3 = true;
        }
        else if (bossHealth <= 0)
        {
            speed = 0f;
            phase3 = false;
            Debug.Log("isDead");
            isDead = true;
        }
    }
}
