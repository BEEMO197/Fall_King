using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHandler : MonoBehaviour
{
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;
    public PowerUp[] powerUps;
    public PowerUp powerUpInSlot;

    private void Awake()
    {
        // 10% chance of Spawning
        if (Random.Range(0, 10) == 1)
        {   
            meshFilter.mesh = powerUpInSlot.powerUpMesh;
            meshRenderer.material = powerUpInSlot.powerUpMaterial;
            powerUpInSlot = powerUps[Random.Range(0, powerUps.Length)];
        }
        else
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            powerUpInSlot.UsePowerup(other.gameObject);
            Destroy(gameObject);
        }
    }
}
