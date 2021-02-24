using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePanelScript : MonoBehaviour
{
    public int PanelMin = 1, PanelMax = 8;
    public int PanelNo;

    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject Panel4;
    public GameObject Panel5;
    public GameObject Panel6;
    public GameObject Panel7;
    public GameObject Panel8;

    // Start is called before the first frame update
    void Start()
    {
        PanelNo = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(PanelNo < PanelMin)
        {
            PanelNo = PanelMin;
        }

        if (PanelNo > PanelMax)
        {
            PanelNo = PanelMax;
        }


        if (PanelNo == 1)
        {
            Panel1.SetActive(true);
        }
        else
        {
            Panel1.SetActive(false);
        }

        if (PanelNo == 2)
        {
            Panel2.SetActive(true);
        }
        else
        {
            Panel2.SetActive(false);
        }

        if (PanelNo == 3)
        {
            Panel3.SetActive(true);
        }
        else
        {
            Panel3.SetActive(false);
        }

        if (PanelNo == 4)
        {
            Panel4.SetActive(true);
        }
        else
        {
            Panel4.SetActive(false);
        }

        if (PanelNo == 5)
        {
            Panel5.SetActive(true);
        }
        else
        {
            Panel5.SetActive(false);
        }

        if (PanelNo == 6)
        {
            Panel6.SetActive(true);
        }
        else
        {
            Panel6.SetActive(false);
        }

        if (PanelNo == 7)
        {
            Panel7.SetActive(true);
        }
        else
        {
            Panel7.SetActive(false);
        }

        if (PanelNo == 8)
        {
            Panel8.SetActive(true);
        }
        else
        {
            Panel8.SetActive(false);
        }
    }

    public void NextPanel()
    {
        PanelNo++;
    }

    public void PreviousPanel()
    {
        PanelNo--;
    }
}
