using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject pickUpPS;
    public float rotationSpeed;

    private void Update()
    {
        transform.RotateAround(GetComponentInParent<Transform>().position, Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerBall"))
        {
            Instantiate(pickUpPS, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
