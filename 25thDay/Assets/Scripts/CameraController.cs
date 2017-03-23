using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject target;
	public float followAhead;
	private Vector3 targetPosition;
	public float smoothing;

    public bool followTarget;

    private Vector3 screenShakeActive;
    private float screenShakeAmount;
    public float screenShakeDecay;

	// Use this for initialization
	void Start () {
        followTarget = true;

	}

    // Update is called once per frame
    void Update() {

        if (followTarget)
        {
            targetPosition = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);

            if (target.transform.localScale.x > 0f)
            {
                targetPosition = new Vector3(targetPosition.x + followAhead, targetPosition.y, targetPosition.z);
            }
            else
            {
                targetPosition = new Vector3(targetPosition.x - followAhead, targetPosition.y, targetPosition.z);
            }

            //transform.position = targetPosition;

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);

        }

        if (screenShakeAmount > 0)
        {
            screenShakeActive = new Vector3(Random.Range(-screenShakeAmount, screenShakeAmount), Random.Range(-screenShakeAmount, screenShakeAmount), 0f);
            screenShakeAmount -= Time.deltaTime * screenShakeDecay;
        } else {
            screenShakeActive = Vector3.zero;
        }

        transform.position += screenShakeActive;
    }

    public void ScreenShake(float toShake)
    {
        screenShakeAmount = toShake;
    }
}
