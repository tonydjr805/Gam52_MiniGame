using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PoolingItems
{
    public GameObject item;
    public int amount;
}

public class ObjectPooling : MonoBehaviour {

    public static ObjectPooling instance;
    public PoolingItems[] poolingItems;
    List<GameObject>[] pooledItems;
    public int defaultAmount = 10;
    public bool canExpend;

    [Header("Active and Inactive Lists")]

    public List<GameObject> Active;// List for Active Objects
    public List<GameObject> Inactive; // List for in active objects

   

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {

        //Init Lists
        pooledItems = new List<GameObject>[poolingItems.Length];
        Active = new List<GameObject>();
        Inactive = new List<GameObject>();

        for (int i = 0; i < poolingItems.Length; i++)
        {

            pooledItems[i] = new List<GameObject>();

            int poolingAmout;
            if (poolingItems[i].amount > 0) poolingAmout = poolingItems[i].amount;
            else poolingAmout = defaultAmount;

            for (int j = 0; j < poolingAmout; j++)
            {
                GameObject newItem = Instantiate(poolingItems[i].item);
                newItem.SetActive(false);
                pooledItems[i].Add(newItem);
                Inactive.Add(newItem); //First add every object we create to the in active list
                newItem.transform.SetParent(transform);
            }
        }
    }

    public void DestroyAPS(GameObject myObject)
    {
        myObject.SetActive(false);
        myObject.transform.position = Vector3.zero;
        myObject.transform.rotation = Quaternion.identity;
        Active.Remove(myObject); // Remove this object from active list no longer active anymore
        Inactive.Add(myObject); // add it to the inactive list
    }

    public void DestroyAllAPS()
    {
        for (int i = 0; i < Active.Count; i++)
        {
            Active[i].gameObject.SetActive(false);
            Active[i].gameObject.transform.position = Vector3.zero;
            Active[i].gameObject.transform.rotation = Quaternion.identity;
            Active.Remove(Active[i].gameObject); // Remove this object from active list no longer active anymore
            Inactive.Add(Active[i].gameObject); // add it to the inactive list
        }
    }

    public GameObject InstantiateAPS(string itemName, Vector3 position, Quaternion rotation)
    {
        GameObject newItem = GetPooledItem(itemName);
        if(newItem !=null)
        {
            newItem.transform.position = position;
            newItem.transform.rotation = rotation;
            newItem.SetActive(true);
            Inactive.Remove(newItem); // Remove from inactive list
            Active.Add(newItem); // add it to the active list
            return newItem;
        }

        Debug.LogError("Out of Objects try enabling CanExpend, or Check if you write name corret");
        return null;
    }

    GameObject GetPooledItem(string typeName)
    {
        for (int i = 0; i < poolingItems.Length; i++)
        {
            if (poolingItems[i].item.name == typeName)
            {
                for (int j = 0; j < pooledItems[i].Count; j++)
                {
                    if (!pooledItems[i][j].activeInHierarchy)
                    {
                        return pooledItems[i][j];
                    }
                }

                if (canExpend)
                {
                    GameObject newItem = Instantiate(poolingItems[i].item);
                    newItem.SetActive(false);
                    pooledItems[i].Add(newItem);
                    newItem.transform.SetParent(transform);
                    return newItem;
                }
                break;
            }
        }
        return null;
    }
   
}
