using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARImageTarget : MonoBehaviour
{
    public Transform imageSlide;
    float valueSlide = 0.35f;

    public GameObject buttonLeft;
    public GameObject buttonRight;

    void Update()
    {
        DisableButton();
        InteractByMouseOrTouch();
    }

    #region DisableButton

    void DisableButton()
    {
        ButtonLeft();
        ButtonRight();
    }

    void ButtonLeft()
    {
        if (imageSlide.localPosition.x >= 0 && buttonLeft.activeSelf == true)
        {
            buttonLeft.SetActive(false);
        }

        else if (imageSlide.localPosition.x < 0 && buttonLeft.activeSelf == false)
        {
            buttonLeft.SetActive(true);
        }
    }

    void ButtonRight()
    {
        if (imageSlide.localPosition.x <= -1.4f && buttonRight.activeSelf == true)
        {
            buttonRight.SetActive(false);
        }

        else if (imageSlide.localPosition.x > -1.4f && buttonRight.activeSelf == false)
        {
            buttonRight.SetActive(true);
        }
    }

    #endregion

    #region InteractButton

    void InteractByMouseOrTouch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "ButtonLeft")
                {
                    SlideImageLeft();
                }

                else if (hit.collider.gameObject.tag == "ButtonRight")
                {
                    SlideImageRight();
                }
            }

            else
            {
                //Debug.Log("Nothing");
            }
        }
    }

    void SlideImageLeft()
    {
        var currentValue = imageSlide.localPosition.x;
        imageSlide.localPosition = new Vector3(currentValue + valueSlide, 0, 0);
    }

    void SlideImageRight()
    {
        var currentValue = imageSlide.localPosition.x;
        imageSlide.localPosition = new Vector3(currentValue - valueSlide, 0, 0);
    }

    #endregion
}
