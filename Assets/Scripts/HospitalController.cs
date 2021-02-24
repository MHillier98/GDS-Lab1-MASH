using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HospitalController : MonoBehaviour
{
    [SerializeField]
    private int SoldiersCollected = 0;

    [SerializeField]
    private TextMeshPro ScoreCounter;

    private void Start()
    {
        ScoreCounter = gameObject.GetComponentInChildren<TextMeshPro>();
        UpdateScoreText();
    }

    private void Update()
    {
        UpdateScoreText();
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

    public void SetSoldiersCollected(int NewSoldiers)
    {
        SoldiersCollected = NewSoldiers;
    }

    public void IncrementSoldiersCollected()
    {
        SoldiersCollected += 1;
    }

    public void AddSoldiersCollected(int NewSoldiers)
    {
        SoldiersCollected += NewSoldiers;
    }

    public void ClearSoldiersCollected()
    {
        SoldiersCollected = 0;
    }
}
