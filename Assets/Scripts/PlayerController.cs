using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private bool hasLantern = false;
    [SerializeField] private bool hasScroll = false;

    [SerializeField] private bool hasMoonGem = false;
    [SerializeField] private bool hasSunGem = false;

    public TMP_Text newPopUp;

    [SerializeField] private GameObject playerCharacter;

    private void Start()
    {
        newPopUp.enabled = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "MoonGem")
        {
            hasMoonGem = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "SunGem")
        {
            hasSunGem = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "LanternUpgrade")
        {
            hasLantern = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "ScrollUpgrade")
        {
            hasScroll = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "CrabMonster")
        {
            if(!hasScroll)
            {
                StartCoroutine(GameManager.Instance.ResetKilled());
            }
            else
            {
                StartCoroutine(setNewPopUp("The incantation banishes the creature back to the void"));
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.name == "pumpkin")
        {
            if (!hasLantern)
            {
                StartCoroutine(GameManager.Instance.ResetKilled());
            }
            else
            {
                StartCoroutine(setNewPopUp("Jack thanks you for returning his lantern"));
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.name == "SunAltar")
        {
            if (!hasSunGem)
            {
                Debug.Log("Place Sun Gem");
            }
            else
            {
                StartCoroutine(setNewPopUp("You place the Sun Gem in the socket"));
                GameManager.Instance.sunAltarSet = true;
            }
        }

        if (collision.gameObject.name == "MoonAltar")
        {
            if (!hasMoonGem)
            {
                Debug.Log("Place Moon Gem");
            }
            else
            {
                StartCoroutine(setNewPopUp("You place the Moon Gem in the socket"));
                GameManager.Instance.moonAltarSet = true;
            }
        }
    }

    public IEnumerator setNewPopUp(string textMessage)
    {
        newPopUp.enabled = true;
        newPopUp.text = textMessage;
        yield return new WaitForSeconds(5);
        newPopUp.enabled = false;
        
    }

}
