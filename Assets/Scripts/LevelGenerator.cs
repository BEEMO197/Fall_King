using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject floorPrefab;
    [SerializeField] private Vector3 spawnCenter;
    [SerializeField] private Vector3 spawnExtents;

    [SerializeField] private float spawnDistance;
    [SerializeField] private int spawnAmountMin = 1;
    [SerializeField] private int spawnAmountMax;
    [SerializeField] private int spawnAmount;

    private void Awake()
    {
        randomizeVariables();
        spawnFloors();
    }

    private void randomizeVariables()
    {
        spawnAmount = Random.Range(spawnAmountMin, spawnAmountMax + 1);

        spawnDistance = (spawnExtents.y * 2) / spawnAmount;
    }

    private void spawnFloors()
    {
        for(int i = 0; i < spawnAmount; i++)
        {
            Instantiate(floorPrefab, new Vector3(Random.Range(-spawnExtents.x / 2, spawnExtents.x / 2), i * -spawnDistance, spawnCenter.z), new Quaternion(), transform);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(spawnCenter, spawnExtents);
    }
}
