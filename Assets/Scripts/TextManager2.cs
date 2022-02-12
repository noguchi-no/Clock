using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

class Scenarioo
{
    public string ScenarioID;
    public List<(string, Action)> Textss = new List<(string, Action)>();
    public List<string> Texts = new List<string>();
    public List<Option> Options = new List<Option>();
    public string NextScenarioID;

}

class Optionn
{
    public string Text;
    public Action Action;
}

public class TextManager2 : MonoBehaviour
{
    [SerializeField]
    public Text message;
    [SerializeField]
    Transform buttonPanel;

    [SerializeField]
    Button optionButton;
    public List<string> Texts;
    int index = 0;
    public float messageSpeed = 0.2f;

    Scenarioo currentScenario;
    List<Scenarioo> scenarios = new List<Scenarioo>();
    string mesString;

    string mesStrings;



    // Start is called before the first frame update
    void Start()
    {
        Scenarioo scenario01 = new Scenarioo()
        {
            ScenarioID = "scenario01",
            Textss = new List<(string, Action)>()
            {
                ("おはよう", Nothing),
                ("こんにちは",Nothing),
            },

            NextScenarioID = "scenario02"
        };
        Scenarioo scenario02 = new Scenarioo()
        {

            ScenarioID = "scenario02",
            Textss = new List<(string, Action)>()
            {
                ("こんばんは", Nothing),
                ("さようなら", Nothing),
            },

            NextScenarioID = "scenario03"
        };

        scenarios.Add(scenario02);
        SetScenario(scenario01);
    }

    void SetScenario(Scenarioo scenario)
    {

        currentScenario = scenario;

        mesStrings = currentScenario.Textss[0].Item1;

        message.text = mesStrings;


        if (currentScenario.Options.Count > 0)
        {
            SetNextMessage();

        }
    }
    public void TextAction()
    {
        if (DOTween.IsTweening(message))
        {
            //Tween中なら即終了
            mesStrings = currentScenario.Textss[index].Item1;
            message.text = mesStrings;
            message.DOKill();
        }
        else
        {
            index++;
            message.text = "";
            mesStrings = currentScenario.Textss[index].Item1;
            message.DOText(mesStrings, mesStrings.Length * messageSpeed).SetEase(Ease.Linear);

        }
    }


void SetNextMessage()
{
    if (currentScenario.Texts.Count > index + 1)
    {
        TextAction();

    }
    else
    {
        ExitScenario();
    }
}

void ExitScenario()
{

    index = 0;

        message.text = "";
        Scenarioo nextScenario = null;

        foreach (Scenarioo scenario in scenarios)
        {
            if (scenario.ScenarioID == currentScenario.NextScenarioID)
            {
                nextScenario = scenario;
            }
        }

        if (nextScenario != null)
        {
            SetScenario(nextScenario);

        }
        else
        {

            currentScenario = null;
        }
    
}
public void Nothing()
{

}

// Update is called once per frame
    void Update()
    {
        if (currentScenario != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (buttonPanel.GetComponentsInChildren<Button>().Length < 1)
                {
                    SetNextMessage();
                }
            }
        }

    }
}
