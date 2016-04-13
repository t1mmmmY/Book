using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class ButtonAnimation : MonoBehaviour 
{
	[SerializeField] Animator animator;

	int pushKey = Animator.StringToHash("push");
	int releaseKey = Animator.StringToHash("release");

	bool click = false;
	System.Action clickCallback;

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	public void Click(System.Action callback)
	{
		if (click)
		{
			return;
		}

		click = true;
		clickCallback = callback;
		animator.SetTrigger(pushKey);
	}

	public void OnPushAnimationDone()
	{
		if (click)
		{
			animator.SetTrigger(releaseKey);
		}
	}

	public void OnReleaseAnimationDone()
	{
		if (click)
		{
			click = false;
			if (clickCallback != null)
			{
				clickCallback();
			}
		}
	}

}
