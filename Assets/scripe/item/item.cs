using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Item")]
public class item : ScriptableObject
{

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use ()
    {
            
    }

    public void RemoveFromInventory()
    {
        Inventary.instance.Remove(this);
    }

}
