using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseBuyMenu : MonoBehaviour
{
	private Animator _animator;
    private int trickHelpCost = 1000;
    private float trickHelpDiscount5 = 0.1f;
    private float trickHelpDiscount10 = 0.15f;

	// Use this for initialization
	public void Start () {
		_animator = gameObject.GetComponent<Animator>();
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

    private void UpdateCount(){
        info.Save();
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
	
	public void Opt(){
        bool isOpen = _animator.GetBool("open");
		_animator.SetBool("open",!isOpen);
		if(info.AudioOn) GameObject.Find("audio_buy_menu").GetComponent<AudioSource>().Play();
	}
	
	public void TrickBuy1(){
		if(info.AudioOn) GameObject.Find("audio_buytrick_button").GetComponent<AudioSource>().Play();
        if(info.money > trickHelpCost){
            info.money -= trickHelpCost;
            info.trickHelpCount += 1;
            UpdateCount();
        }
	}

	public void TrickBuy5(){
		if(info.AudioOn) GameObject.Find("audio_buytrick_button").GetComponent<AudioSource>().Play();
        if(info.money > (int)(trickHelpCost*5-(trickHelpCost*5*trickHelpDiscount5))){
            info.money -= (int)(trickHelpCost*5-(trickHelpCost*5*trickHelpDiscount5));
            info.trickHelpCount += 5;
            UpdateCount();
        }
	}

    public void TrickBuy10(){
		if(info.AudioOn) GameObject.Find("audio_buytrick_button").GetComponent<AudioSource>().Play();
        if(info.money > (int)(trickHelpCost*10-(trickHelpCost*10*trickHelpDiscount10))){
            info.money -= (int)(trickHelpCost*10-(trickHelpCost*10*trickHelpDiscount10));
            info.trickHelpCount += 10;
            UpdateCount();
        }
	}

    public void MoneyBuy1(){
		if(info.AudioOn) GameObject.Find("audio_buymoney_button").GetComponent<AudioSource>().Play();
	}
    public void MoneyBuy2(){
		if(info.AudioOn) GameObject.Find("audio_buymoney_button").GetComponent<AudioSource>().Play();
	}
    public void MoneyBuy3(){
		if(info.AudioOn) GameObject.Find("audio_buymoney_button").GetComponent<AudioSource>().Play();
	}
}
