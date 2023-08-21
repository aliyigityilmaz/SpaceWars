using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIManager : MonoBehaviour
{
    public GameObject[] units;
    public Transform[] spawnPoints;
    public Transform[] destinationPoints;
    public Transform[] secondDestinationPoints;
    public Transform[] finalAttacks;

    public float spawnInterval;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex == 1)
        {
            spawnInterval = 15f;
        }
        if (currentScene.buildIndex == 2)
        {
            spawnInterval = 10f;
        }
        if (currentScene.buildIndex == 3)
        {
            spawnInterval = 5f;
        }
        InvokeRepeating("SpawnUnit", 0f, spawnInterval);
    }

    private void SpawnUnit()
    {
        Transform randomSpawnPoint = spawnPoints[UnityEngine.Random.Range(0,spawnPoints.Length)];
        GameObject newUnit = Instantiate(units[UnityEngine.Random.Range(0,units.Length)], randomSpawnPoint.position, Quaternion.identity);
        Transform randomDestination = destinationPoints[UnityEngine.Random.Range(0,destinationPoints.Length)];
        Transform randomAttack = finalAttacks[UnityEngine.Random.Range(0, finalAttacks.Length)];

        AIMovement aIMovement = newUnit.GetComponent<AIMovement>();
        if (aIMovement != null)
        {
            aIMovement.SetTarget(randomDestination.position);
            StartCoroutine(CheckTargetReached(aIMovement, randomAttack.position));
        }
    }
    private IEnumerator CheckTargetReached(AIMovement aIMovement, Vector3 attackPosition)
    {
        Transform randomAttack = finalAttacks[UnityEngine.Random.Range(0, finalAttacks.Length)];

        bool reachedFirstDestination = false;
        bool reachedSecondDestination = false;
        while (true)
        {
            yield return new WaitForSeconds(0.2f); // Adjust the interval as needed

            if (!reachedFirstDestination && aIMovement.targetReached)
            {
                aIMovement.SetTarget(secondDestinationPoints[UnityEngine.Random.Range(0, secondDestinationPoints.Length)].position);
                reachedFirstDestination = true;
            }
            else if (!reachedSecondDestination && aIMovement.targetReached)
            {
                aIMovement.SetTarget(randomAttack.position);
                reachedSecondDestination = true;
            }
        }
    }
}
