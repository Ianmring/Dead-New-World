using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public float currBudget;
    float infation;
    float inflationmax = 16;
    public float inflationrate;
    public float TimePassed;
    public float day;
    public float dayrate;
    public bool Timepass;

    public int clinum;

    public GameObject Clients;

    GameObject cliholder;
    public List<Clients> currentclients = new List<Clients>();

    public List<Clients> openclients = new List<Clients>();

    public List<string> compclilist = new List<string>();


    public float ratting;
    public float[] rattings;

    float clientspawnrate;
    public float clientcountdown;

    public int mintimetospawn;
    public int maxtimetospawn;

    Text budgettxt;
    Text Timetxt;

    public TextAsset ClientList;
    public TextAsset DeathList;


    public string[] Client;
    public string[] Death;

    public bool tutorial;
    private void Start()
    {
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
        currBudget = 1000;
        cliholder = GameObject.Find("Clientholder");

        budgettxt = GameObject.Find("Budget").GetComponent<Text>();
        Timetxt = GameObject.Find("Day").GetComponent<Text>();

        Rattingcalc();

    }

    private void Update()
    {

        //Unclear if time will pass constantly like in the Sims or if there will be an option to pass to the next day.

        budgettxt.text = currBudget.ToString();
        Timetxt.text = day.ToString("f0");


        if (Timepass)
        {
            TimePassed += Time.deltaTime;

            clientcountdown -= Time.deltaTime;

            if (clientcountdown < 1)
            {
                newclient();
            }

            if (infation < inflationmax)
            {
                infation = TimePassed * inflationrate;

            }

        }

        day = 1+ (TimePassed / dayrate);

    }
    public void Rattingcalc()
    {
        foreach (var Rattings in rattings)
        {
            ratting += Rattings;
        }
       ratting = ratting / rattings.Length;
    }

    public void newclient()
    {

        GameObject cli;

        clinum++;
        cli = Instantiate(Clients,this.transform);
// HEAD
        cli.transform.parent = cliholder.gameObject.transform;
        clientspawnrate = Random.Range(mintimetospawn, maxtimetospawn);
//
        cli.transform.SetParent(cliholder.gameObject.transform);
       clientspawnrate = Random.Range(mintimetospawn, maxtimetospawn);
// 748012388b21bd9e6a24ce1b6dedb3ff22a396f2
        clientcountdown = clientspawnrate;

    }
}
   
