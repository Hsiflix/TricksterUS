using UnityEngine;
using UnityEngine.UI;

public class mapBuyMenu : MonoBehaviour
{
    public Animator _animator;

    private void OnEnable() {
        Text moneyText = GameObject.Find("money_text").GetComponent<Text>();
        if(info.money < 1000000){
            moneyText.text = info.money.ToString();
        }else{
            string tmp = info.money.ToString().Substring(0,1)+'.';
            tmp += info.money.ToString().Substring(1,1)+"kk+";
            moneyText.text = tmp;
        }
    }

	// Use this for initialization
	public void Start () {
		_animator = gameObject.GetComponent<Animator>();
        //PurchaseManager.OnPurchaseConsumable += PurchaseManager_OnPurchaseConsumable;
	}

    /*private void PurchaseManager_OnPurchaseConsumable(UnityEngine.Purchasing.PurchaseEventArgs args){
        Debug.Log("You purhcase: "+args.purchasedProduct.definition.id);
        if(args.purchasedProduct.definition.id.Equals("buy_money_1")) MoneyBuy1();
        else if(args.purchasedProduct.definition.id.Equals("buy_money_2")) MoneyBuy2();
        else if(args.purchasedProduct.definition.id.Equals("buy_money_3")) MoneyBuy3();
    }*/

    private void UpdateCount(){
        info.Save();
        Debug.Log(info.money);
        Text moneyText = GameObject.Find("money_text").GetComponent<Text>();
        if(info.money < 1000000){
            moneyText.text = info.money.ToString();
        }else{
            string tmp = info.money.ToString().Substring(0,1)+'.';
            tmp += info.money.ToString().Substring(1,1)+"kk+";
            moneyText.text = tmp;
        }
    }
	
	public void Opt(){
        bool isOpen = _animator.GetBool("open");
		_animator.SetBool("open",!isOpen);
		if(info.AudioOn) GameObject.Find("audio_buy_menu").GetComponent<AudioSource>().Play();
	}

    public void MoneyBuy1(){
		if(info.AudioOn) GameObject.Find("audio_buymoney_button").GetComponent<AudioSource>().Play();
        info.money+=10000;
        UpdateCount();
	}
    public void MoneyBuy2(){
		if(info.AudioOn) GameObject.Find("audio_buymoney_button").GetComponent<AudioSource>().Play();
        info.money+=100000;
        UpdateCount();
	}
    public void MoneyBuy3(){
		if(info.AudioOn) GameObject.Find("audio_buymoney_button").GetComponent<AudioSource>().Play();
        info.money+=1000000;
        UpdateCount();
    }

    public void actionEnableTrue(){
    }

    public void actionEnableFalse(){
    }
}
