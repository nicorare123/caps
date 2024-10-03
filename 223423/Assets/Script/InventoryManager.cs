using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    // Start is called before the first frame update
    void Start()
    {
        inventoryPanel.SetActive(false);    
        foreach(var slot in itemSlots)
        {
            slot.gameObject.SetActive(false);
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
                    break;
                }
            }
        }
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
        }
    }
}
