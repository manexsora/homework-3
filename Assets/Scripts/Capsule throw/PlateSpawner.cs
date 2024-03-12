using UnityEngine;

public class PlateSpawner : MonoBehaviour
{
    public GameObject platePrefab;
    public Transform[] spawnPoints;
    public float minVelocity = 15f;
    public float maxVelocity = 30f;

    public float spawnRate = 2f;
    private float nextSpawnTime = 0f;

    private bool spawnPlates = false;

    void Update()
    {
        if (Time.time >= nextSpawnTime & spawnPlates)
        {
            SpawnPlate();
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    void SpawnPlate()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject plate = Instantiate(platePrefab, spawnPoint.position, Quaternion.identity);

        Rigidbody rb = plate.GetComponent<Rigidbody>();
        if (rb != null)
        {
            float velocity = Random.Range(minVelocity, maxVelocity);
            rb.velocity = spawnPoint.forward * velocity;
        }
        else
        {
            Debug.LogWarning("Plate prefab does not have a Rigidbody!");
        }
    }

    public void setSpawn(bool spawn)
    {
        spawnPlates = spawn;
    }
}
