using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientMana : MonoBehaviour {

    GameManager man;

    public GameObject Clients;

   public GameObject cliholder;
    public List<Clients> currentclients = new List<Clients>();

    public List<Clients> openclients = new List<Clients>();

    public List<string> compclilist = new List<string>();

    public TextAsset ClientList;
    public TextAsset DeathList;

    public string[] Client;
    public string[] Death;

    public float clientspawnrate;
    public float clientcountdown;

    public int mintimetospawn;
    public int maxtimetospawn;

    // Use this for initialization
    public void Awake()
    {
       // cliholder = GameObject.Find("ClientHolder").GetComponent<GameObject>();
    }
    public void Start () {
        man = FindObjectOfType<GameManager>();
        ClientList = (TextAsset)Resources.Load("Clients_List");
        DeathList = (TextAsset)Resources.Load("Deaths_List");

        if (ClientList != null)
        {
            Client = (ClientList.text.Split('\n'));
        }
        if (ClientList != null)
        {
            Death = (DeathList.text.Split('\n'));
        }
    }
	
	// Update is called once per frame
	public void Update () {
        if (man.Timepass)
        {

            clientcountdown -= Time.deltaTime;

            if (clientcountdown < 1)
            {
                newclient();
            }

           
        }
    }
    public void newclient()
    {

        GameObject cli;

       // clinum++;
        cli = Instantiate(Clients, this.transform);
        cli.transform.parent = cliholder.gameObject.transform;
        clientspawnrate = Random.Range(mintimetospawn, maxtimetospawn);

        cli.transform.SetParent(cliholder.gameObject.transform);
        clientspawnrate = Random.Range(mintimetospawn, maxtimetospawn);
        clientcountdown = clientspawnrate;

    }
}
