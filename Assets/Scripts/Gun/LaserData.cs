using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunCount { SINGLE = 0, DOUBLE = 1 }

[System.Serializable]
public class GunType
{
    public Sprite sprite;
    public int damage;
    public GunCount gunCount = GunCount.SINGLE;
}

public class LaserData : MonoBehaviour
{
    [SerializeField]
    private GunType[] gunTypes;
    public GunType[] GunTypes { get { return gunTypes; } }

    public int CurrentIndexLevel = 0;

    private void Start()
    {
        CurrentIndexLevel = 0;
    }

    public int GetGunTypesCount() => gunTypes.Length;

    public GunType GetCurrentWeapon() => gunTypes[CurrentIndexLevel];

    public void ChangeLaserLevel()
    {
        if (CurrentIndexLevel == gunTypes.Length - 1) return;
        CurrentIndexLevel++;
    }

    public void IncreaseLaserLevel()
    {
        PlayerController playerController = FindObjectOfType<PlayerController>();

        if (playerController.MoneyAmount < 100 || CurrentIndexLevel == GetGunTypesCount() - 1) return;

        playerController.HandleMoney(-100);
        ChangeLaserLevel();
    }
}
