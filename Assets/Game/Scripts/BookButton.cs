using UnityEngine;
using System.Collections;

public enum ActionType
{
	MoveToPage,
	TakeObject
}

[RequireComponent(typeof(BoxCollider))]
public class BookButton : MonoBehaviour, InteractiveObject 
{
	[SerializeField] ActionType actionType;
	[SerializeField] int pageNumber = 0;

	[SerializeField] MeshRenderer buttonRender;
//	[SerializeField] ButtonAnimation buttonAnimation;
	[SerializeField] bool active = true;

	[Range(0.001f, 0.5f)]
	[SerializeField] float animationTime = 0.1f;
	[Range(0, 255)]
	[SerializeField] int targetV = 200;

	Material buttonMaterial;
	bool click = false;

	void Awake()
	{
		Debug.LogWarning("CreateNewMaterial");
//		buttonMaterial = buttonRender.sharedMaterial;
		buttonMaterial = new Material(buttonRender.sharedMaterial);
		buttonRender.material = buttonMaterial;
	}

	public void OnPush()
	{
	}

	public void OnStay()
	{
	}

	public void OnRelease()
	{
		if (click)
		{
			//Animation running
			return;
		}

		Debug.Log("Click button");
		StartCoroutine("ClickAnimation");
//		buttonAnimation.Click(MakeAction);
	}

	IEnumerator ClickAnimation()
	{
		click = true;

		float elapsedTime = 0;
		float h;
		float s;
		float v;
		Color.RGBToHSV(buttonMaterial.color, out h, out s, out v);
		Color newColor = buttonMaterial.color;

		float startValue = v;
		float currentValue = v;
		float endValue = targetV / 255.0f;

		do
		{
			yield return new WaitForEndOfFrame();
			elapsedTime += Time.deltaTime / (animationTime * 2);

			currentValue = Mathf.Lerp(startValue, endValue, elapsedTime);

			newColor = Color.HSVToRGB(h, s, currentValue);
			buttonMaterial.SetColor("_Color", newColor);

		} while (elapsedTime < 1.0f);

		currentValue = endValue;
		elapsedTime = 0;

		do
		{
			yield return new WaitForEndOfFrame();
			elapsedTime += Time.deltaTime / (animationTime * 2);

			currentValue = Mathf.Lerp(endValue, startValue, elapsedTime);

			newColor = Color.HSVToRGB(h, s, currentValue);
			buttonMaterial.SetColor("_Color", newColor);

		} while (elapsedTime < 1.0f);

		click = false;
		MakeAction();
	}

	void MakeAction()
	{
		switch (actionType)
		{
			case ActionType.MoveToPage:
				BookController.Instance.SetPage(pageNumber);
				break;
			case ActionType.TakeObject:
				break;
		}
	}

}
