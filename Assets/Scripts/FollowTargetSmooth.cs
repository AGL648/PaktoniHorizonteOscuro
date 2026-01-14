using UnityEngine;
using System.Collections;

public class FollowTargetSmooth : MonoBehaviour {


	public Transform target;
	public float smoothPosition = 1F;
	public float SmoothRotation = 1F;

	void Update() {



		transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * smoothPosition );
		transform.rotation = Quaternion.Lerp (transform.rotation, target.rotation, Time.deltaTime  * SmoothRotation);

	}
}
