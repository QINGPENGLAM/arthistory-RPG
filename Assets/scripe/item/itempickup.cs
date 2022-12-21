using UnityEngine;

public class itempickup : interactable
{
    public item item;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up" + item.name);
        bool wasPickedUp = Inventary.instance.Add(item);

        if (wasPickedUp)
            Destroy(gameObject);
    }
}
