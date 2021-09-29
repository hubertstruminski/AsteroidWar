using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private float shootSpeed = 2f;

    [SerializeField]
    private float shootPeriod = 0.25f;

    private float lastShootTime = 0;

    private LaserData data;

    private void Start()
    {
        data = FindObjectOfType<LaserData>();
    }

    private void Update()
    {
        foreach(Touch touch in Input.touches)
        {
            //if(touch.fingerId == 1)
            if (touch.fingerId == 0)
            {
                if (CanShoot())
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

    private bool CanShoot()
    {
        return Time.timeSinceLevelLoad > lastShootTime + shootPeriod;
    }
}
