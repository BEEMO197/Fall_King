using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab;

    // Damage of Bullets Also power for bonus jump
    [SerializeField] private float Damage = 1.0f;
    // Speed of Bullets and Speed of firing scale / second 5.0f = .02 per second so can fire every 5th of a second
    [SerializeField] private float Speed = 5.0f;
    // When the weapon can be used again
    [SerializeField] private bool canUse = false;
    // Size of Bullets
    [SerializeField] private int Size = 1;
    // Spread of Bullets
    [SerializeField] private int Spread = 1;
    // Ammo left
    [SerializeField] private int MaxAmmo = 8;
    // Spread of Bullets
    [SerializeField] private int CurrentAmmo = 8;
    // Spread of Bullets
    [SerializeField] private bool CurrentlyReloading = false;

    [SerializeField] private AudioSource bulletAudioSource;
    [SerializeField] private AudioClip bulletSoundEffect;

    public int getSize()
    {
        return Size;
    }

    public void setSize(int newSize)
    {
        Size = newSize;
    }

    public void increaseSize(int sizeToAdd)
    {
        Size += sizeToAdd;
    }

    public int getSpread()
    {
        return Spread;
    }

    public void setSpread(int newSpread)
    {
        Spread = newSpread;
        Spread = Spread > 3 ? 3 : Spread;
    }

    public void increaseSpread(int spreadToAdd)
    {
        Spread += spreadToAdd;
        Spread = Spread > 3 ? 3 : Spread;
    }

    public int getMaxAmmo()
    {
        return MaxAmmo;
    }

    public void setMaxAmmo(int newMaxAmmo)
    {
        MaxAmmo = newMaxAmmo;
    }

    public void increaseMaxAmmo(int maxAmmoToAdd)
    {
        MaxAmmo += maxAmmoToAdd;
    }

    public float getDamage()
    {
        return Damage;
    }

    public void setDamage(float newDamage)
    {
        Damage = newDamage;
    }

    public void increaseDamage(float damageToAdd)
    {
        Damage += damageToAdd;
    }

    public float getSpeed()
    {
        return Speed;
    }

    public void setSpeed(float newSpeed)
    {
        Speed = newSpeed;
    }

    public void increaseSpeed(float speedToAdd)
    {
        Speed += speedToAdd;
    }

    public int getCurrentAmmo()
    {
        return CurrentAmmo;
    }

    public void setCurrentAmmo(int newCurrentAmmo)
    {
        CurrentAmmo = newCurrentAmmo;
    }

    public void increaseCurrentAmmo(int currentAmmoToAdd)
    {
        CurrentAmmo += currentAmmoToAdd;
    }

    public virtual int useWeapon()
    {
        if (CurrentAmmo > 0 && canUse)
        {
            StartCoroutine(useCooldownLower());
            CurrentAmmo -= Spread;
            int bulletsToSpawn = CurrentAmmo < 0 ? Spread + CurrentAmmo : Spread;
            Debug.Log(bulletsToSpawn);
            int startSpawnAngle = 0;

            switch(bulletsToSpawn)
            {
                case 0:
                    startSpawnAngle = 0;
                    break;

                case 1:
                    startSpawnAngle = 0;
                    break;

                case 2:
                    startSpawnAngle = -15;
                    break;

                case 3:
                    startSpawnAngle = -30;
                    break;
            }

            for(int i = 0; i < bulletsToSpawn; i++)
            {
                GameObject bulletSpawned = Instantiate(BulletPrefab, transform.position, new Quaternion());
                bulletSpawned.transform.Rotate(new Vector3(0.0f, 0.0f, startSpawnAngle + (30 * i)));
                bulletSpawned.transform.localScale *= Size;

                bulletSpawned.GetComponent<Rigidbody>().velocity = (bulletSpawned.transform.rotation * Vector3.down) * Speed;
                StartCoroutine(killBullet(bulletSpawned));

                bulletAudioSource.PlayOneShot(bulletSoundEffect);
            }


            if(CurrentAmmo < 0)
                StartCoroutine(reloadWeapon());

            return CurrentAmmo < 0 ? Spread - CurrentAmmo : Spread;
        }
        else if(CurrentAmmo <= 0)
        {
            StartCoroutine(reloadWeapon());
        }
        return 0;
    }

    private IEnumerator killBullet(GameObject bulletToKill)
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(bulletToKill);
    }

    public IEnumerator useCooldownLower()
    {
        canUse = false;
        yield return new WaitForSeconds(1.0f / Speed);
        canUse = true;

    }

    public virtual IEnumerator reloadWeapon()
    {
        if (!CurrentlyReloading)
        {
            CurrentlyReloading = true;
            yield return new WaitForSeconds(2.0f / Speed);
            CurrentAmmo = MaxAmmo;
            CurrentlyReloading = false;
        }
    }
}
