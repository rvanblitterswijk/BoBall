using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Beacon : MonoBehaviour
{
    private ParticleSystem ps;

    public float floatTime;
    public Transform floatDestination;

    private const float EMISSIONMULTIPLIER = 4F;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerBall"))
        {
            var rb = other.gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            StartCoroutine(FloatBall(other.gameObject));
        }
    }

    private IEnumerator FloatBall(GameObject playerBall)
    {
        var time = 0f;
        var startposition = playerBall.transform.position;
        IncreasePSEmission();


        while (time <= floatTime)
        {
            playerBall.transform.position = Vector3.Lerp(startposition, floatDestination.position, time / floatTime);

            time += Time.deltaTime;
            yield return null;
        }

        LoadNextScene();
        yield break;
    }

    private void LoadNextScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void ReloadScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    private void IncreasePSEmission()
    {
        var psEmission = ps.emission;
        psEmission.rateOverTime = new ParticleSystem.MinMaxCurve(psEmission.rateOverTime.constantMin * EMISSIONMULTIPLIER, psEmission.rateOverTime.constantMin * EMISSIONMULTIPLIER);
    }
}
