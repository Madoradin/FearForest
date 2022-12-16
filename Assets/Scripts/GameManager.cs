using Invector.vCharacterController;
using PopUp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance
    {
        get;
        private set;
    }

    public bool nightMode = false;
    [SerializeField] private float dayTimer = 60f;
    private float currentTimer;
    public bool pause = false;
    private float fogTransitionTimer = 0f;

    [SerializeField] public GameObject player;
    [SerializeField] private Light moonAltar;
    [SerializeField] private Light sunAltar;
    public bool moonAltarSet = false;
    public bool sunAltarSet = false;

    [Header("Night Doors")]
    [SerializeField] private GameObject Mazedoor1;
    [SerializeField] private GameObject Mazedoor2;
    [SerializeField] private GameObject Mazedoor3;
    [SerializeField] private GameObject Mazedoor4;
    [SerializeField] private GameObject MazeExit;

    [Header("DayDoors")]
    [SerializeField] private GameObject DayDoor1;
    [SerializeField] private GameObject DayDoor2;

    public PopUpController popupDead;


    public IEnumerator ResetKilled()
    {
        currentTimer = dayTimer;
        RenderSettings.fogDensity = 0.01f;

        Mazedoor1.SetActive(true);
        Mazedoor2.SetActive(true);
        Mazedoor3.SetActive(true);
        Mazedoor4.SetActive(true);
        DayDoor1.SetActive(false);
        DayDoor2.SetActive(false);

        player.GetComponent<vThirdPersonInput>().cc.input.x = 0;
        player.GetComponent<vThirdPersonInput>().cc.input.z = 0;
        player.GetComponent<vThirdPersonInput>().enabled = false;
        player.transform.position = new Vector3(466,-295,360);

        popupDead.SetUp("Fear has gotten the better of you", "You return to the safety of your campfire");

        yield return new WaitForSeconds(1);

        player.GetComponent<vThirdPersonInput>().enabled = true;
    }


    private void Awake()
    {
        if (Instance != null)
        {
            throw new System.Exception($"Multiple game managers in scene! {Instance} :: {this}");
        }
        Instance = this;
    }

    private void DayTransition(float startingDensity, float targetDensity)
    {
        fogTransitionTimer += Time.deltaTime;
        RenderSettings.fogDensity = Mathf.Lerp(startingDensity, targetDensity, fogTransitionTimer/4);

        if (fogTransitionTimer >= 4f)
            fogTransitionTimer = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTimer = dayTimer;
        RenderSettings.fogDensity = 0.01f;
        Cursor.lockState = CursorLockMode.Confined;

        Mazedoor1.SetActive(true);
        Mazedoor2.SetActive(true);
        Mazedoor3.SetActive(true);
        Mazedoor4.SetActive(true);
        DayDoor1.SetActive(false);
        DayDoor2.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(!pause)
            currentTimer -= Time.deltaTime; 
        
        if(currentTimer <= 0f)
        {
            nightMode = !nightMode;
            currentTimer = dayTimer;

            if (nightMode)
            {
 //               RenderSettings.fogDensity = 0.06f;
                Mazedoor1.SetActive(false);
                Mazedoor2.SetActive(false);
                Mazedoor3.SetActive(false);
                Mazedoor4.SetActive(false);
                DayDoor1.SetActive(true);
                DayDoor2.SetActive(true);
            }
            else
            {
                Mazedoor1.SetActive(true);
                Mazedoor2.SetActive(true);
                Mazedoor3.SetActive(true);
                Mazedoor4.SetActive(true);
                DayDoor1.SetActive(false);
                DayDoor2.SetActive(false);
//                RenderSettings.fogDensity = 0.01f; 
            }
                
        }

        if(nightMode && RenderSettings.fogDensity < 0.06f)
        {
            DayTransition(0.01f, 0.06f);
        }
        if (!nightMode && RenderSettings.fogDensity > 0.01f)
        {
            DayTransition(0.06f, 0.01f);
        }

        if (moonAltarSet)
        {
            moonAltar.intensity = 30;
        }
        if (sunAltarSet)
        {
            sunAltar.intensity = 30;
        }
        if (moonAltarSet && sunAltarSet)
        {
            MazeExit.SetActive(false);
        }
    }

}
