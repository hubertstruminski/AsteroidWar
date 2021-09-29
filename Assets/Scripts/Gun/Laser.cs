using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LaserData data;

    private void Awake()
    {
        data = FindObjectOfType<LaserData>();
    }

    private void Update()
    {
        ManageLaserLifeCycle();
    }

    public void SetConfiguration()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0;
        rigidbody.velocity = Vector2.up * 5f;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = data.GetCurrentWeapon().sprite;
    }

    private void ManageLaserLifeCycle()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (viewportPosition.y > 1f)
            Destroy(gameObject);
    }
}
