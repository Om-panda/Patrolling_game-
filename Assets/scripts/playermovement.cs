using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Animator animator;

    // 🎮 Assign this from Inspector
    public FixedJoystick joystick;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        // 🔥 JOYSTICK INPUT (if assigned)
        if (joystick != null)
        {
            moveX = joystick.Horizontal;
            moveY = joystick.Vertical;
        }

        // 🔥 KEYBOARD INPUT (works if no joystick or adds extra control)
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;
        if (Input.GetKey(KeyCode.W)) moveY = 1f;
        if (Input.GetKey(KeyCode.S)) moveY = -1f;

        Vector2 movement = new Vector2(moveX, moveY).normalized;

        // Move player
        transform.Translate(movement * speed * Time.deltaTime);

        // Animation
        if (movement != Vector2.zero)
        {
            animator.SetBool("isrunning", true);
        }
        else
        {
            animator.SetBool("isrunning", false);
        }
    }
}
