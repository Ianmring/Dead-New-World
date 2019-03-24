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
        if(ClientManager.Instance.GetClientIndex >= ClientManager.Instance.GetClientsToAdd.Count)
        {
            Debug.Log("Can't make new Clients.");
            return;
        }
        else
        {
            Instantiate(ClientManager.Instance.GetCurrentClients[ClientManager.Instance.GetClientIndex], 
                                                                 new Vector3(Random.Range(-4, 4), Random.Range(-4, 0), 0), 
                                                                 Quaternion.identity);
        }
    }

    public void AcceptClient()
    {
        if(ClientManager.Instance.GetClientIndex >= ClientManager.Instance.GetClientsToAdd.Count)
        {
            return;
        }
        else
        {
            ClientManager.Instance.GetClientIndex++;

            ClientManager.Instance.GetCurrentClients.Add(ClientManager.Instance.GetClientsToAdd[ClientManager.Instance.GetClientIndex]);

            ClientManager.Instance.UpdateClients();
        }
    }

    public void RejectClient(GameObject menu)
    {
        menu.gameObject.SetActive(false);
    }
}
