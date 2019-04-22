using UnityEngine;
using UnityEngine.UI;

public class ShowNewClientDetails : MonoBehaviour
{
    [SerializeField]
    private Text ClientDetailsText;

    private void Awake()
    {
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        ClientManager.Instance.GetClientsToAdd[ClientManager.Instance.GetClientIndex + 1].GetClientData =
                                                           ClientManager.Instance.GetClientData[ClientManager.Instance.GetClientIndex + 1];

        ClientDetailsText.text = ClientManager.Instance.GetClientsToAdd[ClientManager.Instance.GetClientIndex + 1].NewRequestedClientDetails();
    }
}
