using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    private void Start()
    {
        float randomRotation = Random.Range(0, 360);
        transform.Rotate(Vector3.down, randomRotation);
    }
}
