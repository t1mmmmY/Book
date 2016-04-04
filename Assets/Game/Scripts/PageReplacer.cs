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
			InteractivePage page = go.GetComponent<InteractivePage>();
			if (page != null)
			{
				page.DestroyPage();
			}
//			Destroy(go);
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

		List<InteractivePage> createdPages = new List<InteractivePage>();
		//Create and assign new pages
		foreach (InteractivePage page in textPart.pages)
		{
			InteractivePage iPage = GameObject.Instantiate<InteractivePage>(page);
			createdPages.Add(iPage);

			pageBuilder.pages.Add(iPage.gameObject);
		}


		Debug.Log(pageNumber.ToString());

		currentPageNumbers = new List<int>();


		//Attach buttons to bage
		for (int i = 0; i < pageBuilder.pages.Count; i++)
		{
//			book.pageparams[i].objects = new List<MegaBookPageObject>();
//			int pageparamsNumber = i / 2;

			AttachedObject[] attachments = createdPages[i].GetAttachedObjects();
			if (attachments.Length > 0)
			{
//				int pageparamsNumber = i;
				int pageparamsNumber = i / 2;
				Debug.Log("page number = " + pageparamsNumber.ToString());


				foreach (AttachedObject attachment in attachments)
				{
					//Detach from page
					attachment.gameObject.transform.parent = attachment.gameObject.transform.parent.parent;

					MegaBookPageObject pageObj = new MegaBookPageObject();
					pageObj.AddAttachment(attachment);

//					book.pageparams[pageparamsNumber].pageobj = attachment.gameObject;
					book.AttachObject(book.pages[pageparamsNumber], pageObj);
//					book.pageparams[pageparamsNumber].objects.Add(pageObj);
				}
			}

		}

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
