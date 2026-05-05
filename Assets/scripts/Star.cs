using UnityEngine;

public class Star : MonoBehaviour
{
    public StarSpawner spawner;
    private Score score;

    [System.Obsolete]
    void Start()
    {
        score = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (score != null)
            {
                score.AddScore(); // 🔥 increase score
            }

            if (spawner != null)
            {
                spawner.SpawnStar();
            }

            Destroy(gameObject);
        }
    }
}
