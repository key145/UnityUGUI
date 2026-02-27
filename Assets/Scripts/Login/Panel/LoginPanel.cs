using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{
	public InputField UserName;
	public InputField Password;

	public Button RegisterBtn;
	public Button SureBtn;

	public Toggle RemPassword;
	public Toggle AutoLogin;

	public override void Init()
	{
		RegisterBtn.onClick.AddListener(() =>
		{
			UIManager.Instance.ShowPanel<RegisterPanel>();

			UIManager.Instance.HidePanel<LoginPanel>(true);
		});

		SureBtn.onClick.AddListener(() =>
		{
			if (UserName.text.Length <= 6 || Password.text.Length <= 6)
			{
				UIManager.Instance.ShowPanel<TipPanel>().ChangeInfo("’À∫≈ªÚ√‹¬Î≥§∂»π˝∂Ã");
				return;
			}

			if (LoginManager.Instance.CheckUser(UserName.text, Password.text))
			{
				LoginManager.Instance.LoginData.UserName = UserName.text;
				LoginManager.Instance.LoginData.Password = Password.text;
				LoginManager.Instance.LoginData.RemPassword = RemPassword.isOn;
				LoginManager.Instance.LoginData.AutoLogin = AutoLogin.isOn;
				LoginManager.Instance.SaveLoginData();

				if (LoginManager.Instance.LoginData.FrontServerID != -1)
				{
					UIManager.Instance.ShowPanel<ServerPanel>();
				}
				else
				{
					UIManager.Instance.ShowPanel<ChooseServerPanel>();
				}

				UIManager.Instance.HidePanel<LoginPanel>(true);
			}
			else
			{
				UIManager.Instance.ShowPanel<TipPanel>().ChangeInfo("’À∫≈ªÚ√‹¬Î¥ÌŒÛ");
			}
		});

		RemPassword.onValueChanged.AddListener((isOn) =>
		{
			if (!isOn)
			{
				AutoLogin.isOn = false;
			}
		});

		AutoLogin.onValueChanged.AddListener((isOn) =>
		{
			if (isOn)
			{
				RemPassword.isOn = true;
			}
		});

	}

	public override void ShowMe()
	{
		base.ShowMe();
		LoginData loginData = LoginManager.Instance.LoginData;
		UserName.text = loginData.UserName;
		RemPassword.isOn = loginData.RemPassword;
		AutoLogin.isOn = loginData.AutoLogin;
		if (loginData.RemPassword)
			Password.text = loginData.Password;
		if (loginData.AutoLogin)
		{
			if (LoginManager.Instance.CheckUser(UserName.text, Password.text))
			{
				if (LoginManager.Instance.LoginData.FrontServerID != -1)
				{
					UIManager.Instance.ShowPanel<ServerPanel>();
				}
				else
				{
					UIManager.Instance.ShowPanel<ChooseServerPanel>();
				}
				UIManager.Instance.HidePanel<LoginPanel>(false);
			}
		}
	}

	public void SetInfo(string userName,string password)
	{
		UserName.text = userName;
		Password.text = password;
	}
}
