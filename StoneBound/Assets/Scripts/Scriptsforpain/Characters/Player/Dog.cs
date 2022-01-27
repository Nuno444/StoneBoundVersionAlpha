using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    private bool is_active_character;
    public Transform owner_transform;
    [Range(0.1f, 20f)] public float owner_distance;
    public CharacterControl character_control;
    private float dog_speed;
    [Range(0.001f, 0.1f)] public float speed_limiter;
    
    // Start is called before the first frame update
    void Start()
    {
        is_active_character = false;
        dog_speed = character_control.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if ((!is_active_character) && (Vector3.Distance(owner_transform.position, gameObject.transform.position) >= owner_distance))
        {
            character_control.Movement(((owner_transform.position.x - gameObject.transform.position.x) * dog_speed * speed_limiter), 
                ((owner_transform.position.z - gameObject.transform.position.z) * dog_speed * speed_limiter));
        }
    }

    public void DogSwitch(bool new_state)
    {
        is_active_character = new_state;
    }

    public void BeingCarried()
    {
        
    }
}
