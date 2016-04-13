using UnityEngine;
using System.Collections;

public class SceneRaycaster : BaseSingleton<SceneRaycaster> 
{
	[SerializeField] Camera mainCamera;

	void Update()
	{
		//On Push
		if (Input.GetMouseButtonDown(0))
		{
			InteractiveObject interactiveObject = Click();
			if (interactiveObject != null)
			{
				interactiveObject.OnPush();
			}
		}

		//On Release
		if (Input.GetMouseButtonUp(0))
		{
			InteractiveObject interactiveObject = Click();
			if (interactiveObject != null)
			{
				interactiveObject.OnRelease();
			}
		}
	}

	public InteractiveObject Click()
	{
		Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, LayerMask.GetMask("Interactive")))
		{
			InteractiveObject interactiveObject = hit.collider.GetComponent<InteractiveObject>();
			if (interactiveObject != null)
			{
				return interactiveObject;
			}
		}

		return null;
	}

}
