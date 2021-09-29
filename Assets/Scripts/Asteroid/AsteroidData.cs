using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AsteroidType
{
    public Sprite sprite;
    public int life;
    public float gravityScale = 0.35f;
}

public class AsteroidData : MonoBehaviour
{
    [SerializeField]
    private AsteroidType[] asteroidTypes;

    private static int currentIndex = 0;
    private static int count = 0;

    private void Start()
    {
        currentIndex = 0;
        count = 0;
    }

    public AsteroidType GetAsteroid()
    {
        count++;
        if (count % 5 == 0)
        {
            if(currentIndex == asteroidTypes.Length - 1)
            {
                currentIndex = 0;
            }
            currentIndex++;
        }

        return asteroidTypes[currentIndex];
    }
}
