using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Item")]
public class item : ScriptableObject
{
    public GameObject[] info;
    private bool isShowing;
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use ()
    {
        for (int i = 0; i < info.Length; i++)
        {
            isShowing = !isShowing;
            info[i].SetActive(isShowing); 
        }
            
    }

    public void RemoveFromInventory()
    {
        Inventary.instance.Remove(this);
    }

}
