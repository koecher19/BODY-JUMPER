using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FirstSelected : MonoBehaviour
{
    public GameObject resumeButton;
    public GameObject selectedWhenMenuAsleep;

    void OnEnable()
    {
        Debug.Log("menu enabled");
        this.setResumeAsSelected();
    }

    void setResumeAsSelected()
    {
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(this.resumeButton, new BaseEventData(eventSystem));
    }

    public void setOtherAsSelected()
    {
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(this.selectedWhenMenuAsleep, new BaseEventData(eventSystem));
    }
}
