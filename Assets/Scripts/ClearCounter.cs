using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField]
    private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                // PLayer is carry => drop to this counter
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                // Player not carry
            }
        }
        else
        {
            if (player.HasKitchenObject()) { }
            else
            {
                // Player not carry anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void InteractAlternate(Player player)
    {
        base.InteractAlternate(player);
    }
}
