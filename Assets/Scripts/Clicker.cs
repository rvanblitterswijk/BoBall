using UnityEngine;
using static UnityEngine.Mathf;

public class Clicker : MonoBehaviour
{
    //References
    public Camera cam;
    public GameObject playerBall;
    public GameObject rippleSystem;
    public ClickTimerUI clickTimerUI;

    //Serialized variables
    [SerializeField]
    private float pushPower, pushCooldown;

    //Private variables
    private int clickCatcherLayermask = 1 << 6;
    private float pushTimer;

    private void Start()
    {
        pushTimer = 0f;
    }

    private void Update()
    {
        pushTimer -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            if (pushTimer <= 0f)
            {
                RaycastHit hit;
                var raycastDir = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(raycastDir, out hit, Infinity, clickCatcherLayermask))
                {
                    PlayRippleEffect(hit.point);
                    PushPlayerBall(hit.point);
                    pushTimer = pushCooldown;
                    clickTimerUI.StartCount(pushCooldown);
                }
            }

        }
    }

    private void PlayRippleEffect(Vector3 position)
    {
        Instantiate(rippleSystem, position, Quaternion.identity);
    }

    private void PushPlayerBall(Vector3 origin)
    {
        var forceDir = (playerBall.transform.position - origin).normalized;
        var forceDistanceModifier = GetForceDistanceModifier(origin);
        var force = forceDir * pushPower * forceDistanceModifier;

        playerBall.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
    }

    private float GetForceDistanceModifier(Vector3 origin)
    {
        var forceDistance = Vector3.Distance(playerBall.transform.position, origin);
        return Clamp(1 / forceDistance, 0f, 1f);
    }
}
