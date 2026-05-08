using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    float elapsed;
    float timer;

    void Update()
    {
        if (GameManager.Instance != null && !GameManager.Instance.IsPlaying) return;
        elapsed += Time.deltaTime;
        timer   += Time.deltaTime;

        float interval = Mathf.Max(0.25f, 1.2f - elapsed * 0.02f);
        if (timer >= interval)
        {
            timer = 0f;
            Spawn();
        }
    }

    void Spawn()
    {
        var block = GameObject.CreatePrimitive(PrimitiveType.Cube);
        float x = Random.Range(-4.5f, 4.5f);
        block.transform.position = new Vector3(x, 12f, 0f);

        float s = Random.Range(0.5f, 1.5f);
        block.transform.localScale = Vector3.one * s;

        var mat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        mat.SetColor("_BaseColor", Random.ColorHSV(0f, 1f, 0.8f, 1f, 0.8f, 1f));
        block.GetComponent<MeshRenderer>().sharedMaterial = mat;

        var rb = block.AddComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;

        float speed = Mathf.Min(18f, 5f + elapsed * 0.3f);
        block.AddComponent<FallingBlock>().Init(speed);
        Destroy(block, 10f);
    }

    public void ResetSpawner() { elapsed = 0f; timer = 0f; }
}
