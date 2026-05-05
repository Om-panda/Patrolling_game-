using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject starPrefab;
    public BoxCollider2D spawnArea;

    void Start()
    {
        SpawnStar(); // create first star
    }

    public void SpawnStar()
    {
        if (starPrefab == null || spawnArea == null)
        {
            Debug.LogError("Assign Star Prefab & Spawn Area!");
            return;
        }

        Bounds bounds = spawnArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        Vector3 spawnPos = new Vector3(x, y, 0f); // 🔥 visible

        GameObject star = Instantiate(starPrefab, spawnPos, Quaternion.identity);

        // assign spawner
        Star s = star.GetComponent<Star>();
        if (s != null)
        {
            s.spawner = this;
        }
    }
}
