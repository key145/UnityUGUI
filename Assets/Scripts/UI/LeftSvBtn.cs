using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftSvBtn : MonoBehaviour
{
    private Button SelfBtn;

	public Text TextInfo;

	private int BeginIndex;
	private int EndIndex;

	private void Awake()
	{
		SelfBtn = GetComponent<Button>();
	}

	// Start is called before the first frame update
	void Start()
    {
		SelfBtn.onClick.AddListener(() =>
		{
			UIManager.Instance.GetPanel<ChooseServerPanel>().UpdatePanel(BeginIndex, EndIndex);
		});

	}
	
	public void SetInfo(int begin,int end)
	{
		BeginIndex = begin;
		EndIndex = end;

		TextInfo.text = begin + " - " + end + "Çø";
	}
}
