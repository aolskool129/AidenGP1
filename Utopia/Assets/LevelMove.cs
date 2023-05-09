using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    public int sceneBuildIndex;

    //Level move zone enter , if collider is a player
    //Move game to another scene 

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("trigger Entered");
        //could use other.GetComponent<PracticePlayer>() to see if the game object has a PracticePlayer component
        //Tags work too.  Maybe some players have different script components

        if(other.tag == "PracticePlayer")
        {
            print("Switching Scene to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex +1, LoadSceneMode.Single);
        }
    }
}
