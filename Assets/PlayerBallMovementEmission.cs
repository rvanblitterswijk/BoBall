using UnityEngine;

public class PlayerBallMovementEmission : MonoBehaviour
{
    public ParticleSystem ps;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ps.transform.LookAt(-rb.velocity);
    }
}
