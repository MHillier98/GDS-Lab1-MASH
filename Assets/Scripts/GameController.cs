using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro HoverText;

    [SerializeField]
    public GameObject Player;

    [SerializeField]
    public Vector3 PlayerSpawnPosition;

    private bool gameover = false;

    [SerializeField]
    public int WavesCompleted = 0;

    [SerializeField]
    public GameObject RockObject;

    [SerializeField]
    public GameObject SoldierObject;

    private void Start()
    {
        HoverText = gameObject.GetComponentInChildren<TextMeshPro>();
        if (HoverText != null)
        {
            HoverText.SetText("");
        }

        GenerateMap(true, true);
    }

    private void Update()
    {
        if (!gameover)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            if (players.Length > 1)
            {
                if (HoverText != null)
                {
                    HoverText.SetText("Why is there more than one player?!");
                }
                return;
            }
            else if (players.Length <= 0)
            {
                if (HoverText != null)
                {
                    HoverText.SetText("Game over!");
                }
                gameover = true;
                return;
            }

            GameObject[] soldiers = GameObject.FindGameObjectsWithTag("Soldier");
            if (soldiers.Length <= 0)
            {
                if (players.Length > 0)
                {
                    PlayerController playerController = players[0].GetComponent<PlayerController>();
                    int playerSoldiersCollected = playerController.GetSoldiersCollected();
                    if (playerSoldiersCollected <= 0)
                    {
                        if (HoverText != null)
                        {
                            WavesCompleted += 1;
                            GenerateMap(false, true); // spawn new soldiers
                        }
                    }
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                HoverText.SetText("");
                Instantiate(Player, PlayerSpawnPosition, Quaternion.Euler(0, 90, 0));
                gameover = false;
            }
        }
    }

    private void GenerateMap(bool generateRocks = false, bool generateSoldiers = false)
    {
        for (float x = -5.0f; x <= 22.0f; x += 0.5f)
        {
            for (float y = -13.0f; y <= 13.0f; y += 0.5f)
            {
                float newNoise = Random.Range(0.0f, 10000f);
                float noise = Mathf.PerlinNoise(x + newNoise, y + newNoise);
                if (noise >= 0.87f)
                {
                    if (RockObject != null && generateRocks)
                    {
                        float randomRotation = Random.Range(0, 360);
                        Instantiate(RockObject, new Vector3(x, 0.0f, y), Quaternion.Euler(0, randomRotation, 0));
                    }
                }
                else if (noise <= 0.04f)
                {
                    if (SoldierObject != null && generateSoldiers)
                    {
                        float randomRotation = Random.Range(0, 360);
                        Instantiate(SoldierObject, new Vector3(x, 0.5f, y), Quaternion.Euler(90.0f, 0, 0));
                    }
                }
            }
        }
    }
}
