using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	[SerializeField]
	private Transform
		target;

	[SerializeField]
	private int
		speedX = 5, speedY = 3, zoomRate = 2;

	[SerializeField]
	private float
		maxViewDistance = 1.0f, minViewDistance = 25.0f, offset;

	private float x = 0.0f, y = 0.0f, distance, disereDistance, corectDistance;
	private bool canRotate = true;

	private void Start ()
	{

	}

	private void LateUpdate ()
	{

		if (canRotate) {
			x += Input.GetAxis ("Mouse X") * speedX;
			y -= Input.GetAxis ("Mouse Y") * speedY;

			y = ClampAngle (y, -10, 90);
			//x = ClampAngle (x, 180, 350);

			Quaternion rotation = Quaternion.Euler (y, x, 0);

			disereDistance -= Input.GetAxis ("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs (disereDistance);
			disereDistance = Mathf.Clamp (disereDistance, minViewDistance, maxViewDistance);
			corectDistance = disereDistance;

			Vector3 position = target.position - (rotation * Vector3.forward * corectDistance);


			transform.rotation = rotation;
			transform.position = new Vector3 (position.x, position.y + offset, position.z);
		}

		if (Input.GetMouseButtonDown (1))
			canRotate = !canRotate;
	}

	private float ClampAngle (float angle, float min, float max)
	{
		if (angle < -360) {
			angle += 360;
		}

		if (angle > 360) {
			angle -= 360;
		}

		return Mathf.Clamp (angle, min, max);
	}
}
