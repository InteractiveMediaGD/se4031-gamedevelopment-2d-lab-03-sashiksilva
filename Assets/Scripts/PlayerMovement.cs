using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private float timer = 0f;

    void Update()
    {
        // 1. Increment the timer every frame
        timer += Time.deltaTime;

        // 2. Get input from keyboard (WASD or Arrow Keys)
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(x, y);

        // 3. Calculate speed (it increases by 0.3 every second)
        float currentSpeed = speed + timer * 0.3f;

        // 4. Move the player
        transform.Translate(move * currentSpeed * Time.deltaTime);
    }
}