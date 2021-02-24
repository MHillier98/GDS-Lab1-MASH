using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Equals("Soldier"))
        {
            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.tag.Equals("Rock"))
        {
            Destroy(collider.gameObject);
        }
    }
}
