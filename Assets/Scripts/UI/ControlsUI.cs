using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ControlsUI : MonoBehaviour
{
    public GameObject statusText;
    public GameObject[] _primaryControlsText;

    private TextMeshProUGUI _btnText;
    private bool _waitingForKey;
    private Event keyEvent;
    private KeyCode newKey;

    [Header("Buttons")]
    //0 - LCLICK, 1 - RCLICK
    public Button[] shootButtons;
    public Button[] scopeButtons;
    public Button[] moveButtons;
    public Button[] controlButtons;

    void Start()
    {
        GetInputText();
        ChangeInputButtonText();
        //check which is being used so that other buttons can be greyed out
        ChangeMouseControls(MovementInput.instance.shoot, "shoot");
        ChangeMovementControls(MovementInput.instance.ReturnSetMovement());
        ChangeDefaultControlsDisplay(MovementInput.instance.controls.isDefault);
    }

    #region KBD Controls
    void GetInputText()
    {
        _primaryControlsText = GameObject.FindGameObjectsWithTag("PRIMARYCTRL");
    }
    void ChangeInputButtonText()
    {
        for (int i = 0; i < _primaryControlsText.Length; i++)
        {
            if (_primaryControlsText[i].name == "JUMP1")
                _primaryControlsText[i].GetComponent<TextMeshProUGUI>().text = MovementInput.instance.jump.ToString();
            else if (_primaryControlsText[i].name == "INTERACT1")
                _primaryControlsText[i].GetComponent<TextMeshProUGUI>().text = MovementInput.instance.interact.ToString();
            else if (_primaryControlsText[i].name == "SPRINT1")
                _primaryControlsText[i].GetComponent<TextMeshProUGUI>().text = MovementInput.instance.sprint.ToString();
            else if (_primaryControlsText[i].name == "DROP1")
                _primaryControlsText[i].GetComponent<TextMeshProUGUI>().text = MovementInput.instance.drop.ToString();
        }
    }

    void OnGUI()
    {
        keyEvent = Event.current;
        if (keyEvent.isKey && _waitingForKey)
        {
            newKey = keyEvent.keyCode;
            _waitingForKey = false;
        }
    }

    public void StartAssignment(string keyName)
    {
        if (!_waitingForKey)
            StartCoroutine(AssignKey(keyName));
    }

    public void SendText (TextMeshProUGUI text)
    {
        _btnText = text;
    }

    IEnumerator WaitForKey()
    {
        while (!keyEvent.isKey)
        {
            statusText.SetActive(true);
            yield return null;
        }
    }

    public IEnumerator AssignKey (string keyName)
    {
        _waitingForKey = true;
        yield return WaitForKey(); //doesnt change until a key is pressed

        switch (keyName)
        {
            case "jump":
                MovementInput.instance.jump = newKey;
                _btnText.text = MovementInput.instance.jump.ToString();
                MovementInput.instance.SaveControls();
                break;
            case "interact":
                MovementInput.instance.interact= newKey;
                _btnText.text = MovementInput.instance.interact.ToString();
                MovementInput.instance.SaveControls();
                break;
            case "sprint":
                MovementInput.instance.sprint = newKey;
                _btnText.text = MovementInput.instance.sprint.ToString();
                MovementInput.instance.SaveControls();
                break;
            case "drop":
                MovementInput.instance.drop = newKey;
                _btnText.text = MovementInput.instance.drop.ToString();
                MovementInput.instance.SaveControls();
                break;
        }
        statusText.SetActive(false);
        yield return null;
    }
    #endregion

    #region Mouse Controls
    public void ChangeScopeControl(int mouseNum)
    {
        ChangeMouseControls(mouseNum, "scope");
        Debug.Log("scope control is now " + MovementInput.instance.scope.ToString());
    }

    public void ChangeShootControl(int mouseNum)
    {
        ChangeMouseControls(mouseNum, "shoot");
        Debug.Log("shoot control is now " + MovementInput.instance.shoot.ToString());
    }
    void ChangeMouseControls (int mouseNum, string keyName)
    {
        switch (mouseNum)
        {
            case 0:
                if (keyName == "shoot")
                {
                    MovementInput.instance.shoot = mouseNum;
                    MovementInput.instance.scope = 1;

                    //disable selected control, enable opposite
                    shootButtons[0].interactable = false;
                    shootButtons[1].interactable = true;
                    scopeButtons[0].interactable = true;
                    scopeButtons[1].interactable = false;

                    MovementInput.instance.SaveControls();
                }
                else if (keyName == "scope")
                {
                    MovementInput.instance.shoot = 1;
                    MovementInput.instance.scope = mouseNum;

                    //disable selected control, enable opposite
                    shootButtons[0].interactable = true;
                    shootButtons[1].interactable = false;
                    scopeButtons[0].interactable = false;
                    scopeButtons[1].interactable = true;

                    MovementInput.instance.SaveControls();
                }
                break;
            case 1:
                if (keyName == "shoot")
                {
                    MovementInput.instance.shoot = mouseNum;
                    MovementInput.instance.scope = 0;

                    //disable selected control, enable opposite
                    shootButtons[0].interactable = true;
                    shootButtons[1].interactable = false;
                    scopeButtons[0].interactable = false;
                    scopeButtons[1].interactable = true;

                    MovementInput.instance.SaveControls();
                }
                else if (keyName == "scope")
                {
                    MovementInput.instance.shoot = 0;
                    MovementInput.instance.scope = mouseNum;

                    //disable selected control, enable opposite
                    shootButtons[0].interactable = false;
                    shootButtons[1].interactable = true;
                    scopeButtons[0].interactable = true;
                    scopeButtons[1].interactable = false;

                    MovementInput.instance.SaveControls();
                }
                break;
        }
    }
    #endregion

    public void ChangeMovementControls(string keyName)
    {
        switch(keyName)
        {
            case "WASD":
                MovementInput.instance.hAxis = "Horizontal";
                MovementInput.instance.vAxis = "Vertical";

                //disable selected control, enable opposite
                moveButtons[0].interactable = false;
                moveButtons[1].interactable = true;
                MovementInput.instance.SaveControls();
                break;
            case "IJKL":
                MovementInput.instance.hAxis = "CustomHorizontal";
                MovementInput.instance.vAxis = "CustomVertical";

                //disable selected control, enable opposite
                moveButtons[0].interactable = true;
                moveButtons[1].interactable = false;
                MovementInput.instance.SaveControls();
                break;
        }
        Debug.Log("move controls are now " + MovementInput.instance.hAxis);
    }


    public void ChangeDefaultControlsDisplay(bool isDefault)
    {
        if (isDefault)
        {
            controlButtons[0].interactable = false;
            controlButtons[1].interactable = true;
        }
        else
        {
            controlButtons[0].interactable = true;
            controlButtons[1].interactable = false;
        }
    }
    public void UpdateControlsDisplay()
    {
        ChangeInputButtonText();
        ChangeMouseControls(MovementInput.instance.shoot, "shoot");
        ChangeMovementControls(MovementInput.instance.ReturnSetMovement());
    }
}
