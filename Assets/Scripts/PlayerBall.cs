using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    public GameObject deathPS;
    public float deathTime;
    public CheckpointSave checkpointSave;

    private void Start()
    {
        if (checkpointSave.checkpointIsSet)
        {
            GetComponentInParent<Transform>().position = checkpointSave.checkpoint;
        }
    }

    private void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Spike"))
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Spike"))
        {
            Die();
        }
    }

    public void Die()
    {
        Instantiate(deathPS, transform.position, Quaternion.identity);
        FindObjectOfType<Beacon>().PlayerDied(deathTime);
        FindObjectOfType<PlayerBallMovementEmission>().StopEmitting();
        Destroy(FindObjectOfType<PlayerBallMovementEmission>());
        Destroy(gameObject);
    }
}
