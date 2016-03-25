#define BOOK_DEBUG

using UnityEngine;
using System.Collections;

public class BookController : MonoBehaviour 
{
	[SerializeField] MegaBookBuilder book;
	int pageCount = 100;

	[Range(0.0f, 5.0f)] 
	[SerializeField] float flipTime = 2.0f;

	int sliderValue = 0;

	public System.Action onFinishFlip;

	void Start()
	{
		sliderValue = (int)book.page;
		pageCount = book.NumPages;
	}


	public void GoToPage(int pageNumber)
	{
//		book.onFinishFlip += OnFinishFlip;
		book.SetPage(pageNumber, false);

		StartCoroutine(MyInvoke(onFinishFlip, 1.0f));
	}

	public void NextPage()
	{
		book.NextPage();
	}

	public void PrevPage()
	{
		book.PrevPage();
	}


//	void OnFinishFlip()
//	{
//		book.onFinishFlip -= OnFinishFlip;
//
//		if (onFinishFlip != null)
//		{
//			onFinishFlip();
//		}
//	}


#if BOOK_DEBUG

	void OnGUI()
	{
		GUILayout.Space(100);

		GUILayout.BeginHorizontal();
		{
			sliderValue = Mathf.RoundToInt(GUILayout.HorizontalSlider(sliderValue, -1, pageCount + 1, GUILayout.Width(Screen.width / 3)));
			GUILayout.Label(sliderValue.ToString());

			if (GUILayout.Button("Apply"))
			{
				GoToPage(sliderValue);
			}

		} GUILayout.EndHorizontal();

		if (GUILayout.Button("Left"))
		{
			PrevPage();
			sliderValue = (int)book.page;
		}
		if (GUILayout.Button("Right"))
		{
			NextPage();
			sliderValue = (int)book.page;
		}
	}

#endif


	IEnumerator MyInvoke(System.Action callback, float time)
	{
		yield return new WaitForSeconds(time);

		if (callback != null)
		{
			callback();
		}
	}

}
