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
            if (player.HasKitchenObject())
            {
                if (
                    player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)
                )
                {
                    // Player is holding a plate
                    if (
                        plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO())
                    )
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
                else
                {
                    // player is not holding plate but holding something else
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        if (
                            plateKitchenObject.TryAddIngredient(
                                player.GetKitchenObject().GetKitchenObjectSO()
                            )
                        )
                        {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            }
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
