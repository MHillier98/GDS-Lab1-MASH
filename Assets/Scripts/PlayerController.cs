using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 15.0f;

    public int SoldiersCollected = 0;
    public int MaxSoldiers = 3;

    void Start()
    {

    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime * MovementSpeed;
        float verticalInput = Input.GetAxisRaw("Vertical") * Time.deltaTime * -MovementSpeed;

        Vector3 movement = new Vector3(verticalInput, 0, horizontalInput);
        transform.Translate(movement);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.Contains("Soldier"))
        {
            if (SoldiersCollected < MaxSoldiers)
            {
                SoldiersCollected += 1;
                Destroy(collider.gameObject);
            }
        }
    }
}
