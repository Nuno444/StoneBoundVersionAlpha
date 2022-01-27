using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public GameController game_controller;
    private Transform transform;
    public KeyCode move_object;
    [Range(1f, 200f)] public float move_distance_constant;
    public float block_detector_debugger;
    private Ray block_detector;
    private RaycastHit block_distance;
    private Blocks block_script;
    public Transform rock_spawner;
    public KeyCode rock_throw;
    public GameObject throwable_rock;
    public KeyCode dog_throw;
    private bool carrying_dog;
    public Animator human_animator;
    
    // Start is called before the first frame update
    void Start()
    {
        transform = gameObject.transform;
        block_detector = new Ray((transform.position + (Vector3.down * block_detector_debugger)), Vector3.back);
        block_script = null;
        carrying_dog = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(rock_throw))
        {
            Instantiate(throwable_rock, rock_spawner.position, Quaternion.Euler(0, 0, 0));
        }
        block_detector.origin = transform.position;
        if ((Physics.Raycast(block_detector, out block_distance, move_distance_constant)) && (block_distance.collider.tag == "BigMovable"))
        {
            Debug.DrawRay((transform.position + (Vector3.down * block_detector_debugger)), Vector3.back, Color.green);
            Debug.Log("Object found");
            block_script = block_distance.collider.gameObject.GetComponent<Blocks>();
        } else if (block_script != null)
        {
            block_script = null;
            human_animator.SetBool("Pushing", false);
        }
        if ((Input.GetKey(move_object)) && (block_script != null))
        {
            block_script.BeingMoved(transform);
            human_animator.SetBool("Pushing", true);
        }
        if (Input.GetKeyDown(dog_throw))
        {
            if (!carrying_dog)
            {
                game_controller.CallDogThrow(transform);
            }
        }
    }
}
