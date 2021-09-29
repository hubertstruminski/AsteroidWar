using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldData : MonoBehaviour
{
    [SerializeField]
    private Sprite[] shieldTypes;

    public int CurrentIndexLevel = 0;

    private void Start()
    {
        CurrentIndexLevel = 0;
    }

    public int GetShieldTypesCount() => shieldTypes.Length;

    public Sprite GetCurrentShield() => shieldTypes[CurrentIndexLevel];

    public void ChangeShieldLevel()
    {
        if (CurrentIndexLevel == shieldTypes.Length - 1) return;
        CurrentIndexLevel++;
    }

    public void IncreaseLaserLevel()
    {
        int cost = 150;
        PlayerController playerController = FindObjectOfType<PlayerController>();

        if (playerController.MoneyAmount < cost || CurrentIndexLevel == GetShieldTypesCount() - 1) return;

        playerController.HandleMoney(-cost);
        ChangeShieldLevel();
    }
}
