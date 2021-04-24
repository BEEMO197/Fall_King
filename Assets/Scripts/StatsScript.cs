using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsScript : MonoBehaviour
{
    public PlayerController pc;
    public Weapon pw;

    // Player Stats
    public TMPro.TextMeshProUGUI healthText;
    public TMPro.TextMeshProUGUI maxHealthText;
    public TMPro.TextMeshProUGUI moveSpeedText;
    public TMPro.TextMeshProUGUI maxSpeedText;
    public TMPro.TextMeshProUGUI jumpPowerText;
     
    // Weapon Stats
    public TMPro.TextMeshProUGUI strengthText;
    public TMPro.TextMeshProUGUI speedText;
    public TMPro.TextMeshProUGUI spreadText;
    public TMPro.TextMeshProUGUI sizeText;
    public TMPro.TextMeshProUGUI maxAmmotext;
    public TMPro.TextMeshProUGUI currentAmmoText;

    private void Update()
    {
        updateText();
    }

    private void updateText()
    {
        healthText.text = pc.getHealth().ToString();
        maxHealthText.text = pc.getMaxHealth().ToString();
        moveSpeedText.text = pc.getPlayerSpeed().ToString();
        maxSpeedText.text = pc.getMaxSpeed().ToString();
        jumpPowerText.text = pc.getJumpHeight().ToString();

        strengthText.text = pw.getDamage().ToString();
        speedText.text = pw.getSpeed().ToString();
        spreadText.text = pw.getSpread().ToString();
        sizeText.text = pw.getSize().ToString();
        maxAmmotext.text = pw.getMaxAmmo().ToString();
        currentAmmoText.text = pw.getCurrentAmmo().ToString();
    }
}
