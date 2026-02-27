using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class LoginManager
{
	private static LoginManager instance = new LoginManager();

	public static LoginManager Instance => instance;

	private LoginData loginData;

	public LoginData LoginData => loginData;

	private RegisterData registerData;

	public RegisterData RegisterData => registerData;

	private List<ServerData> serverData;

	public List<ServerData> ServerData => serverData;

	private LoginManager()
	{
		loginData = JsonMgr.Instance.LoadData<LoginData>("LoginData");

		registerData = JsonMgr.Instance.LoadData<RegisterData>("RegisterData");

		serverData=JsonMgr.Instance.LoadData<List<ServerData>>("ServerData");
	}

	public void SaveLoginData()
	{
		JsonMgr.Instance.SaveData(loginData, "LoginData");
	}

	public void SaveRegisterData()
	{
		JsonMgr.Instance.SaveData(registerData, "RegisterData");
	}

	public void ClearLoginData()
	{
		loginData.FrontServerID = -1;
		loginData.AutoLogin = false;
		loginData.RemPassword = false;
	}

	public bool RegisterUser(string userName,string password)
	{
		if(registerData.RegisterInfo.ContainsKey(userName))
		{
			return false;
		}

		registerData.RegisterInfo.Add(userName,password);

		ClearLoginData();

		SaveRegisterData();

		return true;
	}

	public bool CheckUser(string userName,string password)
	{
		if (registerData.RegisterInfo.ContainsKey(userName))
		{
			if (registerData.RegisterInfo[userName] == password)
			{
				return true;
			}
		}

		return false;
	}
}
