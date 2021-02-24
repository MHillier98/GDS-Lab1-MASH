using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro HoverText;

    private bool gameover = false;

    private void Start()
    {
        HoverText = gameObject.GetComponentInChildren<TextMeshPro>();
        if (HoverText != null)
        {
            HoverText.SetText("");
        }
    }

    void Update()
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
                gameover = true;
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
                if (HoverText != null)
                {
                    HoverText.SetText("You win!");
                }
                gameover = true;
            }
        }
    }
}
