using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUnit : MonoBehaviour
{
    public Image healthBar;
    public static float CHP = 5f;
    public static float MaxHp = 5f;
    [SerializeField]
    public  static float CurrentHP = 5;
    public TextMeshProUGUI MHPText;
    public TextMeshProUGUI CHPText;
    public static bool CanSetHP = false;
    public WaveSpawner powerManager;

    public GameObject gameOverMenu;
    public Behaviour waveManager;

    public Timer timer;
    //Temporary Data
    public int MaxHPData;
    public int CurrentHPData;
    public int CHPData;

   
    public Animator PlayerHitEffect;
    private void Start()
    {
        CHP = CHPData;
        MaxHp = MaxHPData;
        CurrentHP = CurrentHPData;
        MaxHp = CurrentHP; 

    }

    public void Update()
    {
        MHPText.text = CHP.ToString();
        CHPText.text = CurrentHP.ToString();
        healthBar.fillAmount = MaxHp / CHP;
    }

    public void TakeDamage(int totalDamage)
    {
        CurrentHP -= totalDamage;
        MaxHp -= totalDamage;
        PlayerHitEffect.SetTrigger("hit");
        CHPText.text = CurrentHP.ToString();


        if (CurrentHP <= 0)
        {
            dead();
        }

    }

    
    public void dead()
    {
        Destroy(gameObject);
        Time.timeScale = 0f;
        gameOverMenu.SetActive(true);
        waveManager.enabled = false;
        

    }

}
