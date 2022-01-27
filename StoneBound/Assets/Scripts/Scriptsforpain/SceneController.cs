using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameController game_controller;
    public KeyCode[] scene_change_test;
    //public 
    
    // Start is called before the first frame update
    void Start()
    {
        SceneChanger(0, 1, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(scene_change_test[scene_change_test.Rank]))
        {
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
            game_controller.SceneControllerCall(1, scene_change_test.Rank);
        }
    }

    public void SceneChanger(int last_scene, int new_scene, int change_type)
    {
        switch (change_type)
        {
            case 0 : //Load without unloading another scene
                SceneManager.LoadSceneAsync(new_scene, LoadSceneMode.Additive);
                break;
            case 1 : //Load and unload another scene
                SceneManager.UnloadSceneAsync(last_scene);
                SceneManager.LoadSceneAsync(new_scene, LoadSceneMode.Additive);
                break;
            case 2 : //Load a scene by itself
                SceneManager.LoadSceneAsync(new_scene, LoadSceneMode.Single);
                break;
        }
    }
}
