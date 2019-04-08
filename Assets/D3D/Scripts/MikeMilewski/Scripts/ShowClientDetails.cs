using UnityEngine;
using UnityEngine.UI;

public class ShowClientDetails : MonoBehaviour
{
    [SerializeField]
    private Text ClientDetailsText;

    private void OnEnable()
    {
        ClientDetailsText.text = ClientManager.Instance.GetCurrentClients[0].AdditionalClientDetails();
    }
}
