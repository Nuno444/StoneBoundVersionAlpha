using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterControl : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Collider collider;
    public KeyCode foward;
    public KeyCode backward;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode character_change;
    [Range(0, 1)] public int camera_identification;
    private GameController game_controller;
    [Range(1f, 100f)] public float speed;
    [Range(100f, 500f)] public float jump_height;
    [Range(1f, 50f)] public float floor_distance_constant;
    private Ray floor_detector;
    private RaycastHit floor_distance;
    private bool is_jumping;
    public Animator player_animator;

    private void Start()
    {
        game_controller = FindObjectOfType<GameController>();
        is_jumping = false;
        floor_detector = new Ray(gameObject.transform.position, Vector3.down);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(foward))
        {
            Movement(0, -speed);
            player_animator.SetBool("Walk", true);
        } else
        {
            player_animator.SetBool("Walk", false);
        }
        if (Input.GetKey(right))
        {
            Movement(-speed, 0);
        }
        if (Input.GetKey(left))
        {
            Movement(speed, 0);
        }
        if (Input.GetKey(backward))
        {
            Movement(0, speed);
        }
        if ((Input.GetKeyDown(jump)) && !(is_jumping))
        {
            rigidbody.AddForce(0, jump_height, 0);
            is_jumping = true;
        }
        else if (is_jumping)
        {
            if ((Physics.Raycast(floor_detector, out floor_distance, floor_distance_constant)) && (floor_distance.collider.tag == "Floor"))
            {
                is_jumping = false;
            }
        }
        if (Input.GetKeyDown(character_change))
        {
            game_controller.CharacterChange(camera_identification);
        }
    }
    
    public void Movement(float move_x, float move_z)
    {
        //float xDirection = Input.GetAxis("Horizontal");
        //float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(move_x, 0.0f, move_z);
        transform.position += moveDirection * Time.deltaTime;
    }
}
