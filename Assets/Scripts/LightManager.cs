using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{

    public Light lightGameObject;

    private float transitionTimer = 0f;



    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.nightMode && lightGameObject.intensity > 0.4f)
        {
            transitionTimer += Time.deltaTime;
            lightGameObject.intensity = Mathf.Lerp(1.5f,0.4f, transitionTimer/4);
            if(transitionTimer >= 4f)
            {
                transitionTimer = 0f;
            }
            Debug.Log(lightGameObject.intensity);
        }
        if (!GameManager.Instance.nightMode && lightGameObject.intensity < 1.5f)
        {
            transitionTimer += Time.deltaTime;
            lightGameObject.intensity = Mathf.Lerp(0.4f, 1.5f, transitionTimer / 4);
            if (transitionTimer >= 4f)
            {
                transitionTimer = 0f;
            }
            Debug.Log(lightGameObject.intensity);
        }
    }
}
