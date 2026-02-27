using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class ServerChooseBtn : MonoBehaviour
{
    public Text ServerName;
    public Image ServerState;
    public Button SelfBtn;
    public GameObject NewSign;

    public ServerData CurServerInfo;


    void Start()
    {
        SelfBtn.onClick.AddListener(() =>
        {
            LoginManager.Instance.LoginData.FrontServerID = CurServerInfo.id;

            UIManager.Instance.HidePanel<ChooseServerPanel>();

            UIManager.Instance.ShowPanel<ServerPanel>();
        });
    }

    public void InitInfo(ServerData serverData)
    {
		CurServerInfo = serverData;

		ServerName.text = serverData.id.ToString() + "Çø  " + serverData.name;

        NewSign.SetActive(serverData.isNew);

        SpriteAtlas sa = Resources.Load<SpriteAtlas>("Login");
        switch (serverData.state)
        {
            case 0:
				ServerState.gameObject.SetActive(false);
				break;
            case 1:
                ServerState.gameObject.SetActive(true);
                ServerState.sprite = sa.GetSprite("ui_DL_huobao_01");
                break;
            case 2:
				ServerState.gameObject.SetActive(true);
				ServerState.sprite = sa.GetSprite("ui_DL_liuchang_01");
				break;
            case 3:
				ServerState.gameObject.SetActive(true);
				ServerState.sprite = sa.GetSprite("ui_DL_fanhua_01");
				break;
            case 4:
				ServerState.gameObject.SetActive(true);
				ServerState.sprite = sa.GetSprite("ui_DL_weihu_01");
				break;
        }

    }
}
