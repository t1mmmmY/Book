using UnityEngine;
using System.Collections;

public class PageController : MonoBehaviour 
{
	[SerializeField] MegaBookBuilder book;
	int pageCount = 100;

	[Range(0.0f, 5.0f)] 
	[SerializeField] float flipTime = 2.0f;

	int sliderValue = 0;

	void Start()
	{
		sliderValue = (int)book.page;
		pageCount = book.NumPages;
	}

	void OnGUI()
	{
		GUILayout.Space(100);

		GUILayout.BeginHorizontal();
		{
			sliderValue = Mathf.RoundToInt(GUILayout.HorizontalSlider(sliderValue, -1, pageCount + 1, GUILayout.Width(Screen.width / 3)));
			GUILayout.Label(sliderValue.ToString());
//			sliderValue = System.Convert.ToInt32(GUILayout.TextField(sliderValue.ToString()));

			if (GUILayout.Button("Apply"))
			{
//				StartCoroutine(SetPageNumber(sliderValue));
				book.SetPage(sliderValue, false);
			}

		} GUILayout.EndHorizontal();

		if (GUILayout.Button("Left"))
		{
			book.PrevPage();
			sliderValue = (int)book.page;
		}
		if (GUILayout.Button("Right"))
		{
			book.NextPage();
			sliderValue = (int)book.page;
		}
	}

	IEnumerator SetPageNumber(int nextNumber)
	{
		float oldNumber = book.page;
		float currentNumber = oldNumber;
		float elapsedTime = 0;
		do
		{
			yield return new WaitForEndOfFrame();

			if (flipTime == 0)
			{
				elapsedTime = 1;
			}
			else
			{
				elapsedTime += Time.deltaTime / flipTime;
			}

			currentNumber = Mathf.Lerp(oldNumber, (float)nextNumber, elapsedTime);

			book.SetPage(currentNumber, true);

			
		} while (elapsedTime < 1.0f);
	}

}
