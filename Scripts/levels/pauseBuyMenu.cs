using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseBuyMenu : MonoBehaviour
{
	public Animator _animator;
    public pause Pause;
    private int trickHelpCost = 1000;
    private float trickHelpDiscount5 = 0.1f;
    private float trickHelpDiscount10 = 0.15f;
    private int mode = 0; //0 - TH, 1 - M

    private void OnEnable() {
        //_animator = gameObject.GetComponent<Animator>();
        Text moneyText = GameObject.Find("money_text").GetComponent<Text>();
        if(info.money < 1000000){
            moneyText.text = info.money.ToString();
        }else{
            string tmp = info.money.ToString().Substring(0,1)+'.';
            tmp += info.money.ToString().Substring(1,1)+"kk+";
            moneyText.text = tmp;
        }
        Text trickHelpText = GameObject.Find("trickHelp_text").GetComponent<Text>();
        if(info.trickHelpCount < 1000000){
            trickHelpText.text = info.trickHelpCount.ToString();
        }else{
            string tmp = info.trickHelpCount.ToString().Substring(0,1)+'.';
            tmp += info.trickHelpCount.ToString().Substring(1,1)+"kk+";
            trickHelpText.text = tmp;
        }
    }

	// Use this for initialization
	public void Start () {
		_animator = gameObject.GetComponent<Animator>();
        //Debug.Log(_animator.name);
        if(_animator.name == "trickHelp_menu"){
            mode = 0;
        }else if (_animator.name == "money_menu"){
            //PurchaseManager.OnPurchaseConsumable += PurchaseManager_OnPurchaseConsumable;
            mode = 1;
        }
        /*Text moneyText = GameObject.Find("money_text").GetComponent<Text>();
        if(info.money < 1000000){
            moneyText.text = info.money.ToString();
        }else{
            string tmp = info.money.ToString().Substring(0,1)+'.';
            tmp += info.money.ToString().Substring(1,1)+"kk+";
            moneyText.text = tmp;
        }
        Text trickHelpText = GameObject.Find("trickHelp_text").GetComponent<Text>();
        if(info.trickHelpCount < 1000000){
            trickHelpText.text = info.trickHelpCount.ToString();
        }else{
            string tmp = info.trickHelpCount.ToString().Substring(0,1)+'.';
            tmp += info.trickHelpCount.ToString().Substring(1,1)+"kk+";
            trickHelpText.text = tmp;
        }*/
	}

    /*private void PurchaseManager_OnPurchaseConsumable(UnityEngine.Purchasing.PurchaseEventArgs args){
        Debug.Log("You purchase: "+args.purchasedProduct.definition.id);
        if(args.purchasedProduct.definition.id.Equals("buy_money_1")) MoneyBuy1();
        else if(args.purchasedProduct.definition.id.Equals("buy_money_2")) MoneyBuy2();
        else if(args.purchasedProduct.definition.id.Equals("buy_money_3")) MoneyBuy3();
    }
*/

    public void actionEnableTrue(){
        switch (mode)
        {
            case 0: Pause.actionEnableTH = true;
                break;
            case 1: Pause.actionEnableM = true;
                break;
        }
    }

    public void actionEnableFalse(){
        switch (mode)
        {
            case 0: Pause.actionEnableTH = false;
                break;
            case 1: Pause.actionEnableM = false;
                break;
        }
    }

    public void UpdateCount(){
        Debug.Log("UpdateCount()");
        info.Save();
        try{
            Text moneyText = GameObject.Find("money_text").GetComponent<Text>();
            if(info.money < 1000000){
                moneyText.text = info.money.ToString();
            }else{
                string tmp = info.money.ToString().Substring(0,1)+'.';
                tmp += info.money.ToString().Substring(1,1)+"kk+";
                moneyText.text = tmp;
            }
        }catch{Debug.LogWarning("money_text not found");}
        try{
            Text trickHelpText = GameObject.Find("trickHelp_text").GetComponent<Text>();
            if(info.trickHelpCount < 1000000){
                trickHelpText.text = info.trickHelpCount.ToString();
            }else{
                string tmp = info.trickHelpCount.ToString().Substring(0,1)+'.';
                tmp += info.trickHelpCount.ToString().Substring(1,1)+"kk+";
                trickHelpText.text = tmp;
            }
        }catch{Debug.LogWarning("trickHelp_text not found");}
    }
	
	public void Opt(){
        bool isOpen = _animator.GetBool("open");
		_animator.SetBool("open",!isOpen);
		if(info.AudioOn) GameObject.Find("audio_buy_menu").GetComponent<AudioSource>().Play();
	}
	
	public void TrickBuy1(){
		if(info.AudioOn) GameObject.Find("audio_buytrick_button").GetComponent<AudioSource>().Play();
        if(info.money >= trickHelpCost){
            info.money -= trickHelpCost;
            info.trickHelpCount += 1;
            UpdateCount();
        }
	}

	public void TrickBuy5(){
		if(info.AudioOn) GameObject.Find("audio_buytrick_button").GetComponent<AudioSource>().Play();
        if(info.money >= (int)(trickHelpCost*5-(trickHelpCost*5*trickHelpDiscount5))){
            info.money -= (int)(trickHelpCost*5-(trickHelpCost*5*trickHelpDiscount5));
            info.trickHelpCount += 5;
            UpdateCount();
        }
	}

    public void TrickBuy10(){
		if(info.AudioOn) GameObject.Find("audio_buytrick_button").GetComponent<AudioSource>().Play();
        if(info.money >= (int)(trickHelpCost*10-(trickHelpCost*10*trickHelpDiscount10))){
            info.money -= (int)(trickHelpCost*10-(trickHelpCost*10*trickHelpDiscount10));
            info.trickHelpCount += 10;
            UpdateCount();
        }
	}

    public void MoneyBuy1(){
		if(info.AudioOn) GameObject.Find("audio_buymoney_button").GetComponent<AudioSource>().Play();
        info.money+=10000;
        info.Save();
        UpdateCount();
	}
    public void MoneyBuy2(){
		if(info.AudioOn) GameObject.Find("audio_buymoney_button").GetComponent<AudioSource>().Play();
        info.money+=100000;
        info.Save();
        UpdateCount();
	}
    public void MoneyBuy3(){
		if(info.AudioOn) GameObject.Find("audio_buymoney_button").GetComponent<AudioSource>().Play();
        info.money+=1000000;
        info.Save();
        UpdateCount();
    }
}
