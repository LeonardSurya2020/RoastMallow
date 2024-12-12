using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUpManager : MonoBehaviour
{
    private bool canDash = false;
    private bool canAbi = false;

    public PlayerUnit PlayerUnitControl;

    public WaveSpawner powerManager;
    public TextMeshProUGUI dmgUp;
    public TextMeshProUGUI hpUp;
    public TextMeshProUGUI spdUp;

    public void Update()
    {
        dmgUp.text = "Damage +2";
        spdUp.text = "Speed +2";
        hpUp.text = "Hp +10";
    }
    public void AttackUp()
    {
        Bullet.damage += 2;
        WaveSpawner.isPaused = false;
        powerManager.Resume();
    }

    public void totalBulletUp()
    {
        Player_mov.ms += 1;
        Shooting.bulletForce += 1;
        //Shooting2.totalBulletNum += 2;
        WaveSpawner.isPaused = false;
        powerManager.Resume();
    }

    public void HPUp()
    {
        PlayerUnit.MaxHp += 10;
        PlayerUnit.CurrentHP += 10;
        PlayerUnit.CHP += 10;
        WaveSpawner.isPaused = false;
        powerManager.Resume();
    }

    public void DashAbility()
    {

    }

    public void ultimateAbility()
    {

    }
}
