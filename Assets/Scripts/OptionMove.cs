using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMove : MonoBehaviour
{
    [SerializeField] Toggle mouseMove;
    [SerializeField] Toggle KeyboardMove;
    [SerializeField] GameObject MovementOpt;
    // Start is called before the first frame update
    void Start()
    {
       
        if(PlayerMovement.mouseController == true)
        {
            mouseMove.isOn = true;
        }else
        {
            KeyboardMove.isOn = true;
        }
        MovementOpt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if(!MovementOpt.activeSelf )
            {
                MovementOpt.SetActive(true);
                Time.timeScale = 0f;
            }else
            {
                MovementOpt.SetActive(false);
                Time.timeScale = 1f;
            }
        }
        if (mouseMove.isOn)
        {
            PlayerMovement.mouseController = true;
           
        }
        if(KeyboardMove.isOn)
        {
            PlayerMovement.mouseController = false;
        }
    }
}
