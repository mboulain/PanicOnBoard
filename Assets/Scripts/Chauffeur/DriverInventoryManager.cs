using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DriverInventoryManager : MonoBehaviour {

    public static DriverInventoryManager driverInventory;

    public List<GameObject> AllSlots;

    InputSelectionScript inputs;

    public List<Sprite> AllButtonsSprite;

    public List<string> InputsToDo, RightInputs, PlayerInputs;

    int actualNumberOfButtons;

    public Image ObjectToGive;

    public GameObject Difficulty3, Difficulty4, Difficulty5, Difficulty6, Difficulty7;

    public bool InventoryOpened;

    int PlayerInputState, OpenedSlot;

	// Use this for initialization
	void Start () {
        driverInventory = this;
        inputs = FindObjectOfType<InputSelectionScript>();

        actualNumberOfButtons = 3;

        ObjectToGive.gameObject.SetActive(false);
        Difficulty3.SetActive(false);
        Difficulty4.SetActive(false);
        Difficulty5.SetActive(false);
        Difficulty6.SetActive(false);
        Difficulty7.SetActive(false);

        InputsToDo[0] = inputs.ActiveDriverInputs[4];
        InputsToDo[1] = inputs.ActiveDriverInputs[5];
        InputsToDo[2] = inputs.ActiveDriverInputs[6];
        InputsToDo[3] = inputs.ActiveDriverInputs[7];

    }

    private void Update()
    {
        if (Input.GetAxisRaw(inputs.ActiveDriverInputs[2]) <= -0.8f)
        {
            if (AllSlots[0].GetComponent<DriverSlotManager>().myCurrentItem != null)
            {
                OpenedSlot = 0;
                OpenInventory(0);
            }
        }

        if (Input.GetAxisRaw(inputs.ActiveDriverInputs[3]) <= -0.8f)
        {
            if (AllSlots[1].GetComponent<DriverSlotManager>().myCurrentItem != null)
            {
                OpenedSlot = 1;
                OpenInventory(1);
            }
        }

        if (Input.GetAxisRaw(inputs.ActiveDriverInputs[3]) >= 0.8f)
        {
            if (AllSlots[2].GetComponent<DriverSlotManager>().myCurrentItem != null)
            {
                OpenedSlot = 2;
                OpenInventory(2);
            }
        }

        if (Input.GetAxisRaw(inputs.ActiveDriverInputs[2]) >= 0.8f)
        {
            if (AllSlots[3].GetComponent<DriverSlotManager>().myCurrentItem != null)
            {
                OpenedSlot = 3;
                OpenInventory(3);
            }
        }

        if (InventoryOpened)
        {
            CheckInputsInInventory();
            CheckIfPlayerIsRight();
        }
    }

    public void AddToInventory(GameObject PickedItem, Sprite ItemImage)
    {
        for(int i = 0; i < AllSlots.Count; i++)
        {
            if(AllSlots[i].GetComponent<DriverSlotManager>().myCurrentItem == null)
            {
                AllSlots[i].GetComponent<DriverSlotManager>().myCurrentItem = PickedItem;
                AllSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = ItemImage;
                return;
            }
        }
    }

    public void OpenInventory(int theSlot)
    {
        if (!InventoryOpened)
        {
            InventoryOpened = true;
            ObjectToGive.gameObject.SetActive(true);
            ObjectToGive.sprite = AllSlots[theSlot].transform.GetChild(0).GetComponent<Image>().sprite;

            if (actualNumberOfButtons == 3)
            {
                Difficulty3.SetActive(true);

                for (int i = 0; i < Difficulty3.GetComponent<ItemsDifficultyManager>().AllImages.Count; i++)
                {
                    int rand = Random.Range(0, InputsToDo.Count);

                    Difficulty3.GetComponent<ItemsDifficultyManager>().AllImages[i].sprite = AllButtonsSprite[rand];
                    RightInputs[i] = InputsToDo[rand];
                }
            }

            if (actualNumberOfButtons == 4)
            {
                Difficulty4.SetActive(true);

                for (int i = 0; i < Difficulty4.GetComponent<ItemsDifficultyManager>().AllImages.Count; i++)
                {
                    int rand = Random.Range(0, InputsToDo.Count);

                    Difficulty4.GetComponent<ItemsDifficultyManager>().AllImages[i].sprite = AllButtonsSprite[rand];
                    RightInputs[i] = InputsToDo[rand];
                }
            }

            if (actualNumberOfButtons == 5)
            {
                Difficulty5.SetActive(true);

                for (int i = 0; i < Difficulty5.GetComponent<ItemsDifficultyManager>().AllImages.Count; i++)
                {
                    int rand = Random.Range(0, InputsToDo.Count);

                    Difficulty5.GetComponent<ItemsDifficultyManager>().AllImages[i].sprite = AllButtonsSprite[rand];
                    RightInputs[i] = InputsToDo[rand];
                }
            }

            if (actualNumberOfButtons == 6)
            {
                Difficulty6.SetActive(true);

                for (int i = 0; i < Difficulty6.GetComponent<ItemsDifficultyManager>().AllImages.Count; i++)
                {
                    int rand = Random.Range(0, InputsToDo.Count);

                    Difficulty6.GetComponent<ItemsDifficultyManager>().AllImages[i].sprite = AllButtonsSprite[rand];
                    RightInputs[i] = InputsToDo[rand];
                }
            }

            if (actualNumberOfButtons == 7)
            {
                Difficulty7.SetActive(true);

                for (int i = 0; i < Difficulty7.GetComponent<ItemsDifficultyManager>().AllImages.Count; i++)
                {
                    int rand = Random.Range(0, InputsToDo.Count);

                    Difficulty7.GetComponent<ItemsDifficultyManager>().AllImages[i].sprite = AllButtonsSprite[rand];
                    RightInputs[i] = InputsToDo[rand];
                }
            }
        }
    }

    public void CheckInputsInInventory()
    {
        if (Input.GetButtonDown(inputs.ActiveDriverInputs[4]))
        {
            PlayerInputs[PlayerInputState] = inputs.ActiveDriverInputs[4];

            if(PlayerInputs[PlayerInputState] == RightInputs[PlayerInputState])
            {
                PlayerInputState += 1;
            }
            else
            {
                CloseInventory();
            }
        }

        if (Input.GetButtonDown(inputs.ActiveDriverInputs[5]))
        {
            PlayerInputs[PlayerInputState] = inputs.ActiveDriverInputs[5];

            if (PlayerInputs[PlayerInputState] == RightInputs[PlayerInputState])
            {
                PlayerInputState += 1;
            }
            else
            {
                CloseInventory();
            }
        }

        if (Input.GetButtonDown(inputs.ActiveDriverInputs[6]))
        {
            PlayerInputs[PlayerInputState] = inputs.ActiveDriverInputs[6];

            if (PlayerInputs[PlayerInputState] == RightInputs[PlayerInputState])
            {
                PlayerInputState += 1;
            }
            else
            {
                CloseInventory();
            }
        }

        if (Input.GetButtonDown(inputs.ActiveDriverInputs[7]))
        {
            PlayerInputs[PlayerInputState] = inputs.ActiveDriverInputs[7];

            if (PlayerInputs[PlayerInputState] == RightInputs[PlayerInputState])
            {
                PlayerInputState += 1;
            }
            else
            {
                CloseInventory();
            }
        }
    }

    public void CheckIfPlayerIsRight()
    {
        if(PlayerInputState == actualNumberOfButtons)
        {
            GiveItemToCop();
        }
    }

    public void CloseInventory()
    {
        PlayerInputState = 0;
        InventoryOpened = false;
        Difficulty3.SetActive(false);
        Difficulty4.SetActive(false);
        Difficulty5.SetActive(false);
        Difficulty6.SetActive(false);
        Difficulty7.SetActive(false);
        ObjectToGive.gameObject.SetActive(false);

        for (int i = 0; i < RightInputs.Count; i++)
        {
            RightInputs[i] = "";
        }

        for (int i = 0; i < PlayerInputs.Count; i++)
        {
            PlayerInputs[i] = "";
        }
    }

    public void GiveItemToCop()
    {
        CloseInventory();

        AllSlots[OpenedSlot].GetComponent<DriverSlotManager>().transform.GetChild(0).GetComponent<Image>().sprite = null;
        AllSlots[OpenedSlot].GetComponent<DriverSlotManager>().myCurrentItem = null;

        // Remplir cette partie quand le cop sera commencé

        if (actualNumberOfButtons < 7)
        {
            actualNumberOfButtons += 1;
        }
    }
}
