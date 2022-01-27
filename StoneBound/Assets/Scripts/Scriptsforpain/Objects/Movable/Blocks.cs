using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public void BeingMoved(Transform mover)
    {
        gameObject.transform.position += Vector3.back * 100 * Time.deltaTime;
    }
}
