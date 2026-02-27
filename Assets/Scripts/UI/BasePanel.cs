using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public abstract class BasePanel : MonoBehaviour
{
	private CanvasGroup CanvasGroup;

	private float AlphaSpeed = 10f;

	private bool isShow;

	private UnityAction HideCallBack;

	protected virtual void Awake()
	{
		CanvasGroup = this.GetComponent<CanvasGroup>();
		if(CanvasGroup == null)
		{
			CanvasGroup = this.AddComponent<CanvasGroup>();
		}
	}

	protected virtual void Start()
	{
		Init();
	}

	public abstract void Init();

	public virtual void ShowMe()
	{
		isShow = true;
		CanvasGroup.alpha = 0;
	}

	public virtual void HideMe(UnityAction callBack)
	{
		isShow = false;
		CanvasGroup.alpha = 1;
		HideCallBack = callBack;
	}

	public void Update()
	{
		if (isShow && CanvasGroup.alpha != 1)
		{
			CanvasGroup.alpha += AlphaSpeed * Time.deltaTime;
			if(CanvasGroup.alpha >= 1)
			{
				CanvasGroup.alpha = 1;
			}
		}
		if (!isShow && CanvasGroup.alpha != 0)
		{
			CanvasGroup.alpha -= AlphaSpeed * Time.deltaTime;
			if (CanvasGroup.alpha <= 0)
			{
				CanvasGroup.alpha = 0;
				HideCallBack?.Invoke();
			}
		}
	}


}
