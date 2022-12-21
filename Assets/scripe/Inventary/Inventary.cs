using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventary : MonoBehaviour
{
    #region singleton

    public static Inventary instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("more than one instance of inventory found");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    public int space = 20;

    public List<item> items = new List<item>();

    public bool Add (item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("not enough room");
                return false;
            }
            items.Add(item);

            if (onItemChangedCallBack !=null)
                onItemChangedCallBack.Invoke();
        }
        return true;
        
    }

    public void Remove (item item)
    {
        items.Remove (item);

        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
