using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CreditSystem : MonoBehaviour
{
    public int credit;
    public int creditGain;
    public float creditTimer;
    public Text creditText;
    public GameObject fighterPrefab;
    public GameObject cruiserPrefab;
    public GameObject battleshipPrefab;
    public GameObject fighterspawnPoint;
    public GameObject cruiserspawnPoint;
    public GameObject battleshipspawnPoint;
    public GameObject checkpoint;
    public GameObject checkpoint2;
    public GameObject checkpoint3;

    public GameObject miniP1, miniP2, miniP3, miniP4, miniP5, miniP6, miniP7, miniP8, miniP9, miniP10;
    public bool m1, m2,m3,m4,m5,m6,m7,m8,m9,m10;
    // Start is called before the first frame update
    void Start()
    {
        credit = 200;
        creditGain = 10;
    }

    // Update is called once per frame
    void Update()
    {
        bool Redwinning = checkpoint.GetComponent<CheckpointScript>().RedWinning;
        bool Bluewinning = checkpoint.GetComponent<CheckpointScript>().BlueWinning;
        bool Redwinning2 = checkpoint2.GetComponent<CheckpointScript>().RedWinning;
        bool Bluewinning2 = checkpoint2.GetComponent<CheckpointScript>().BlueWinning;
        bool Redwinning3 = checkpoint3.GetComponent<CheckpointScript>().RedWinning;
        bool Bluewinning3 = checkpoint3.GetComponent<CheckpointScript>().BlueWinning;
        m1=miniP1.GetComponent<CheckpointScript>().BlueWinning;
        m2 = miniP2.GetComponent<CheckpointScript>().BlueWinning;
        m3 = miniP3.GetComponent<CheckpointScript>().BlueWinning;
        m4 = miniP4.GetComponent<CheckpointScript>().BlueWinning;
        m5 = miniP5.GetComponent<CheckpointScript>().BlueWinning;
        m6 = miniP6.GetComponent<CheckpointScript>().BlueWinning;
        m7 = miniP7.GetComponent<CheckpointScript>().BlueWinning;
        m8 = miniP8.GetComponent<CheckpointScript>().BlueWinning;
        m9 = miniP9.GetComponent<CheckpointScript>().BlueWinning;
        m10 = miniP10.GetComponent<CheckpointScript>().BlueWinning;
        int moremoney = 10;

        creditTimer += Time.deltaTime;
        if (creditTimer >= 2.0f)
        {
            if (Bluewinning)
            {
                int extraCreditOne = 30;
                credit += extraCreditOne;
            }
            if (Bluewinning2)
            {
                int extraCreditOne = 30;
                credit += extraCreditOne;
            }
            if (Bluewinning3)
            {
                int extraCreditOne = 30;
                credit += extraCreditOne;
            }
            if (m1){credit += moremoney;}
            if (m2) { credit += moremoney; }
            if (m3) { credit += moremoney; }
            if (m4) { credit += moremoney; }
            if (m5) { credit += moremoney; }
            if (m6) { credit += moremoney; }
            if (m7) { credit += moremoney; }
            if (m8) { credit += moremoney; }
            if (m9) { credit += moremoney; }
            if (m10) { credit += moremoney; }
            credit += creditGain;
            creditTimer = 0.0f;
        }
        creditText.text = credit.ToString();
    }

    public void SpawnFighter()
    {
        if (credit >= 100)
        {
            Instantiate(fighterPrefab, fighterspawnPoint.transform.position, Quaternion.identity);
            credit -= 100;
        }
    }
    public void SpawnCruiser()
    {
        if (credit >= 500)
        {
            Instantiate(cruiserPrefab, cruiserspawnPoint.transform.position, Quaternion.identity);
            credit -= 500;
        }
    }
    public void Battleship()
    {
        if (credit >= 1500)
        {
            Instantiate(battleshipPrefab, battleshipspawnPoint.transform.position, Quaternion.identity);
            credit -= 1500;
        }
    }

}
