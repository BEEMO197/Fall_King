using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
            Destroy(gameObject);
    }
}
