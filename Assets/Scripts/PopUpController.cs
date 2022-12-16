using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


namespace PopUp
{
    public class PopUpController : MonoBehaviour
    {

        [SerializeField] private TMP_Text headerText;
        [SerializeField] private TMP_Text descriptionText;

        // Start is called before the first frame update
        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void SetUp(string header, string description)
        {
            headerText.text = header;
            descriptionText.text = description;
            GameManager.Instance.pause = true;
            GameManager.Instance.player.GetComponent<vThirdPersonInput>().cc.input.x = 0;
            GameManager.Instance.player.GetComponent<vThirdPersonInput>().cc.input.z = 0;
            GameManager.Instance.player.GetComponent<vThirdPersonInput>().enabled = false;
            gameObject.SetActive(true);

        }
        private void OnClick()
        {
            ClosePopUp();
        }

        public void ClosePopUp()
        {
            GameManager.Instance.pause = false;
            GameManager.Instance.player.GetComponent<vThirdPersonInput>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            gameObject.SetActive(false);
        }
    }
}
