using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //declare public max and current health
    public float maxHealth;
    public float currentHealth;
    public int coincount;
    PlayerMovement movement;

    void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    public bool PickupItem(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Currency":
                coincount++;
                return true;
            case "Speed+":
                movement.SpeedPowerUp();
                return true;
            default:
                Debug.Log("Item tag or reference not set");
                return false;
        }
    }
    //crate that minuses the players current health
    private void Update()
    {
        if (currentHealth <= 0)
        {
            PauseGame();
        }
    }
    public void TakeDamage()
    {
        currentHealth -= 1;
    }
    //create that will pause the game
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    //create a function that will resume the game
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
