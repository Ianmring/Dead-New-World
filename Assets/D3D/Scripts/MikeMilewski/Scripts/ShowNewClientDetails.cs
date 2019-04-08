using UnityEngine;
using UnityEngine.UI;

public class ShowNewClientDetails : MonoBehaviour
{
    [SerializeField]
    private Text detailsText;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        UpdateClientDetails();
    }

    private void UpdateClientDetails()
    {
        if(ClientManager.Instance.GetClientsToAdd.Count > 0)
        detailsText.text = ClientManager.Instance.GetClientsToAdd[0].NewRequestedClientDetails();
    }
}
