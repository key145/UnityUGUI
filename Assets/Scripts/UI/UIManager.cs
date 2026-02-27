using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
	private static UIManager instance = new UIManager();

	public static UIManager Instance=>instance;

	private Dictionary<string, BasePanel> PanelDic = new Dictionary<string, BasePanel>();

	private Transform CanvasTrans;

	private UIManager()
	{
		CanvasTrans = GameObject.Find("Canvas").transform;
		GameObject.DontDestroyOnLoad(CanvasTrans);
	}

	public T ShowPanel<T>() where T : BasePanel
	{
		string panelName = typeof(T).Name;
		if(PanelDic.ContainsKey(panelName) )
			return PanelDic[panelName] as T;

		GameObject panelObj = GameObject.Instantiate(Resources.Load<GameObject>("UI/" + panelName), CanvasTrans);

		T panel = panelObj.GetComponent<T>();

		PanelDic.Add(panelName, panel);

		panel.ShowMe();
		return panel;
	}

	public void HidePanel<T>(bool isFade = true) where T : BasePanel
	{
		string panelName = typeof(T).Name;
		if (PanelDic.ContainsKey(panelName))
		{
			if (isFade)
			{
				PanelDic[panelName].HideMe(() =>
				{
					GameObject.Destroy(PanelDic[panelName].gameObject);
					PanelDic.Remove(panelName);
				});
			}
			else
			{
				GameObject.Destroy(PanelDic[panelName].gameObject);
				PanelDic.Remove(panelName);
			}
		}
	}

	public T GetPanel<T>() where T: BasePanel
	{
		string panelName = typeof(T).Name;
		if (PanelDic.ContainsKey(panelName))
			return PanelDic[panelName] as T;
		return null;
	}
}
