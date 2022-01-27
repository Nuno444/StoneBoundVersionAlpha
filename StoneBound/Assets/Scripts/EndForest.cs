using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndForest : MonoBehaviour
{
    public GameController game_controller;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            game_controller.ChangeLevel(1, 2, 3, 1);
        }
    }
}
