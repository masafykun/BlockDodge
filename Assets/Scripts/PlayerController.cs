using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 8f;
    const float boundary = 4.5f;
    const float hitRadius = 0.6f;
    Rigidbody rb;

    void Start() => rb = GetComponent<Rigidbody>();

    void FixedUpdate()
    {
        if (GameManager.Instance != null && !GameManager.Instance.IsPlaying) return;

        float h = 0f;
        var kb = Keyboard.current;
        if (kb != null)
        {
            if (kb.leftArrowKey.isPressed || kb.aKey.isPressed)       h = -1f;
            else if (kb.rightArrowKey.isPressed || kb.dKey.isPressed) h =  1f;
        }

        var newPos = rb.position;
        newPos.x = Mathf.Clamp(newPos.x + h * speed * Time.fixedDeltaTime, -boundary, boundary);
        rb.MovePosition(newPos);

        foreach (var col in Physics.OverlapSphere(rb.position, hitRadius))
        {
            if (col.gameObject != gameObject && col.GetComponent<FallingBlock>() != null)
            {
                GameManager.Instance?.GameOver();
                return;
            }
        }
    }
}
