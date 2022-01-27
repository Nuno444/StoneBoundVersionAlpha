using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCaveBlock : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "BigMovable")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
