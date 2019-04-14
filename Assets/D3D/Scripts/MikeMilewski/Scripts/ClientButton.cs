using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClientButton : MonoBehaviour
{
    [SerializeField]
    private int ClientIndex;

    public int GetClientIndex
    {
        get
        {
            return ClientIndex;
        }
        set
        {
            ClientIndex = value;
        }
    }

    public void selectedButton()
    {
        ClientManager.Instance.GetEventSystem.SetSelectedGameObject(this.gameObject);
        ClientManager.Instance.GetLastSelectedObject = this.gameObject;
    }
}
