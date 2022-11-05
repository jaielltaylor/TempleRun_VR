using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour
{

	[SerializeField]
	private GameObject[]
		_mummies;

	[SerializeField]
	private GUIStyle
		_style;

	private int counter;
	private GameObject _temp;

	private void Start ()
	{
		_temp = _mummies [0];
	}

	private void Update ()
	{
		
	}

	private void OnGUI ()
	{
		if (GUI.Button (new Rect (Screen.width * 0.5f - 50, 5, 50, 50), "<<")) {
			counter--;
			if (counter < 0)
				counter = _mummies.Length - 1;

			_temp.SetActive (false);
			_mummies [counter].SetActive (true);
			_temp = _mummies [counter];
		}

		if (GUI.Button (new Rect (Screen.width * 0.5f + 50, 5, 50, 50), ">>")) {
			counter++;
			if (counter >= _mummies.Length)
				counter = 0;
			
			_temp.SetActive (false);
			_mummies [counter].SetActive (true);
			_temp = _mummies [counter];
		}


		GUI.Label (new Rect (Screen.width * 0.5f, Screen.height - 50, 300, 50), "Stop camera rotation RMB, zoom MMB", _style);
	}
}
