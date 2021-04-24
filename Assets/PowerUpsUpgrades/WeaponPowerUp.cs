using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponPowerUp", menuName = "WeaponPowerUp", order = 2)]
public class WeaponPowerUp : PowerUp
{
    public float damageChange;
    public float speedChange;
    public int spreadChange;
    public int sizeChange;
    public int maxAmmoChange;

    override public void UsePowerup(GameObject playerObject)
    {
        playerObject.GetComponent<Weapon>().increaseDamage(damageChange);
        playerObject.GetComponent<Weapon>().increaseSpeed(speedChange);
        playerObject.GetComponent<Weapon>().increaseSpread(spreadChange);
        playerObject.GetComponent<Weapon>().increaseSize(sizeChange);
        playerObject.GetComponent<Weapon>().increaseMaxAmmo(maxAmmoChange);
    }
}
