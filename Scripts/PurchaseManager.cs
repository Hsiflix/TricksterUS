using System;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;
 
public class PurchaseManager : MonoBehaviour, IStoreListener
{
    private static IStoreController m_StoreController;
    private static IExtensionProvider m_StoreExtensionProvider;
    private int currentProductIndex;
 
    [Tooltip("Не многоразовые товары. Больше подходит для отключения рекламы и т.п.")]
    public string[] NC_PRODUCTS;
    [Tooltip("Многоразовые товары. Больше подходит для покупки игровой валюты и т.п.")]
    public string[] C_PRODUCTS;
 
    /// <summary>
    /// Событие, которое запускается при удачной покупке многоразового товара.
    /// </summary>
    public static event OnSuccessConsumable OnPurchaseConsumable;
    /// <summary>
    /// Событие, которое запускается при удачной покупке не многоразового товара.
    /// </summary>
    public static event OnSuccessNonConsumable OnPurchaseNonConsumable;
    /// <summary>
    /// Событие, которое запускается при неудачной покупке какого-либо товара.
    /// </summary>
    public static event OnFailedPurchase PurchaseFailed;
 
    private void Awake()
    {
        InitializePurchasing();
    }
    /// <summary>
    /// Проверить, куплен ли товар.
    /// </summary>
    /// <param name="id">Индекс товара в списке.</param>
    /// <returns></returns>
    public static bool CheckBuyState(string id)
    {
        Product product = m_StoreController.products.WithID(id);
        if (product.hasReceipt) { return true; }
        else { return false; }
    }
 
    public void InitializePurchasing()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        foreach (string s in C_PRODUCTS) builder.AddProduct(s, ProductType.Consumable);
        foreach (string s in NC_PRODUCTS) builder.AddProduct(s, ProductType.NonConsumable);
        UnityPurchasing.Initialize(this, builder);
    }
 
    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }
 
    public void BuyConsumable(int index)
    {
        currentProductIndex = index;
        BuyProductID(C_PRODUCTS[index]);
    }
 
    public void BuyNonConsumable(int index)
    {
        currentProductIndex = index;
        BuyProductID(NC_PRODUCTS[index]);
    }
 
    void BuyProductID(string productId)
    {
        if (IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productId);
 
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                try{GameObject.Find("Debug").GetComponent<Text>().text += "\n"+string.Format("Purchasing product asychronously: '{0}'", product.definition.id);
                }catch{}
                m_StoreController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
                try{GameObject.Find("Debug").GetComponent<Text>().text += "\n"+"BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase";}
                catch{}
                OnPurchaseFailed(product, PurchaseFailureReason.ProductUnavailable);
            }
        }
    }
 
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: PASS");
        try{GameObject.Find("Debug").GetComponent<Text>().text += "\n"+"OnInitialized: PASS";}
        catch{}
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }
 
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
        try{GameObject.Find("Debug").GetComponent<Text>().text += "\n"+"OnInitializeFailed InitializationFailureReason:" + error;}
        catch{}
    }
 
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (C_PRODUCTS.Length > 0 && String.Equals(args.purchasedProduct.definition.id, C_PRODUCTS[currentProductIndex], StringComparison.Ordinal))
            OnSuccessC(args);
        else if (NC_PRODUCTS.Length > 0 && String.Equals(args.purchasedProduct.definition.id, NC_PRODUCTS[currentProductIndex], StringComparison.Ordinal))
            OnSuccessNC(args);
        else {
            Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
            try{GameObject.Find("Debug").GetComponent<Text>().text += "\n"+string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id);
            }catch{}
        }
        return PurchaseProcessingResult.Complete;
    }
 
    public delegate void OnSuccessConsumable(PurchaseEventArgs args);
    protected virtual void OnSuccessC(PurchaseEventArgs args)
    {
        if (OnPurchaseConsumable != null) OnPurchaseConsumable(args);
        Debug.Log(C_PRODUCTS[currentProductIndex] + " Buyed!");
        try{GameObject.Find("Debug").GetComponent<Text>().text += "\n"+C_PRODUCTS[currentProductIndex] + " Buyed!";
        }catch{}
    }
    public delegate void OnSuccessNonConsumable(PurchaseEventArgs args);
    protected virtual void OnSuccessNC(PurchaseEventArgs args)
    {
        if (OnPurchaseNonConsumable != null) OnPurchaseNonConsumable(args);
        Debug.Log(NC_PRODUCTS[currentProductIndex] + " Buyed!");
        try{GameObject.Find("Debug").GetComponent<Text>().text += "\n"+NC_PRODUCTS[currentProductIndex] + " Buyed!";
        }catch{}
    }
    public delegate void OnFailedPurchase(Product product, PurchaseFailureReason failureReason);
    protected virtual void OnFailedP(Product product, PurchaseFailureReason failureReason)
    {
        if (PurchaseFailed != null) PurchaseFailed(product,failureReason);
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
        try{GameObject.Find("Debug").GetComponent<Text>().text += "\n"+string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason);}
        catch{}
    }
 
    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        OnFailedP(product,failureReason);
    }
}