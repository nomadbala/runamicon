using UnityEngine;

public class Sword : MonoBehaviour
{
	public int _damage = 25;

	private void OnTriggerEnter(Collider other)
	{
		// if (other.gameObject.GetComponent<PlayerController>() is null)
		// {

		// 	if (other.gameObject.tag == "Cube")
		// 	{
		// 		Debug.Log("Sword Enter");

		// 		if (other.gameObject.GetComponent<Cube>().getColor() == Color.magenta)
		// 		{

		// 			other.gameObject.GetComponent<Cube>().SetMaterial(Color.white);
		// 		}
		// 		else
		// 		{

		// 			other.gameObject.GetComponent<Cube>().SetMaterial(Color.magenta);
		// 		}

		// 	}
		// }

		if (other.tag != "Mob")
		{
			return;
		}

		var mobStateMachine = other.GetComponent<MobStateMachine>();

		mobStateMachine.GetComponent<MobHealth>().TakeDamage(_damage);
		mobStateMachine.Animator.Play("hit");
#if (UNITY_EDITOR)
		Debug.Log(_damage);
#endif

		// Debug.Log(mobStateMachine is null);
	}

}
