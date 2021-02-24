using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float MovementSpeed = 15.0f;

    [SerializeField]
    public int SoldiersCollected = 0;

    [SerializeField]
    public int MaxSoldiers = 3;

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime * MovementSpeed;
        float verticalInput = Input.GetAxisRaw("Vertical") * Time.deltaTime * -MovementSpeed;

        Vector3 movement = new Vector3(verticalInput, 0, horizontalInput);
        transform.Translate(movement);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Equals("Soldier"))
        {
            if (SoldiersCollected < MaxSoldiers)
            {
                SoldiersCollected += 1;
                Destroy(collider.gameObject);
            }
        }
        else if (collider.gameObject.tag.Equals("Hospital"))
        {
            HospitalController hospital = collider.gameObject.GetComponent<HospitalController>();
            hospital.AddSoldiersCollected(SoldiersCollected);
            SoldiersCollected = 0;
        }
        else if (collider.gameObject.tag.Equals("Rock"))
        {
            Destroy(gameObject);
        }
    }
}
