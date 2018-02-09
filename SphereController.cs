using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SphereController : MonoBehaviour {
	public float moduloVelocidad = 30.0f;
	public float angulo = 90.0f;
	private float Rangulo;
	private float yValue;
	private float xValue;
	private float t = 0.0f;
	bool empezar = false;

	void Update () 
	{
		if (Input.GetKey("w")) { //Sube angulo
			if(empezar ==false)
			angulo += 0.5f;
		}
		if (Input.GetKey("s")) { //Baja angulo
			if(empezar ==false)
			angulo -= 0.5f;
		}
		if (Input.GetKey("a")) { //Baja Velocidad
			if(empezar ==false)
			moduloVelocidad -= 0.5f;
		}
		if (Input.GetKey("d")) { //Sube Velocidad
			if(empezar ==false)
			moduloVelocidad += 0.5f;
		}
		if (Input.GetKey("space")) { //Dispara
			empezar = true;
		}
		if (Input.GetKey("escape")) { //Dispara
			Application.Quit();
		}


		Rangulo = angulo * (Mathf.PI / 180); //Pasamos Angulos a radianes

		if (empezar == true) { //Si podemos empezar, realizamos el movimiento parabolico
			xValue = moduloVelocidad * Mathf.Cos (Rangulo) * t; //Posicion X
			yValue = moduloVelocidad * t - 0.5f * 9.8f * Mathf.Pow (t, 2); //Posicion Y
			transform.position = new Vector3 (xValue, yValue, transform.position.z); //Aplicamos posicion
			t += 0.1f; //Aumentamos tiempo
		}
		if (yValue <= -23) { //Si esta a nivel de suelo, empezamos
			empezar = false;
			transform.position = new Vector3 (0, 0, 0);
			t = 0;
		}
		
		//Mandamos valores a la interfaz
		UIManager.Velocidad = moduloVelocidad;
		UIManager.Angulo = angulo;


	}
}