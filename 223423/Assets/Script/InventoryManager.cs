using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryPanel;
    private bool isInventoryOpen = false;

    public List<GameObject> items = new List<GameObject>();
    public List<Image> itemSlots;

    [System.Serializable]
    public class InventoryItem
    {
        public string itemName;
        public Sprite itemSprite;
    }

    public List<InventoryItem> inventoryItems;

    public Image BigImage;
    public GameObject BigImagePanel;
    public CanvasGroup BigImageCanvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        inventoryPanel.SetActive(false);    
        foreach(var slot in itemSlots)
        {
            slot.gameObject.SetActive(false);
        }
        BigImagePanel.SetActive(false);

        if (BigImageCanvasGroup != null)
        {
            BigImageCanvasGroup.blocksRaycasts = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    public void AddItem(GameObject item)
    {
        items.Add(item);
        UpdateInventoryUI(item.name);
    }

    void UpdateInventoryUI(string itemName)
    {
        for(int i = 0; i < items.Count; i++)
        {
            itemSlots[i].gameObject.SetActive(true);

            foreach (var invItem in inventoryItems)
            {
                if(invItem.itemName == items[i].name)
                {
                    itemSlots[i].sprite = invItem.itemSprite;
                    

                    AddMouseEvent(itemSlots[i], invItem.itemSprite);
                    break;
                }
            }
        }
    }

    void AddMouseEvent(Image slot, Sprite itemSprite)
    {
        EventTrigger trigger = slot.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry pointerEnter = new EventTrigger.Entry();
        pointerEnter.eventID = EventTriggerType.PointerEnter;
        pointerEnter.callback.AddListener((eventData) => { ShowBigImage(itemSprite); });
        trigger.triggers.Add(pointerEnter);

        EventTrigger.Entry pointerExit = new EventTrigger.Entry();
        pointerExit.eventID = EventTriggerType.PointerExit;
        pointerExit.callback.AddListener((eventData) => { HideBigImage(); });
        trigger.triggers.Add(pointerExit);
    }

    void ShowBigImage(Sprite itemSprite)
    {
        BigImage.sprite = itemSprite;
        BigImagePanel.SetActive(true);
    }
    void HideBigImage()
    {
        BigImagePanel.SetActive(false);
    }
    void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;

        inventoryPanel.SetActive(isInventoryOpen);

        if (isInventoryOpen)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;

            HideBigImage();
        }
    }
}
