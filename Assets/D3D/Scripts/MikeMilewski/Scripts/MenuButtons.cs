using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class handles all of the button functionalities.
//Add this onto an empty object in the scene and attach
//it to a button event to call a function accordingly.
public class MenuButtons : MonoBehaviour
{
    public void GenerateClient()
    {
        if(ClientManager.Instance.GetCurrentClients.Count > 0)
        {
            Instantiate(ClientManager.Instance.GetCurrentClients[0], new Vector3(Random.Range(-4, 4), Random.Range(-4, 0), 0),
                                                                     Quaternion.identity);

            ClientManager.Instance.GetCurrentClients.RemoveAt(0);
        }
    }

    public void AcceptClient()
    {
        if(ClientManager.Instance.GetClientsToAdd.Count > 0)
        {
            ClientManager.Instance.GetCurrentClients.Add(ClientManager.Instance.GetClientsToAdd[0]);

            ClientManager.Instance.UpdateClients(0);

            ClientManager.Instance.GetClientsToAdd.RemoveAt(0);
        }
    }

    public void RejectClient(GameObject menu)
    {
        menu.gameObject.SetActive(false);
    }
}
