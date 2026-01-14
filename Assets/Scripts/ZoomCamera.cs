using UnityEngine;
using System.Collections;

public class ZoomCamera : MonoBehaviour {
	
	public Transform pos_MaxCamara;//el pivote que representa la posicion Max
	public Transform pos_Camara; //la camara en si
	public LayerMask layerPared; // La capa PARED, para que choque el ray
	public float zoomSpeed = 10;// Velocidad del zoom

	public Transform pos_ApuntarCamara; //Esta es la posicion de la camara cuando apuntas
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
			// hacemos una variable float para saber la distancia que hay desde el pivote hasta la camara
			float disMax = Vector3.Distance (transform.position, pos_MaxCamara.position);
			//ahora necesito la direccion
			Vector3 raycastDir = pos_MaxCamara.position - transform.position;
			//Declaro el hit y el ray cast
			RaycastHit hit;
			//el raycast dispara mi posicion, la direccion, salida, en una distancia, en la layer pared
			if (Physics.Raycast (transform.position, raycastDir, out hit, disMax, layerPared)) {
				//Si el raycast choca contra una pared, la posicion de la camara sera la posicion donde el ray ha chocado
				pos_Camara.position = Vector3.Lerp (pos_Camara.position, hit.point, Time.deltaTime * zoomSpeed);


			} else {
				//Si no, la camara irá a su posicion maxima;
				pos_Camara.position = Vector3.Lerp (pos_Camara.position, pos_MaxCamara.position, Time.deltaTime * zoomSpeed);

			}

		




	}
}
