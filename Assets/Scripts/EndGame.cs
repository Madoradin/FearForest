using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PopUp;

public class EndGame : MonoBehaviour
{

    public PopUpController popUpEnd;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(EndofGame());
        }
    }

    public IEnumerator EndofGame()
    {
        popUpEnd.SetUp("Congratulations!", "You have made it out of Fear Forest.");
        yield return new WaitForSeconds(5);
        Application.Quit();
    }

}
