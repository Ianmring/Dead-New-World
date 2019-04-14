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
        if(ClientManager.Instance.GetClientsToAdd.Count > 0)
        ClientDetailsText.text = ClientManager.Instance.GetClientsToAdd[0].NewRequestedClientDetails();
    }
}
