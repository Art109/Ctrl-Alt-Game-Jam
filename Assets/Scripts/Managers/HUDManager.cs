using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField] Slider sldHealthPlayer;

    private void OnEnable()
    {
        PlayerHealth.OnPlayerHurth+= UpdateHealthBar;
    }

    private void Start()
    {
        sldHealthPlayer.maxValue = PlayerData.MaxHealth;
    }

    void UpdateHealthBar(int playerHealth){
        sldHealthPlayer.value = (playerHealth > 0)
        ? playerHealth
        : 0;
    }

    void OnDisable()
    {
        PlayerHealth.OnPlayerHurth-= UpdateHealthBar;
    }

}
