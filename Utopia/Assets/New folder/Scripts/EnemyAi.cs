using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    // reference all waypoints in our enemy path
    public List<Transform> points;
    // the next int value for the next index item in our list
    public int nextId;
    // Create a int that will help us change our nextId
    private int idChangeValue = 1;
    //float to set our speed of our enemy
    public float speed = 2;
    // Update is called once per frame
    Vector2 Target;
    public Transform Player;
    public int enemyHealth = 6;
    void Update()
    {
        enemyDeath();
        if (Vector2.Distance(transform.position, Player.position) < 5f)
        {
            Debug.Log("hello");
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        }
        else
        {
            MoveToNextPoint();
        }
    }
    void MoveToNextPoint()
    {
        //create a variable to set our goalpoint based off our list
        Transform goalPoint = points[nextId];
        //flip the enemy so it is looking at its current goal
        // Might need to change based off your sprite 
        if (goalPoint.transform.position.x > transform.position.x)
        {                                       //1
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {                                       //-1
            transform.localScale = new Vector3(1, 1, 1);
        }
        //move towards our goalPoint
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);

        //check distance between enemy and goalpoint to trigger the next point
        if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
            //Check if we are at the end of the line make the change to -1
            if (nextId == points.Count - 1)
            {
                idChangeValue = -1;
            }
            //Check if we are at the end of the line make the change to 1
            if (nextId == 0)
            {
                idChangeValue = +1;
            }
            nextId += idChangeValue;
        }
    }
    public void TakeDamage()
    {
        enemyHealth -= 2;
    }
    public void enemyDeath()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            speed = 0f;
        }
    }
}
