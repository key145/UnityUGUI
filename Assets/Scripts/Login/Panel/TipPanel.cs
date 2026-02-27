using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipPanel : BasePanel
{
	public Text TipText;
	public Button SureBtn;

	public override void Init()
	{
		SureBtn.onClick.AddListener(() =>
		{
			UIManager.Instance.HidePanel<TipPanel>();
		});
	}

	public void ChangeInfo(string tipInfo)
	{
		TipText.text = tipInfo;
	}
}
