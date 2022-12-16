using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCard : MonoBehaviour
{

    private void Start()
    {
        GameManager.Instance.pause = true;
        GameManager.Instance.player.GetComponent<vThirdPersonInput>().enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        gameObject.SetActive(true);
    }
    public void OnClickEnd()
    {
        Application.Quit();
    }

    public void OnClickPlay()
    {
        GameManager.Instance.pause = false;
        GameManager.Instance.player.GetComponent<vThirdPersonInput>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
    }


}
