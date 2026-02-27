using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ServerPanel : BasePanel
{
	public Text ServerInfo;

	public Button ChooseBtn;
	public Button StartBtn;
	public Button BackBtn;

	public override void Init()
	{
		StartBtn.onClick.AddListener(() =>
		{
			SceneManager.LoadScene("GameScene");

			LoginManager.Instance.SaveLoginData();

			UIManager.Instance.HidePanel<ServerPanel>();
		});

		BackBtn.onClick.AddListener(() =>
		{
			UIManager.Instance.HidePanel<ServerPanel>();

			if (LoginManager.Instance.LoginData.AutoLogin)
			{
				LoginManager.Instance.LoginData.AutoLogin = false;
			}

			UIManager.Instance.ShowPanel<LoginPanel>();
		});

		ChooseBtn.onClick.AddListener(() =>
		{
			UIManager.Instance.ShowPanel<ChooseServerPanel>();

			UIManager.Instance.HidePanel<ServerPanel>();
		});
	}

	public override void ShowMe()
	{
		base.ShowMe();
		if (LoginManager.Instance.LoginData.FrontServerID > -1)
		{
			ServerData frontServer = LoginManager.Instance.ServerData[LoginManager.Instance.LoginData.FrontServerID - 1];
			ServerInfo.text = frontServer.id + "Çø  " + frontServer.name;
		}
	}
}
