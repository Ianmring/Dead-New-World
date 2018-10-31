using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class ClientMana : MonoBehaviour {

    GameManager man;

    InventoryMana inv;
    public GameObject Clients;

   public GameObject cliholder;
    public List<Clients> currentclients = new List<Clients>();

    public List<Clients> openclients = new List<Clients>();

    public List<string> compclilist = new List<string>();

   // public TextAsset ClientList;
  //  public TextAsset DeathList;

    public string[] Client;
    public string[] Death;

    public float clientspawnrate;
    public float clientcountdown;

    public int mintimetospawn;
    public int maxtimetospawn;

    int Cnamenum;
    int CDeathnum;
    int Cheadnum;
    int Ccoffinnum;
    // Use this for initialization
    public void Awake()
    {
       // cliholder = GameObject.Find("ClientHolder").GetComponent<GameObject>();
    }
    public void Start () {
        
        man = FindObjectOfType<GameManager>();
        inv = FindObjectOfType<InventoryMana>();

        string CliList = File.ReadAllText(Application.dataPath +"/ClientInfo"+ "/ClientlistJS.json");
        string DeadList = File.ReadAllText(Application.dataPath + "/ClientInfo" + "/DeathListJS.json");

        // ClientList = (TextAsset)Resources.Load("Clients_List");
       // DeathList = (TextAsset)Resources.Load("Deaths_List");

        if (CliList != null)
        {
            Client = (CliList.Split('\n'));
        }
        if (DeadList != null)
        {
            Death = (DeadList.Split('\n'));
        }

        //JsonUtility.ToJson(Client);
       // File.WriteAllText(Application.dataPath + "/ClientlistJS.json", Client[2]);

       // File.WriteAllText(Application.dataPath + "/ClientlistJS.json", Client[1]);

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
        Clients clientS;

        GameObject cli;


       // clinum++;
        cli = Instantiate(Clients, this.transform);
        clientS = cli.gameObject.GetComponent<Clients>();
        randomclifactor();
        clientS.namenum = Cnamenum;
        clientS.Deathnum = CDeathnum;
        clientS.headnum = Cheadnum;
        clientS.coffinnum = Ccoffinnum;

        cli.transform.parent = cliholder.gameObject.transform;
        clientspawnrate = Random.Range(mintimetospawn, maxtimetospawn);

        cli.transform.SetParent(cliholder.gameObject.transform);
        clientspawnrate = Random.Range(mintimetospawn, maxtimetospawn);
        clientcountdown = clientspawnrate;

    }

    public void randomclifactor()
    {
        Cnamenum = Random.Range(1, Client.Length);
        CDeathnum = Random.Range(1, Death.Length);
        Cheadnum = Random.Range(0, inv.headstoneList.Count);
        Ccoffinnum = Random.Range(0, inv.CoffinList.Count);
    }
}
