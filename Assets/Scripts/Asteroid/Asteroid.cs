using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private AsteroidType asteroidType;

    public AsteroidType GetAsteroidType()
    {
        return asteroidType;
    }

    public void HandleDamage(int value)
    {
        if(asteroidType.life <= 0)
        {
            Destroy(gameObject);
            return;
        }
        asteroidType.life -= value;
    }

    private void Start()
    {
        asteroidType = FindObjectOfType<AsteroidData>().GetAsteroid();
        SetConfiguration();
    }

    private void Update()
    {
        ManageLifeCycle();
    }

    private void SetConfiguration()
    {
        GetComponent<SpriteRenderer>().sprite = asteroidType.sprite;
        GetComponent<Rigidbody2D>().gravityScale = asteroidType.gravityScale;
        
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
