using UnityEngine;
using System.Collections;

public class Sword_Shield : BaseAnimController
{
	[SerializeField]
	private string
		_atack_1, _atack_2, _threaten, _gd_1;

	protected override void BaseButtons ()
	{
		base.BaseButtons ();

		if (GUI.Button (new Rect (10, 130, 100, 50), "Atack_1")) {
			_anim.SetTrigger (_atack_1);
		}

		if (GUI.Button (new Rect (10, 180, 100, 50), "Atack_2")) {
			_anim.SetTrigger (_atack_2);
		}

		if (GUI.Button (new Rect (10, 250, 100, 50), "Threaten")) {
			_anim.SetTrigger (_threaten);
		}

		if (GUI.Button (new Rect (10, 430, 100, 50), "GetDamage_1")) {
			_anim.SetTrigger (_gd_1);
		}
	}

}
