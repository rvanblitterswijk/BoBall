using UnityEngine;

public class PlayerBallMovementEmission : MonoBehaviour
{
    public GameObject playerBall;
    public float triggerSpeed;

    private Rigidbody rb;
    private ParticleSystem ps;
    private bool isEmitting;

    private void Start()
    {
        rb = playerBall.GetComponent<Rigidbody>();
        ps = GetComponent<ParticleSystem>();
        isEmitting = false;
    }

    private void Update()
    {
        UpdatePosition();
        UpdateRotation();
        HandleEmissionTriggers();
    }

    public void StopEmitting()
    {
        ps.Stop();
    }

    private void HandleEmissionTriggers()
    {
        if (isEmitting)
        {
            if (rb.velocity.magnitude < triggerSpeed)
            {
                ps.Stop();
                isEmitting = false;
            }
        }
        else
        {
            if (rb.velocity.magnitude > triggerSpeed)
            {
                ps.Play();
                isEmitting = true;
            }
        }
    }

    private void UpdateRotation()
    {
        transform.LookAt(-rb.velocity);
    }

    private void UpdatePosition()
    {
        transform.position = playerBall.transform.position;
    }
}
