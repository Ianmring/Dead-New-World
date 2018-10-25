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
    ClientMana climana;
  

    public float ratting;
    public float[] rattings;

 

    Text budgettxt;
    Text Timetxt;

   

    public bool tutorial;

    public GameObject inv;
    public GameObject Cli;
    private void Start()
    {
        climana = FindObjectOfType<ClientMana>();
  
        inv = GameObject.Find("Inventory");
        Cli = GameObject.Find("Clients");

    
        currBudget = 1000;
        cliholder = GameObject.Find("Clientholder");

        budgettxt = GameObject.Find("Budget").GetComponent<Text>();
        Timetxt = GameObject.Find("Day").GetComponent<Text>();

        Rattingcalc();

        inv.SetActive(false);
        Cli.SetActive(false);
    }

    private void Update()
    {

        //Unclear if time will pass constantly like in the Sims or if there will be an option to pass to the next day.

        budgettxt.text = currBudget.ToString();
        Timetxt.text = day.ToString("f0");


        if (Timepass)
        {
            TimePassed += Time.deltaTime;

           

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

   
}
   
