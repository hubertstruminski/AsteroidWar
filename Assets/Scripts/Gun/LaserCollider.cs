using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "asteroid")
        {
            Asteroid asteroid = collision.gameObject.GetComponent<Asteroid>();
            LaserData data = FindObjectOfType<LaserData>();
            PlayerController playerController = FindObjectOfType<PlayerController>();

            Destroy(gameObject);
            asteroid.HandleDamage(data.GetCurrentWeapon().damage);
            playerController.HandleMoney(30);
        }
    }
}
