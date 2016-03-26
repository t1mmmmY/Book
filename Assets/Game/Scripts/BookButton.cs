using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class BookButton : MonoBehaviour 
{
	[SerializeField] MeshRenderer buttonRender;
	[SerializeField] bool active = true;

	Material buttonMaterial;

	void Start()
	{
		buttonMaterial = new Material(buttonRender.sharedMaterial);
		buttonRender.material = buttonMaterial;
	}

	void OnClick()
	{
		Debug.Log("Click button");
	}
}
