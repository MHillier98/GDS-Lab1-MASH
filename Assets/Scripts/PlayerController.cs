using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float MovementSpeed = 15.0f;

    [SerializeField]
    public int SoldiersCollected = 0;

    [SerializeField]
    public int MaxSoldiers = 3;

    [SerializeField]
    private TextMeshPro ScoreCounter;

    [SerializeField]
    public AudioClip PickupSound;

    [SerializeField]
    public AudioClip DropoffSound;

    [SerializeField]
    public AudioClip DeathSound;

    private void Start()
    {
        ScoreCounter = gameObject.GetComponentInChildren<TextMeshPro>();
        UpdateScoreText();
    }

    private void Update()
    {
        Move();
        UpdateScoreText();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime * MovementSpeed;
        float verticalInput = Input.GetAxisRaw("Vertical") * Time.deltaTime * -MovementSpeed;

        Vector3 movement = new Vector3(verticalInput, 0, horizontalInput);
        transform.Translate(movement);
    }

    private void UpdateScoreText()
    {
        if (ScoreCounter != null)
        {
            ScoreCounter.SetText(SoldiersCollected.ToString());
        }
    }

    public int GetSoldiersCollected()
    {
        return SoldiersCollected;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Equals("Soldier"))
        {
            if (SoldiersCollected < MaxSoldiers)
            {
                if (PickupSound != null)
                {
                    Vector3 soundLocation = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 20.0f, gameObject.transform.position.z);
                    AudioSource.PlayClipAtPoint(PickupSound, soundLocation);
                }

                SoldiersCollected += 1;
                Destroy(collider.gameObject);
            }
        }
        else if (collider.gameObject.tag.Equals("Hospital"))
        {
            if (DropoffSound != null)
            {
                Vector3 soundLocation = new Vector3(0, gameObject.transform.position.y + 20.0f, 0);
                AudioSource.PlayClipAtPoint(DropoffSound, soundLocation);
            }

            HospitalController hospitalController = collider.gameObject.GetComponent<HospitalController>();
            if (hospitalController != null)
            {
                hospitalController.AddSoldiersCollected(SoldiersCollected);
            }
            SoldiersCollected = 0;
        }
        else if (collider.gameObject.tag.Equals("Rock"))
        {
            if (DeathSound != null)
            {
                Vector3 soundLocation = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 20.0f, gameObject.transform.position.z);
                AudioSource.PlayClipAtPoint(DeathSound, soundLocation);
            }

            Destroy(gameObject);
        }
    }
}
