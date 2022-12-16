using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PopUp;

    public class CollideObject : MonoBehaviour
    {

        public string headerString;
        public string descriptString;
        public PopUpController popupObject;

        public void OnCollisionEnter(Collision collision)
        {
        Cursor.lockState = CursorLockMode.Confined;
        popupObject.SetUp(headerString,descriptString);
        }
    }

