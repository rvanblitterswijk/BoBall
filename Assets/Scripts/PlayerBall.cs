using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    public GameObject deathPS;
    public float deathTime;

    private void Start()
    {

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

    public void Die()
    {
        Instantiate(deathPS, transform.position, Quaternion.identity);
        FindObjectOfType<Beacon>().PlayerDied(deathTime);
        Destroy(gameObject);
    }
}
