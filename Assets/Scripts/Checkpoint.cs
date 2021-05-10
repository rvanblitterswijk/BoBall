using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public CheckpointSave checkpointSave;

    [SerializeField]
    private float rotationSpeed;

    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        transform.RotateAround(GetComponentInParent<Transform>().position, Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        SetCheckpoint();
    }

    private void SetCheckpoint()
    {
        renderer.material.color = Color.green;
        checkpointSave.checkpoint = transform.position;
        checkpointSave.checkpointIsSet = true;
    }
}
