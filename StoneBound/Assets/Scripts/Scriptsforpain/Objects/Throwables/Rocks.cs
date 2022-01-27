using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    public Rigidbody rigidbody;
    [Range(1f, 10f)] public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody.velocity = Vector3.back * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
