using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class Clients : MonoBehaviour
{

  public GameManager mann;

    UIManager uimann;
    string client;

    string deadrelativename;

    string Reasonofdeath;

   public float Pay;

    

   public float timetocomplete;

    public bool ontheclock;

    public Clients(string name, string relation, string causeofdeath, float pay)
    {
        name = client;
        relation = deadrelativename;
        causeofdeath = Reasonofdeath;
        pay = Pay;
    }
    public enum Status { Satisfied, Unsatified, fine, inprogress , notstarted , Finished};

    Status currentstatus;

    float Timetocomplete;

    int ratting;

    public int numberoftaks;

    public int takscompl;
    // Use this for initialization

    public Text name;
    public Text Causeofdeath;
    public Text payr;
    public Text timetocom;

 

    int namenum;
    int Deathnum;
    void Start()
    {
        mann = GameObject.FindObjectOfType<GameManager>();
        uimann = GameObject.FindObjectOfType<UIManager>();

        mann = mann.GetComponent<GameManager>();

        if (mann.tutorial)
        {
            namenum = 0;
            Deathnum = 0;
        }

        namenum = Random.Range(1, mann.Client.Length);
        Deathnum = Random.Range(1, mann.Death.Length);

     
        name.text = ("Name:\n"+mann.Client[namenum]);
        Causeofdeath.text = ("Cause of Death:\n"+ mann.Death[Deathnum]);
                          
        mann.openclients.Insert(0, this);
        payr.text =("Pay: " + Pay.ToString());
        timetocom.text = ("Time to Complete: " + timetocomplete.ToString());
        currentstatus = Status.notstarted;
        //txtcontents = textAsset.text;

    }

    // Update is called once per frame
    void Update()
    {
        if (ontheclock)
        {
            if (mann.TimePassed >= timetocomplete + mann.TimePassed)
            {
                Complete();
            }
        }
        // here is where the completed tasks will go so that planning on making it an array of boolians, need bade's help since he made the asset dropping system

        if (uimann.hideui)
        {
            GetComponent<CanvasGroup>().interactable = false;
            
        }
    }

    void Judge()
    {
        if (ratting > 25)
        {
            currentstatus = Status.Satisfied;
            Complete();
        }
        if (ratting< 25)
        {
            currentstatus = Status.Unsatified;
            Complete();
        }
    }

    public void accept()
    {
        ontheclock = true;
        currentstatus = Status.inprogress;
        Debug.Log(currentstatus);
        //still working on this
        mann.openclients.RemoveAt(mann.openclients.Count - 1);

        
        mann.currentclients.Insert(0,this);
        
    }
    public void Complete()
    {
        Debug.Log("Complete");

        //Judge();
       currentstatus = Status.Satisfied;
        ontheclock = false;
        switch (currentstatus)
        {
            case Status.Unsatified:
                {
                    mann.currBudget = mann.currBudget + Pay;
                  currentstatus=  Status.Finished;
                }
                break;
             case Status.Satisfied:
                {
                    mann.currBudget = mann.currBudget + Pay + (Pay * takscompl/numberoftaks);
                    
                    currentstatus = Status.Finished;

                }
                break;
            case Status.Finished:
                {
                    return;
                }
                break;
        }

        mann.Rattingcalc();
        //mann.compclilist.Insert(0, new Clients(client, deadrelativename, Reasonofdeath, Pay));
        mann.currentclients.RemoveAt(mann.currentclients.Count - 1);

        mann.compclilist.Insert(0,client + "\n"+ deadrelativename + "\n" + Reasonofdeath + "\n" + Pay.ToString());

        Destroy(this.gameObject);


    }

}
