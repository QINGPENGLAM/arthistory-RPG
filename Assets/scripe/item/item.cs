using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Item")]
public class item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use ()
    {
        Debug.Log("Using" + name);
    }

    public void RemoveFromInventory()
    {
        Inventary.instance.Remove(this);
    }

}
