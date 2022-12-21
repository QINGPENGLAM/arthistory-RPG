using UnityEngine;
using UnityEngine.UI;

public class inventaryslot : MonoBehaviour
{
    item item;

    public Image icon;
    public Button removeButton;

    public void Additem (item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void Clearslot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled=false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventary.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
