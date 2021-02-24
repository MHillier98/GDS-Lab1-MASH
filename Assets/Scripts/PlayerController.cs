using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 15.0f;

    void Start()
    {

    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime * MovementSpeed;
        float verticalInput = Input.GetAxisRaw("Vertical") * Time.deltaTime * MovementSpeed;

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(movement);
    }
}
