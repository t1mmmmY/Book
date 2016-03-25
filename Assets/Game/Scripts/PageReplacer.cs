using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PageReplacer : MonoBehaviour 
{
	[SerializeField] MegaBookBuilder book;
	[SerializeField] MBComplexPage pageBuilder;
	[SerializeField] BookController bookController;
	[SerializeField] TextMaster textMaster;

	List<int> toDelPageNumbers;
	List<int> oldPageNumbers;
	List<int> currentPageNumbers;

	float scaler = 0.05f;
	int[] pageNumbers;

	void Start()
	{
		toDelPageNumbers = new List<int>();
		oldPageNumbers = new List<int>();
		currentPageNumbers = new List<int>();
		pageNumbers = textMaster.GetAllPageNumbers();

		int numPages = book.NumPages;
		scaler = numPages / 1000.0f;
	}

	public void CreateNewText(int pageNumber, int textNumber)
	{
		TextPart textPart = textMaster.GetTextPart(textNumber);

		//Delete old pages
		List<GameObject> pages = pageBuilder.pages;
		foreach (GameObject go in pages)
		{
			Destroy(go);
		}
		pageBuilder.pages = new List<GameObject>();


		oldPageNumbers = new List<int>();
		foreach (int page in currentPageNumbers)
		{
			oldPageNumbers.Add(page);
		}

		toDelPageNumbers = new List<int>();
		foreach (int page in oldPageNumbers)
		{
			toDelPageNumbers.Add(page);
		}

//		oldPageNumbers = new List<int>();
//		foreach (int page in currentPageNumbers)
//		{
//			oldPageNumbers.Add(page);
//		}

		//Create and assign new pages
		foreach (GameObject page in textPart.pages)
		{
			GameObject go = GameObject.Instantiate<GameObject>(page);
			pageBuilder.pages.Add(go);
		}


		Debug.Log(pageNumber.ToString());

		currentPageNumbers = new List<int>();

		for (int i = 0; i < pageBuilder.pages.Count; i++)
		{
			book.AttachDynamicObjectToPage(book.pages[pageNumber + i], i);
			currentPageNumbers.Add(pageNumber + i);
		}

	}

	public void DeleteOldText()
	{
		foreach (int number in toDelPageNumbers)
		{
			Debug.Log("Clear page " + number + " with page number " + (book.pageparams.Count - 1).ToString());
			book.AttachDynamicObjectToPage(book.pages[number], book.pageparams.Count - 1);
		}
	}


	int GetPageNumber(int textNumber)
	{
		return Mathf.RoundToInt(textNumber * scaler);
	}

	void OnGUI()
	{
		GUILayout.BeginHorizontal();
		{
			foreach (int number in pageNumbers)
			{
				if (GUILayout.Button(number.ToString()))
				{
					DeleteOldText();
					CreateNewText(GetPageNumber(number), number);

//					bookController.onFinishFlip += OnFinishFlip;
					bookController.GoToPage(GetPageNumber(number));

				}
			}

//			for (int i = 0; i < pageNumbers.Length; i++)
//			{
//				if (GUILayout.Button(pageNumbers[i].ToString()))
//				{
//					CreateNewText(GetPageNumber(pageNumbers[i]), pageNumbers[i]);
//
//					bookController.GoToPage(GetPageNumber(pageNumbers[i]), () =>
//					{
//						DeleteOldText();
//					});
//
//				}
//			}

		} GUILayout.EndHorizontal();
	}


//	void OnFinishFlip()
//	{
//		bookController.onFinishFlip -= OnFinishFlip;
//		DeleteOldText();
//		Debug.Log("Done");
//	}

}
