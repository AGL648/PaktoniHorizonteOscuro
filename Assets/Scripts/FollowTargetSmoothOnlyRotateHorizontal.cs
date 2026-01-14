using UnityEngine;
using System.Collections;

public class FollowTargetSmoothOnlyRotateHorizontal : MonoBehaviour {


	public Transform target;
	public float smoothPosition = 1F;
	public float SmoothRotation = 1F;

	void Update() {



		transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * smoothPosition );

		Vector2 Temp_Vect2 = new Vector2 (0, Input.GetAxis ("Horizontal"));

		transform.rotation = Quaternion.Lerp (transform.rotation, target.rotation, Time.deltaTime * SmoothRotation * Temp_Vect2.magnitude);


	}
}
