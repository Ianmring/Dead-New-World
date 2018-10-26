using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class Clients : MonoBehaviour
{

  public GameManager mann;

    public ClientMana climan;
    UIManager uimann;

    public InventoryMana invman;

    public string client;

    string deadrelativename;

    string Reasonofdeath;

   public float Pay;

   public D3D.Headstone RequestedHeadstone;
    public Coffin RequestedCoffin;

   public float timetocomplete;

    public bool ontheclock;

    public Clients(string name, string relation, string causeofdeath, float pay)
    {
        name = client;
        relation = deadrelativename;
        causeofdeath = Reasonofdeath;
        pay = Pay;
    }
    public enum Status { Satisfied, Unsatified, inprogress , notstarted , Finished};

    public enum bodstate { fresh, boxed, placed, burried, rotton}

    Status currentstatus;

    bodstate currentbodstatus;
    float Timetocomplete;

    int ratting;

    public int numberoftaks;

    public int takscompl;
    // Use this for initialization

    public Text clientName;
    public Text Causeofdeath;
    public Text payr;
    public Text timetocom;
    public Text jobstatus;
 

    int namenum;
    int Deathnum;
    int headnum;
    int coffinnum;

    void Start()
    {
        mann = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
        uimann = GameObject.FindObjectOfType<UIManager>();
        invman = GameObject.FindObjectOfType<InventoryMana>().GetComponent<InventoryMana>();
        climan = FindObjectOfType<ClientMana>();

        //mann = mann

        //invman = 

        if (mann.tutorial)
        {
            namenum = 0;
            Deathnum = 0;
        }

        namenum = Random.Range(1, climan.Client.Length);
        Deathnum = Random.Range(1, climan.Death.Length);
        headnum = Random.Range(0, invman.headstoneList.Count);
        coffinnum = Random.Range(0, invman.CoffinList.Count);

        //  Debug.Log(invman.headstoneList.Count);

        RequestedHeadstone = invman.headstoneList[headnum].GetComponent<headstoneobj>().currentheadstone;
        RequestedCoffin = invman.CoffinList[coffinnum].GetComponent<Coffinobj>().SelectedCoffin;
     
        clientName.text = ("Name:\n"+climan.Client[namenum]);
        Causeofdeath.text = ("Cause of Death:\n"+ climan.Death[Deathnum]);
        client = climan.Client[namenum];
      //  name.text = ("Name:\n"+client);
        Reasonofdeath = climan.Death[Deathnum];
        Causeofdeath.text = ("Cause of Death:\n"+ Reasonofdeath);

                          
        climan.openclients.Insert(0, this);
        payr.text =("Pay: " + Pay.ToString());
        timetocom.text = ("Time to Complete: " + timetocomplete.ToString());
        currentstatus = Status.notstarted;
        //txtcontents = textAsset.text;
        jobstatus.text = "Current Status: Not Started";
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
        jobstatus.text = "Current Status: Started";

        ontheclock = true;
        currentstatus = Status.inprogress;
        Debug.Log(currentstatus);
        //still working on this
        climan.openclients.RemoveAt(climan.openclients.Count - 1);
                
        climan.currentclients.Insert(0,this);
                
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

                    jobstatus.text = "Final Status: Unsatisfied";

                }
                break;
             case Status.Satisfied:
                {
                    mann.currBudget = mann.currBudget + Pay + (Pay * takscompl/numberoftaks);
                    
                    currentstatus = Status.Finished;

                    jobstatus.text = "Final Status: Satisfied";


                }
                break;
            case Status.Finished:
                {
                    return;
                }
        }

        mann.Rattingcalc();
        //mann.compclilist.Insert(0, new Clients(client, deadrelativename, Reasonofdeath, Pay));
        climan.currentclients.RemoveAt(climan.currentclients.Count - 1);

        climan.compclilist.Insert(0,client + "\n" + Reasonofdeath + "\n" + Pay.ToString() + "\n" + jobstatus.text);

        Destroy(this.gameObject);


    }

}
