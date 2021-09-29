using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    [SerializeField]
    public GameObject asteroidPrefab;

    void Start()
    {
        StartCoroutine(GenerateAsteroids());
    }

    IEnumerator GenerateAsteroids()
    {
        while(true)
        {
            StartCoroutine(GenerateWave());
            yield return new WaitForSecondsRealtime(5f);
        }
    }

    private Vector3 GenerateRandomPosition()
    {
        float x = Random.Range(0f, 1f);
        x = Mathf.Clamp(x, 0.1f, 0.9f);
        Vector3 viewportPosition = new Vector3(x, 1.5f);

        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewportPosition);
        worldPos.z = 10f;

        return worldPos;
    }

    private IEnumerator GenerateWave()
    {
        Vector3 worldPosition = GenerateRandomPosition();
        Instantiate(asteroidPrefab, worldPosition, Quaternion.identity);

        yield return new WaitForSecondsRealtime(3.5f);
    }
}
