using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private AsteroidType asteroidType;

    private void Start()
    {
        asteroidType = FindObjectOfType<AsteroidData>().GetAsteroid();
        SetConfiguration();
    }

    private void Update()
    {
        ManageLifeCycle();
    }

    public AsteroidType GetAsteroidType()
    {
        return asteroidType;
    }

    public void HandleDamage(int value)
    {
        if (asteroidType.life <= 0)
        {
            Destroy(gameObject);
            return;
        }
        asteroidType.life -= value;
    }

    private void SetConfiguration()
    {
        GetComponent<SpriteRenderer>().sprite = asteroidType.sprite;
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = 0;
        rigidbody2D.velocity = Vector2.down * asteroidType.velocity;
        
        BoxCollider2D boxCollider = gameObject.AddComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
    }

    private void ManageLifeCycle()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (viewportPosition.y < 0)
            Destroy(gameObject);
    }
}
