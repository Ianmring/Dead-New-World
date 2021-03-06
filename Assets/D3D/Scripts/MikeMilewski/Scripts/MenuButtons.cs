﻿using UnityEngine;

//This class handles all of the button functionalities.
//Add this onto an empty object in the scene, attach
//it to a button event, and call an appropriate function.
public class MenuButtons : MonoBehaviour
{
    public void GenerateClient()
    {
        if(ClientManager.Instance.GetCurrentClients.Count > 0 && ClientManager.Instance.GetLastSelectedObject != null)
        {
            if(ClientManager.Instance.GetLastSelectedObject.GetComponent<ClientButton>() && 
               ClientManager.Instance.GetLastSelectedObject.GetComponent<ClientButton>().GetAlreadyInScene == false)
            {
                Instantiate(ClientManager.Instance.GetCurrentClients
                           [ClientManager.Instance.GetLastSelectedObject.GetComponent<ClientButton>().GetClientIndex],
                           new Vector3(Random.Range(0.37f, 5.95f), Random.Range(-4.28f, -0.37f), 0), Quaternion.identity);

                ClientManager.Instance.GetLastSelectedObject.GetComponent<ClientButton>().GetAlreadyInScene = true;
            }
        }
    }

    public void AcceptClient()
    {
        if(ClientManager.Instance.GetClientsToAdd.Count > 0)
        {
            ClientManager.Instance.GetCurrentClients.Add(ClientManager.Instance.GetClientsToAdd[ClientManager.Instance.GetClientIndex + 1]);

            ClientManager.Instance.UpdateClients(ClientManager.Instance.GetClientIndex + 1);
        }
    }

    public void GetClientInfo()
    {
        ClientManager.Instance.GetClientDetailsMenu.SetActive(true);

        ClientManager.Instance.GetCurrentClients[ClientManager.Instance.GetEventSystem.currentSelectedGameObject.GetComponent<ClientButton>().GetClientIndex].GetClientData =
                                                 ClientManager.Instance.GetClientData[ClientManager.Instance.GetEventSystem.currentSelectedGameObject.GetComponent<ClientButton>().GetClientIndex];

        ClientManager.Instance.GetClientInfoText.text = ClientManager.Instance.GetCurrentClients
        [ClientManager.Instance.GetEventSystem.currentSelectedGameObject.GetComponent<ClientButton>().GetClientIndex].AdditionalClientDetails();
    }

    public void CloseMenu(GameObject menu)
    {
        menu.gameObject.SetActive(false);
    }

    public void OpenMenu(GameObject menu)
    {
        menu.gameObject.SetActive(true);
    }

    public void ToggleMenu(GameObject menu)
    {
        if(menu.activeInHierarchy)
        {
            menu.SetActive(false);
        }
        else
        {
            menu.SetActive(true);
        }
    }
}
