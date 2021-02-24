using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalController : MonoBehaviour
{
    [SerializeField]
    private int SoldiersCollected = 0;

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
}
