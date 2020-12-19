using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelCutscene : MonoBehaviour
{
    public GameObject CutsceneCamera;
    public GameObject Timeline;

    public GameObject Trigger;

    // Start is called before the first frame update
    void Start()
    {
        CutsceneCamera.SetActive(false);
        Timeline.SetActive(false);
    }

    private void OnTriggerEnter(Collider Player)
    {
        CutsceneCamera.SetActive(true);
        Timeline.SetActive(true);
    }

    private void OnTriggerExit(Collider Player)
    {
        CutsceneCamera.SetActive(false);
        Timeline.SetActive(false);

        Trigger.SetActive(false);
    }
}
