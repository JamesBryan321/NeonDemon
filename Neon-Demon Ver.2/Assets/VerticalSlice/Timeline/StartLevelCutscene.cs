using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelCutscene : MonoBehaviour
{
    public GameObject CutsceneCamera;
    public GameObject Timeline;

    public GameObject Trigger;

    public GameObject player;

    void Start()
    {
        CutsceneCamera.SetActive(false);
        Timeline.SetActive(false);
    }

    private void OnTriggerEnter(Collider Player)
    {
        CutsceneCamera.SetActive(true);
        Timeline.SetActive(true);

        player.SetActive(false);

        StartCoroutine(EnablePlayer());
    }

    private void OnTriggerExit(Collider Player)
    {
        CutsceneCamera.SetActive(false);
        Timeline.SetActive(false);

        Trigger.SetActive(false);
    }

    IEnumerator EnablePlayer()
    {
        yield return new WaitForSeconds(3.5f);

        player.SetActive(true);
        CutsceneCamera.SetActive(false);
        Timeline.SetActive(false);

        Trigger.SetActive(false);
    }
}
