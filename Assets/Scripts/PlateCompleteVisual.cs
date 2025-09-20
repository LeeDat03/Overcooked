using System;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public struct KichenObjectSO_GameObject
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    }

    [SerializeField]
    private PlateKitchenObject plateKitchenObject;

    [SerializeField]
    private List<KichenObjectSO_GameObject> kichenObjectSOGameObjectList;

    private void Start()
    {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;
        foreach (KichenObjectSO_GameObject kichenObjectSOGameObject in kichenObjectSOGameObjectList)
        {
            kichenObjectSOGameObject.gameObject.SetActive(false);
        }
    }

    private void PlateKitchenObject_OnIngredientAdded(
        object sender,
        PlateKitchenObject.OnIngredientAddedEventArgs e
    )
    {
        foreach (KichenObjectSO_GameObject kichenObjectSOGameObject in kichenObjectSOGameObjectList)
        {
            if (kichenObjectSOGameObject.kitchenObjectSO == e.kitchenObjectSO)
            {
                kichenObjectSOGameObject.gameObject.SetActive(true);
            }
        }
    }
}
