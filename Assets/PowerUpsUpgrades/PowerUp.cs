using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum powerUpType
{
    DEFAULT,
    PLAYER,
    WEAPON
}

[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUp", order = 0)]
public class PowerUp : ScriptableObject
{
    public Mesh powerUpMesh;
    public Material powerUpMaterial;

    virtual public void UsePowerup(GameObject playerObject)
    {

    }

}
