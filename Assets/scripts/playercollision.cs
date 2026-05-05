using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement; 
    public GameController gameController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("collectable"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("obstacles"))
        {
            movement.enabled = false; 
            gameController.GameOver();
            Debug.Log("Game Over!");// disable player movement
        }
    }
}
