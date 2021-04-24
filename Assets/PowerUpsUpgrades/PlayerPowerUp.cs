using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPowerUp", menuName = "PlayerPowerUp", order = 1)]
public class PlayerPowerUp : PowerUp
{
    public float maxSpeedChange;
    public float speedChange;
    public float jumpHeightChange;
    public float massChange;

    override public void UsePowerup(GameObject playerObject)
    {
        playerObject.GetComponent<PlayerController>().increaseMaxSpeed(maxSpeedChange);
        playerObject.GetComponent<PlayerController>().increasePlayerSpeed(speedChange);
        playerObject.GetComponent<PlayerController>().increaseJumpHeight(jumpHeightChange);
        playerObject.GetComponent<PlayerController>().increaseMass(massChange);
    }
}
