using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Range(-50f, -1f)] public float gravity;
    public GameObject human, dog, camera;
    public CameraBehaviour camera_behaviour;
    public CharacterControl human_controller, dog_controller;
    public Dog dog_script;
    public SceneController scene_controller;
    public Vector3[] spawn_points;
    public Vector3 dog_spawn_offset;

    void Start()
    {
        Physics.gravity = new Vector3(0, gravity);
        //scene_controller.SceneChanger(0, 1, 0);
    }

    public void GameStart()
    {
        scene_controller.SceneChanger(1, 2, 1);
        human.SetActive(true);
        dog.SetActive(true);
        camera.SetActive(true);
        SpawnPlayer(0);
    }

    public void CharacterChange(int where_to)
    {
        camera_behaviour.ChangeViewpoint(where_to);
        if (human_controller.enabled)
        {
            human_controller.enabled = false;
            dog_controller.enabled = true;
            dog_script.DogSwitch(true);
        }
        else
        {
            human_controller.enabled = true;
            dog_controller.enabled = false;
            dog_script.DogSwitch(false);
        }
    }

    public void ChangeLevel(int next_spawn_point, int last_scene, int new_scene, int change_type)
    {
        scene_controller.SceneChanger(last_scene, new_scene, change_type);
        SpawnPlayer(next_spawn_point);
    }

    public void CallDogThrow(Transform human_transform)
    {
        dog_controller.Movement(human_transform.position.x, human_transform.position.z);
        dog_script.BeingCarried();
    }

    public void SpawnPlayer(int next_spawn_point)
    {
        do
        {
            human.transform.position = spawn_points[next_spawn_point];
            dog.transform.position = spawn_points[next_spawn_point] + dog_spawn_offset;
        } while (human.transform.position != spawn_points[next_spawn_point]);
        Debug.Log("Spawn point success");
    }

    public void SceneControllerCall(int last_scene, int new_scene)
    {
        scene_controller.SceneChanger(last_scene, new_scene, 2);
        human.transform.position = spawn_points[new_scene - 1];
    }
}
