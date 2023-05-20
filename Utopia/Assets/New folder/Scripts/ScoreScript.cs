using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text Myscoretext;
    PlayerManager playermanager;

    // Start is called before the first frame update
    void Start()
    {
        playermanager = GameObject.FindGameObjectWithTag("PracticePlayer").GetComponent<PlayerManager>();
    }
     void Update()
    {
        Myscoretext.text = "Score : " + playermanager.coincount;
    }
}
