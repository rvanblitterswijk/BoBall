using System.Collections;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    public Transform[] waypoints;
    public float movementSpeed;
    public float waitTime;

    private Transform target;

    private int pointIndex;


    void Start()
    {
        pointIndex = 0;

        SetNextTarget();
    }

    void Update()
    {
        if (target != null)
        {
            MoveTowardTarget();

            if (Vector3.Distance(transform.position, target.position) <= 0.01f)
            {
                StartCoroutine(TargetReached());
            }
        }

    }

    private IEnumerator TargetReached()
    {
        var timer = 0f;
        target = null;

        while (timer < waitTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        SetNextTarget();
        yield break;
    }

    void SetNextTarget()
    {
        if (waypoints.Length == 0)
        {
            return;
        }

        pointIndex++;
        if (pointIndex >= waypoints.Length)
        {
            pointIndex = 0;
        }

        target = waypoints[pointIndex];
    }

    private void MoveTowardTarget()
    {
        //Getting direction
        var direction = target.position - transform.position;
        direction.Normalize();

        //Movement
        var movementVector = direction * movementSpeed * Time.deltaTime;
        transform.Translate(movementVector);
    }
}
