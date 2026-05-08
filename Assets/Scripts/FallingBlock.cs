using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    float speed;
    Rigidbody rb;

    public void Init(float spd)
    {
        speed = spd;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var newPos = rb.position + Vector3.down * speed * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
        if (newPos.y < -3f)
            Destroy(gameObject);
    }
}
