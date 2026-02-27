using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class ChooseServerPanel : BasePanel
{
	public ScrollRect LeftSv;
	public ScrollRect RightSv;

	public Text FrontServerInfo;
	public Image FrontServerState;

	public Text ServerRange;

	private List<GameObject>BtnList=new List<GameObject>();

	public override void Init()
	{
		List<ServerData> infoList = LoginManager.Instance.ServerData;

		int len = infoList.Count / 5 + 1;
		for(int i=0;i<len; i++)
		{
			GameObject LeftBtn = Instantiate(Resources.Load<GameObject>("UI/ServerLeftItem"));
			LeftBtn.transform.SetParent(LeftSv.content,false);
			int beginIndex = 5 * i + 1;
			int endIndex = 5 * (i + 1);
			if (endIndex > infoList.Count)
			{
				endIndex = infoList.Count;
			}
			LeftBtn.GetComponent<LeftSvBtn>().SetInfo(beginIndex, endIndex);
		}
	}

	public override void ShowMe()
	{
		base.ShowMe();
		if (LoginManager.Instance.LoginData.FrontServerID < 0)
		{
			FrontServerInfo.text = "无";
			FrontServerState.gameObject.SetActive(false);
		}
		else
		{
			ServerData FrontData = LoginManager.Instance.ServerData[LoginManager.Instance.LoginData.FrontServerID-1];
			FrontServerInfo.text = FrontData.id + "区   " + FrontData.name;
			SpriteAtlas sa = Resources.Load<SpriteAtlas>("Login");
			switch (FrontData.state)
			{
				case 1:
					FrontServerState.gameObject.SetActive(true);
					FrontServerState.sprite = sa.GetSprite("ui_DL_huobao_01");
					break;
				case 2:
					FrontServerState.gameObject.SetActive(true);
					FrontServerState.sprite = sa.GetSprite("ui_DL_liuchang_01");
					break;
				case 3:
					FrontServerState.gameObject.SetActive(true);
					FrontServerState.sprite = sa.GetSprite("ui_DL_fanhua_01");
					break;
				case 4:
					FrontServerState.gameObject.SetActive(true);
					FrontServerState.sprite = sa.GetSprite("ui_DL_weihu_01");
					break;
			}
		}
		UpdatePanel(1, 5 > LoginManager.Instance.ServerData.Count ? LoginManager.Instance.ServerData.Count : 5);
	}

	public void UpdatePanel(int beginIndex,int endIndex)
	{
		for (int i = 0; i < BtnList.Count; i++)
		{
			Destroy(BtnList[i].gameObject);
		}
		BtnList.Clear();
		ServerRange.text = "服务器 " + beginIndex + "-" + endIndex;
		for (int i = beginIndex; i <= endIndex; i++) {
			ServerData CurServer = LoginManager.Instance.ServerData[i - 1];
			GameObject serverBtn = Instantiate(Resources.Load<GameObject>("UI/ServerBtn"));
			serverBtn.transform.SetParent(RightSv.content, false);
			serverBtn.GetComponent<ServerChooseBtn>().InitInfo(CurServer);
			BtnList.Add(serverBtn);
		}
	}


}
