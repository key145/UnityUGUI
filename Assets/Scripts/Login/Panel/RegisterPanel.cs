using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : BasePanel
{
	public InputField UserName;
	public InputField Password;

	public Button CancelBtn;
	public Button SureBtn;

	public override void Init()
	{
		CancelBtn.onClick.AddListener(() =>
		{
			UIManager.Instance.ShowPanel<LoginPanel>();
			UIManager.Instance.HidePanel<RegisterPanel>(true);
		});

		SureBtn.onClick.AddListener(() =>
		{
			if(UserName.text.Length<=6|| Password.text.Length <= 6)
			{
				UIManager.Instance.ShowPanel<TipPanel>().ChangeInfo("账号密码长度过短");
				return;
			}

			if (LoginManager.Instance.RegisterUser(UserName.text, Password.text))
			{
				LoginPanel loginPanel = UIManager.Instance.ShowPanel<LoginPanel>();
				loginPanel.SetInfo(UserName.text, Password.text);
				UIManager.Instance.HidePanel<RegisterPanel>(true);
			}
			else
			{
				UIManager.Instance.ShowPanel<TipPanel>().ChangeInfo("用户名已存在");
				UserName.text = "";
				Password.text = "";
			}
		});
	}
}
