using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] itemSlots;
    public UseItem useItem;
    public int gold;
    public TMP_Text goldText;
    public GameObject lootPrefab;
    public Transform player;

    private void Start()
    {
        foreach (var slot in itemSlots)
        {
            slot.UpdateUI();
        }
    }
    private void OnEnable()
    {
        Loot.OnItemLooted += AddItem;
    }

    private void OnDisable()
    {
        Loot.OnItemLooted -= AddItem;
    }

    public void AddItem(ItemSO itemSO, int quantity)
    {
        if (itemSO.isGold)
        {
            gold += quantity;
            goldText.text = gold.ToString();
            return;
        }
        foreach (var slot in itemSlots)
        {
            if (slot.ItemSO == itemSO && slot.quantity < itemSO.stackSize)
            {
                int availablesSpace = itemSO.stackSize - slot.quantity;
                int amountToAdd = Mathf.Min(availablesSpace, quantity);
                slot.quantity += amountToAdd;
                quantity -= amountToAdd;
                slot.UpdateUI();
                if (quantity <= 0)
                    return;
            }
        }
        foreach (var slot in itemSlots)
        {
            if (slot.ItemSO == null)
            {
                int amountToAdd = Mathf.Min(itemSO.stackSize, quantity);
                slot.ItemSO = itemSO;
                slot.quantity = quantity;
                slot.UpdateUI();
                return;
            }
        }
        if(quantity > 0)
            DropLoot(itemSO, quantity);
    }

    public void DropItem(InventorySlot slot)
    {
        DropLoot(slot.ItemSO, 1);
        slot.quantity--;
        if(slot.quantity <= 0)
        {
            slot.ItemSO = null;
        }
        slot.UpdateUI();
    }

    private void DropLoot(ItemSO itemSO, int quantity)
    {
        Loot loot = Instantiate(lootPrefab, player.position, Quaternion.identity).GetComponent<Loot>();
        loot.Initialize(itemSO,quantity);
    }

    public void UseItem(InventorySlot slot)
    {
        if (slot.ItemSO != null && slot.quantity >= 0)
        {
            useItem.ApplyItemEffects(slot.ItemSO);
            slot.quantity--;
            if (slot.quantity <= 0)
            {
                slot.ItemSO = null;
            }
            slot.UpdateUI();
        }
    }
}
