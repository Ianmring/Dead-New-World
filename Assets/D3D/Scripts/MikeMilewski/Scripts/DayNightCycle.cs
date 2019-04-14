using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField]
    private Light DirectionalLight;

    [SerializeField]
    private Text TimeText;

    //Value that determines at which intervals the request menu will open.
    [SerializeField]
    private float RequestTimer;

    private float timer;

    private void Update()
    {
        //Rotates the directional light to represent the passage of the day.
        //This is placed just as a test for now. 
        DirectionalLight.transform.Rotate(0, 0.1f * Time.deltaTime, 0);

        timer += Time.deltaTime;

        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = Mathf.Floor(timer % 60).ToString("00");

        OpenRequestMenu();

        TimeText.text = minutes + ":" + seconds;
    }

    private void OpenRequestMenu()
    {
        if (Mathf.Floor(timer % 60) == RequestTimer)
        {
            RequestTimer += 4;
            if (ClientManager.Instance.GetNewClientRequestMenu.activeInHierarchy)
            {
                return;
            }
            else
            {
                ClientManager.Instance.GetNewClientRequestMenu.SetActive(true);
            }
        }
    }
}
