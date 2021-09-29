using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LaserController : MonoBehaviour
{
    [SerializeField]
    private GameObject laserPrefab;

    [SerializeField]
    private Transform leftGunPoint;

    [SerializeField]
    private Transform rightGunPoint;

    [SerializeField]
    private Transform middleGunPoint;

    [SerializeField]
    private float shootPeriod = 0.25f;

    private float lastShootTime = 0;

    private LaserData data;
    private Button[] gameButtons;

    private void Start()
    {
        data = FindObjectOfType<LaserData>();
        gameButtons = FindObjectsOfType<Button>();
    }

    private void Update()
    {
        foreach(Touch touch in Input.touches)
        {
            //if(touch.fingerId == 1)
            if (touch.fingerId == 0)
            {
                if (CanShoot() && !CheckIfUIButtonIsClicked())
                {
                    SpawnWeapon();
                }
            }
        }
    }

    public void SpawnWeapon()
    {
        if(data.GunTypes[data.CurrentIndexLevel].gunCount == GunCount.SINGLE)
            SpawnSingleWeapon();
        else
            SpawnDoubleWeapon();
    }

    private void SpawnSingleWeapon()
    {
        GameObject laser = Instantiate(laserPrefab, middleGunPoint.position, Quaternion.identity);
        laser.GetComponent<Laser>().SetConfiguration();

        lastShootTime = Time.timeSinceLevelLoad;
    }

    private void SpawnDoubleWeapon()
    {
        GameObject laser1 = Instantiate(laserPrefab, leftGunPoint.position, Quaternion.identity);
        laser1.GetComponent<Laser>().SetConfiguration();

        GameObject laser2 = Instantiate(laserPrefab, rightGunPoint.position, Quaternion.identity);
        laser2.GetComponent<Laser>().SetConfiguration();

        lastShootTime = Time.timeSinceLevelLoad;
    }

    private bool CheckIfUIButtonIsClicked()
    {
        GameObject go = EventSystem.current.currentSelectedGameObject;

        if (go != null)
        {
            foreach (Button button in gameButtons)
            {
                if (button.name == go.name)
                    return true;
            }
        }
        return false;
    }

    private bool CanShoot()
    {
        return Time.timeSinceLevelLoad > lastShootTime + shootPeriod;
    }
}
