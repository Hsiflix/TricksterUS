using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    public Text MainText;
    public GameObject button1, button2, button3, buttonDefault;
    public Text text1, text2, text3, textDefault;
    public TheEndStories stories;
    public static int money = 0;

    float textAreaPixel = 720f; //Screen.height*0.661;
    float coefMainText = 1f;
    bool defaultOn = false;
    int count = 0;
    int bestFit = 30;
    bool UpdateOn = false;
    bool isDivision = false;
    string tempText = "";
    int updateCnt = 0;

    //const string text1_ = "Вы забирайте всё добытое золото и потихоньку убегайте с материка. В пути у вас кончается вода и вы решайте пришвартоваться у одного из ближайших островов в поисках питьевой воды.\nПробираясь через зелёные заросли, вы не замечайте ловушки, скрытые в зелёных уголках острова. Вы падайте в какую-то яму метров 4 в глубину. Поднимаясь с земли, вы видите над собой силуэты, закрывающие небо. Один из них швыряет вам верёвку, вы поднимайтесь к ним и вам сразу завязывают глаза и руки, приложив к земле.\n\nВы:\n1) Пытайтесь убежать\n\n2) Идёте  спокойно с незнакомцами";
    //const string text2_ = "Пытайтесь убежать и на вас напрыгивает толпа аборигенов, вы без сознания. Вы просыпайтесь от резкого потока света - вам сняли повязку.\n\nВы:\n\n1) Начинайте смеяться и показывать пальцем на свору маленьких карапузов\n\n2) Спокойно реагируйте, пристально смотря на их острыя копья";
    //const string text4_ = "Показывайте вдаль, надеясь отвлечь карапузов, и убегайте в противоположном направлении, в джунгли. Карапузы поднимают шумиху и издают различные звуки, которые сливаются в одно *УУУУУУ*. Вы постоянно попадайте в какие-то маленькие ловушки, которые цепляются за ваши ноги, перепрыгивайте через ловушки из лиан и добирайтесь до водопада.\n\nВы:\n\n1) Прыгайте в пучину из воды метров 50 в глубину, надеясь выжить.\n\n2) Пытайтесь спрятаться за большим валуном рядом с вами.\n\n3) Вы решайте сдаться карапузам, отдать свою жизнь на волю судьбе, так сказать.";
    //const string text5_ = "Пытайтесь спрятаться за большим валуном рядом с вами. Карапузы подходят к водопаду и смотрят в пучину. Таких злых малышей вы не видели никогда: они начали прыгать на месте и толкать друг друга, парочка свалилась в водопад, остальные побежали их спасать, издавая при этом странные звуки. Вы дождались пока они уйдут и отправились вглубь джунглей. Через долгие два дня мучений вы добирайтесь до корабля. Всё золото на месте. Вы радостный отправляйтесь наконец в долгое плавание на Тортый Фуг. Из подзорной трубы виднеется свора маленьки человечков на берегу, прыгающих и явно кричащих что-то вроде *БУЭЭ* и *ВААА*. Вы улыбайтесь и попивайте мерзкий пиратский пом!";
    //const string text6_ = "You take away all the gold mined and slowly run away from the mainland. On the way, you run out of water and you decide to moor at one of the nearest islands in search of drinking water.\nWhen you go through the green thickets, you do not notice traps hidden in the green corners of the island. You fall into some hole 4 meters deep. Rising from the earth, you see silhouettes covering the sky above you. One of them throws a rope at you, you go up to them and blindfold you and put your hands to the ground.\n\nYou:\n\n1) Try to run away\n\n2)Go quietly with strangers";
    RectTransform m_RectTransform_1, m_RectTransform_2, m_RectTransform_3, m_RectTransform_Default;
    
    void Start()
    {   
        Debug.Log("MONEEEEEEEEY: "+money);
        UpdateOn = false;
        if(money < 10000) stories.scenarioNumber = 0;
        else if(money < 30000) stories.scenarioNumber = 1;
        else if(money < 50000) stories.scenarioNumber = 2;
        else if(money < 100000) stories.scenarioNumber = 3;
        else if(money < 150000) stories.scenarioNumber = 4;
        else if(money < 300000) stories.scenarioNumber = 5;
        else if(money < 600000) stories.scenarioNumber = 6;
        else if(money < 900000) stories.scenarioNumber = 7;
        else if(money < 1200000) stories.scenarioNumber = 8;
        else stories.scenarioNumber = 9;

        tempText = stories.ReturnFirst();
        UpdateText(tempText);
    }

    void Update(){
        if(UpdateOn){
            if(count == 0){
                UpdateOn = false;
            }else if(count == 1){
                UpdateOn = false;
            }else if(count == 2){
                bestFit = Math.Min(text2.cachedTextGenerator.fontSizeUsedForBestFit, text1.cachedTextGenerator.fontSizeUsedForBestFit);
            }else{
                bestFit = Math.Min(Math.Min(text2.cachedTextGenerator.fontSizeUsedForBestFit, text1.cachedTextGenerator.fontSizeUsedForBestFit), text3.cachedTextGenerator.fontSizeUsedForBestFit);
            }
            if(bestFit > 0 && updateCnt > 1){
                if(bestFit > Convert.ToInt32(textDefault.cachedTextGenerator.fontSizeUsedForBestFit*1.5f)){
                    bestFit = Convert.ToInt32(textDefault.cachedTextGenerator.fontSizeUsedForBestFit*1.5f);
                }
                text1.resizeTextForBestFit = false;
                text2.resizeTextForBestFit = false;
                text3.resizeTextForBestFit = false;
                text1.fontSize = bestFit;
                text2.fontSize = bestFit;
                text3.fontSize = bestFit;
                UpdateOn = false;
            }
            updateCnt++;
        }
    }

    public void UpdateText(string temp){
        UpdateOn = false;

        float but1_indexOf = temp.IndexOf("1)");
        float but2_indexOf = temp.IndexOf("2)");
        float but3_indexOf = temp.IndexOf("3)");

        isDivision = true;
        if(but1_indexOf!=-1){
            int lenght = temp.Substring(0, (int)but1_indexOf-1).Length;
            if(lenght>1000){ //2
                string temp1 = temp.Substring(500,200);
                int indexOf1 = temp1.IndexOf("\n");
                int indexOf2 = temp1.IndexOf(". ");
                int indexOf3 = temp1.IndexOf(" ");
                if(indexOf1 != -1){
                    Debug.Log(temp);
                    Debug.Log(500+indexOf1);
                    Debug.Log(temp.Length-1);
                    textDefault.text = temp.Substring(0, 500+indexOf1);
                    tempText = temp.Substring(500+indexOf1, temp.Length-(500+indexOf1));
                }else if(indexOf2 != -1){
                    textDefault.text = temp.Substring(0, 500+indexOf2);
                    tempText = temp.Substring(500+indexOf2, temp.Length-(500+indexOf2));
                }else if(indexOf3 != -1){
                    textDefault.text = temp.Substring(0, 500+indexOf3);
                    tempText = temp.Substring(500+indexOf3, temp.Length-(500+indexOf3));
                }else{
                    isDivision = false;
                    textDefault.text = temp.Substring(0, (int)but1_indexOf-1);
                }
            }else { //1
                isDivision = false;
                textDefault.text = temp.Substring(0, (int)but1_indexOf-1);
            }
        }else{
            int lenght = temp.Length;
            if(lenght>1000){ //2
                string temp1 = temp.Substring(500,200);
                int indexOf1 = temp1.IndexOf("\n");
                int indexOf2 = temp1.IndexOf(". ");
                int indexOf3 = temp1.IndexOf(" ");
                if(indexOf1 != -1){
                    textDefault.text = temp.Substring(0, 500+indexOf1);
                    tempText = temp.Substring(500+indexOf1, temp.Length-(500+indexOf1));
                }else if(indexOf2 != -1){
                    textDefault.text = temp.Substring(0, 500+indexOf2);
                    tempText = temp.Substring(500+indexOf2, temp.Length-(500+indexOf2));
                }else if(indexOf3 != -1){
                    textDefault.text = temp.Substring(0, 500+indexOf3);
                    tempText = temp.Substring(500+indexOf3, temp.Length-(500+indexOf3));
                }else{
                    isDivision = false;
                    textDefault.text = temp;
                }
            }else { //1
                isDivision = false;
                textDefault.text = temp;
            }
        }

        if(!isDivision){
            m_RectTransform_1 = button1.GetComponent<RectTransform>();
            m_RectTransform_2 = button2.GetComponent<RectTransform>();
            m_RectTransform_3 = button3.GetComponent<RectTransform>();
            m_RectTransform_Default = buttonDefault.GetComponent<RectTransform>();

            float butDef_percent = 0;

            if(but1_indexOf == -1){
                defaultOn = true;
                butDef_percent = 0;
                count = 0;
                m_RectTransform_1.offsetMax = new Vector2(m_RectTransform_1.offsetMax.x, -1080f);
                m_RectTransform_1.offsetMin = new Vector2(m_RectTransform_1.offsetMin.x, 0);
                m_RectTransform_2.offsetMax = new Vector2(m_RectTransform_2.offsetMax.x, -1080f);
                m_RectTransform_2.offsetMin = new Vector2(m_RectTransform_2.offsetMin.x, 0);
                m_RectTransform_3.offsetMax = new Vector2(m_RectTransform_3.offsetMax.x, -1080f);
                m_RectTransform_3.offsetMin = new Vector2(m_RectTransform_3.offsetMin.x, 0);
            }else if (but2_indexOf == -1){
                butDef_percent = (float)(1-but1_indexOf/temp.Length)*coefMainText;
                butDef_percent = (float)(butDef_percent<=0.25?0.25:butDef_percent);
                defaultOn = false;
                text1.text = temp.Substring((int)but1_indexOf);
                m_RectTransform_1.offsetMax = new Vector2(m_RectTransform_1.offsetMax.x, (butDef_percent)*textAreaPixel);
                count = 1;
                m_RectTransform_2.offsetMax = new Vector2(m_RectTransform_2.offsetMax.x, -1080f);
                m_RectTransform_2.offsetMin = new Vector2(m_RectTransform_2.offsetMin.x, 0);
                m_RectTransform_3.offsetMax = new Vector2(m_RectTransform_3.offsetMax.x, -1080f);
                m_RectTransform_3.offsetMin = new Vector2(m_RectTransform_3.offsetMin.x, 0);
            }else if (but3_indexOf == -1){
                butDef_percent = (float)(1-but1_indexOf/temp.Length)*coefMainText;
                butDef_percent = (float)(butDef_percent<=0.25?0.25:butDef_percent);
                defaultOn = false;
                
                float coef12 = (but2_indexOf-but1_indexOf)/(temp.Length-but2_indexOf);
                coef12 = (float)(coef12<=0.5?0.667:coef12>=2?0.333:0.5);

                text1.text = temp.Substring((int)but1_indexOf, (int)but2_indexOf-(int)but1_indexOf-2);
                m_RectTransform_1.offsetMax = new Vector2(m_RectTransform_1.offsetMax.x, -(1-butDef_percent)*textAreaPixel);
                m_RectTransform_1.offsetMin = new Vector2(m_RectTransform_1.offsetMin.x, butDef_percent*coef12*textAreaPixel);

                text2.text = temp.Substring((int)but2_indexOf);
                m_RectTransform_2.offsetMax = new Vector2(m_RectTransform_2.offsetMax.x, -(1-butDef_percent)*textAreaPixel - butDef_percent*(1-coef12)*textAreaPixel);
                m_RectTransform_2.offsetMin = new Vector2(m_RectTransform_2.offsetMin.x, 0);
            
                count = 2;
                m_RectTransform_3.offsetMax = new Vector2(m_RectTransform_3.offsetMax.x, -1080f);
                m_RectTransform_3.offsetMin = new Vector2(m_RectTransform_3.offsetMin.x, 0);
            }else{
                butDef_percent = (float)(1-but1_indexOf/temp.Length);
                butDef_percent = (float)(butDef_percent<=0.25?0.25:butDef_percent);
                defaultOn = false;
                
                float coef12 = (but2_indexOf-but1_indexOf)/(but3_indexOf-but2_indexOf);
                coef12 = (float)(coef12<=0.5?0.5:coef12>=2?2:1);

                float coef13 = (but2_indexOf-but1_indexOf)/(temp.Length-but3_indexOf);
                coef13 = (float)(coef13<=0.5?0.5:coef13>=2?2:1);

                float part1 = 0;
                //float part2 = 0;
                float part3 = 0;

                if(coef12 == 0.5){
                    if(coef13 == 0.5){
                        part1 = 1f/5;
                        //part2 = 2f/5;
                        part3 = 2f/5;
                    }else if(coef13 == 2){
                        part1 = 2f/7;
                        //part2 = 4f/7;
                        part3 = 1f/7;
                    }else{
                        part1 = 1f/4;
                        //part2 = 2f/4;
                        part3 = 1f/4;
                    }
                }else if(coef12 == 2){
                    if(coef13 == 0.5){
                        part1 = 2f/7;
                        //part2 = 1f/7;
                        part3 = 4f/7;
                    }else if(coef13 == 2){
                        part1 = 2f/4;
                        //part2 = 1f/4;
                        part3 = 1f/4;
                    }else{
                        part1 = 2f/4;
                        //part2 = 1f/4;
                        part3 = 2f/4;
                    }
                } else{
                    if(coef13 == 0.5){
                        part1 = 1f/4;
                        //part2 = 1f/4;
                        part3 = 2f/4;
                    }else if(coef13 == 2){
                        part1 = 2f/5;
                        //part2 = 2f/5;
                        part3 = 1f/5;
                    }else{
                        part1 = 1f/3;
                        //part2 = 1f/3;
                        part3 = 1f/3;
                    }
                }

                text1.text = temp.Substring((int)but1_indexOf, (int)but2_indexOf-(int)but1_indexOf-2);
                m_RectTransform_1.offsetMax = new Vector2(m_RectTransform_1.offsetMax.x, -(1-butDef_percent)*textAreaPixel);
                m_RectTransform_1.offsetMin = new Vector2(m_RectTransform_1.offsetMin.x, butDef_percent*(1-part1)*textAreaPixel);

                text2.text = temp.Substring((int)but2_indexOf, (int)but3_indexOf-(int)but2_indexOf-2);
                m_RectTransform_2.offsetMax = new Vector2(m_RectTransform_2.offsetMax.x, -(textAreaPixel-butDef_percent*(1-part1)*textAreaPixel));
                m_RectTransform_2.offsetMin = new Vector2(m_RectTransform_2.offsetMin.x, textAreaPixel-(1-butDef_percent)*textAreaPixel - butDef_percent*(1-part3)*textAreaPixel);

                text3.text = temp.Substring((int)but3_indexOf);
                m_RectTransform_3.offsetMax = new Vector2(m_RectTransform_3.offsetMax.x, -(1-butDef_percent)*textAreaPixel - butDef_percent*(1-part3)*textAreaPixel);
                m_RectTransform_3.offsetMin = new Vector2(m_RectTransform_3.offsetMin.x, 0);

                count = 3;
            }

            //Default
            Debug.Log(butDef_percent);
            m_RectTransform_Default.offsetMax = new Vector2(m_RectTransform_Default.offsetMax.x, 0);
            m_RectTransform_Default.offsetMin = new Vector2(m_RectTransform_Default.offsetMin.x, (float)(butDef_percent*textAreaPixel));

            bestFit = 0;
            text1.resizeTextForBestFit = true;
            updateCnt = 0;
            text1.resizeTextForBestFit = true;
            text2.resizeTextForBestFit = true;
            text3.resizeTextForBestFit = true;
            UpdateOn = true;
        }else{
            m_RectTransform_1 = button1.GetComponent<RectTransform>();
            m_RectTransform_2 = button2.GetComponent<RectTransform>();
            m_RectTransform_3 = button3.GetComponent<RectTransform>();
            m_RectTransform_Default = buttonDefault.GetComponent<RectTransform>();
            m_RectTransform_1.offsetMax = new Vector2(m_RectTransform_1.offsetMax.x, -1080f);
            m_RectTransform_1.offsetMin = new Vector2(m_RectTransform_1.offsetMin.x, 0);
            m_RectTransform_2.offsetMax = new Vector2(m_RectTransform_2.offsetMax.x, -1080f);
            m_RectTransform_2.offsetMin = new Vector2(m_RectTransform_2.offsetMin.x, 0);
            m_RectTransform_3.offsetMax = new Vector2(m_RectTransform_3.offsetMax.x, -1080f);
            m_RectTransform_3.offsetMin = new Vector2(m_RectTransform_3.offsetMin.x, 0);
            m_RectTransform_Default.offsetMax = new Vector2(m_RectTransform_Default.offsetMax.x, 0);
            m_RectTransform_Default.offsetMin = new Vector2(m_RectTransform_Default.offsetMin.x, 0);
        }
    }

    public void ButtonDefault(){
        if(isDivision){
            UpdateText(tempText);
            Debug.Log("ButDef");
        }else{
            if(defaultOn){
                SceneManager.LoadScene("Credits");
            }else{
                Debug.Log("Кнопка Default инактивна");
            }
        }
    }
    public void Button1(){
        tempText = stories.Return(1);
        UpdateText(tempText);
        Debug.Log("But1");
    }
    public void Button2(){
        tempText = stories.Return(2);
        UpdateText(tempText);
        Debug.Log("But2");
    }
    public void Button3(){
        tempText = stories.Return(3);
        UpdateText(tempText);
        Debug.Log("But3");
    }
}



/*
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    public Text MainText;
    public GameObject button1, button2, button3, buttonDefault;
    public Text text1, text2, text3, textDefault;
    public TheEndStories stories;

    float textAreaPixel = 720f; //Screen.height*0.661;
    float coefMainText = 1f;
    bool defaultOn = false;
    int count = 0;
    int bestFit = 30;
    bool UpdateOn = false;

    //const string text1_ = "Вы забирайте всё добытое золото и потихоньку убегайте с материка. В пути у вас кончается вода и вы решайте пришвартоваться у одного из ближайших островов в поисках питьевой воды.\nПробираясь через зелёные заросли, вы не замечайте ловушки, скрытые в зелёных уголках острова. Вы падайте в какую-то яму метров 4 в глубину. Поднимаясь с земли, вы видите над собой силуэты, закрывающие небо. Один из них швыряет вам верёвку, вы поднимайтесь к ним и вам сразу завязывают глаза и руки, приложив к земле.\n\nВы:\n1) Пытайтесь убежать\n\n2) Идёте  спокойно с незнакомцами";
    //const string text2_ = "Пытайтесь убежать и на вас напрыгивает толпа аборигенов, вы без сознания. Вы просыпайтесь от резкого потока света - вам сняли повязку.\n\nВы:\n\n1) Начинайте смеяться и показывать пальцем на свору маленьких карапузов\n\n2) Спокойно реагируйте, пристально смотря на их острыя копья";
    //const string text4_ = "Показывайте вдаль, надеясь отвлечь карапузов, и убегайте в противоположном направлении, в джунгли. Карапузы поднимают шумиху и издают различные звуки, которые сливаются в одно *УУУУУУ*. Вы постоянно попадайте в какие-то маленькие ловушки, которые цепляются за ваши ноги, перепрыгивайте через ловушки из лиан и добирайтесь до водопада.\n\nВы:\n\n1) Прыгайте в пучину из воды метров 50 в глубину, надеясь выжить.\n\n2) Пытайтесь спрятаться за большим валуном рядом с вами.\n\n3) Вы решайте сдаться карапузам, отдать свою жизнь на волю судьбе, так сказать.";
    //const string text5_ = "Пытайтесь спрятаться за большим валуном рядом с вами. Карапузы подходят к водопаду и смотрят в пучину. Таких злых малышей вы не видели никогда: они начали прыгать на месте и толкать друг друга, парочка свалилась в водопад, остальные побежали их спасать, издавая при этом странные звуки. Вы дождались пока они уйдут и отправились вглубь джунглей. Через долгие два дня мучений вы добирайтесь до корабля. Всё золото на месте. Вы радостный отправляйтесь наконец в долгое плавание на Тортый Фуг. Из подзорной трубы виднеется свора маленьки человечков на берегу, прыгающих и явно кричащих что-то вроде *БУЭЭ* и *ВААА*. Вы улыбайтесь и попивайте мерзкий пиратский пом!";
    //const string text6_ = "You take away all the gold mined and slowly run away from the mainland. On the way, you run out of water and you decide to moor at one of the nearest islands in search of drinking water.\nWhen you go through the green thickets, you do not notice traps hidden in the green corners of the island. You fall into some hole 4 meters deep. Rising from the earth, you see silhouettes covering the sky above you. One of them throws a rope at you, you go up to them and blindfold you and put your hands to the ground.\n\nYou:\n\n1) Try to run away\n\n2)Go quietly with strangers";
    RectTransform m_RectTransform_1, m_RectTransform_2, m_RectTransform_3, m_RectTransform_Default;
    
    void Start()
    {   
        Debug.Log("MONEEEEEEEEY: "+info.money);
        UpdateOn = false;
        if(info.money < 10000) stories.scenarioNumber = 0;
        else if(info.money < 30000) stories.scenarioNumber = 1;
        else if(info.money < 50000) stories.scenarioNumber = 2;
        else if(info.money < 100000) stories.scenarioNumber = 3;
        else if(info.money < 150000) stories.scenarioNumber = 4;
        else if(info.money < 300000) stories.scenarioNumber = 5;
        else if(info.money < 600000) stories.scenarioNumber = 6;
        else if(info.money < 900000) stories.scenarioNumber = 7;
        else if(info.money < 1200000) stories.scenarioNumber = 8;
        else stories.scenarioNumber = 9;

        info.money = 0;
        info.Save();

        string temp = stories.ReturnFirst();

        UpdateText(temp);
    }

    void Update(){
        if(UpdateOn){
            if(count == 0){
                UpdateOn = false;
            }else if(count == 1){
                UpdateOn = false;
            }else if(count == 2){
                bestFit = Math.Min(text2.cachedTextGenerator.fontSizeUsedForBestFit, text1.cachedTextGenerator.fontSizeUsedForBestFit);
            }else{
                bestFit = Math.Min(Math.Min(text2.cachedTextGenerator.fontSizeUsedForBestFit, text1.cachedTextGenerator.fontSizeUsedForBestFit), text3.cachedTextGenerator.fontSizeUsedForBestFit);
            }
            if(bestFit > 0){
                text1.resizeTextForBestFit = false;
                text1.fontSize = bestFit;
                text2.resizeTextForBestFit = false;
                text2.fontSize = bestFit;
                text3.resizeTextForBestFit = false;
                text3.fontSize = bestFit;
                UpdateOn = false;
            }
        }
    }

    public void UpdateText(string temp){
        UpdateOn = false;

        float but1_indexOf = temp.IndexOf("1)");
        float but2_indexOf = temp.IndexOf("2)");
        float but3_indexOf = temp.IndexOf("3)");

        m_RectTransform_1 = button1.GetComponent<RectTransform>();
        m_RectTransform_2 = button2.GetComponent<RectTransform>();
        m_RectTransform_3 = button3.GetComponent<RectTransform>();
        m_RectTransform_Default = buttonDefault.GetComponent<RectTransform>();

        float butDef_percent = 0;

        if(but1_indexOf == -1){
            defaultOn = true;
            butDef_percent = 0;
            count = 0;
            m_RectTransform_1.offsetMax = new Vector2(m_RectTransform_1.offsetMax.x, -1080f);
            m_RectTransform_1.offsetMin = new Vector2(m_RectTransform_1.offsetMin.x, 0);
            m_RectTransform_2.offsetMax = new Vector2(m_RectTransform_2.offsetMax.x, -1080f);
            m_RectTransform_2.offsetMin = new Vector2(m_RectTransform_2.offsetMin.x, 0);
            m_RectTransform_3.offsetMax = new Vector2(m_RectTransform_3.offsetMax.x, -1080f);
            m_RectTransform_3.offsetMin = new Vector2(m_RectTransform_3.offsetMin.x, 0);
        }else if (but2_indexOf == -1){
            butDef_percent = (float)(1-but1_indexOf/temp.Length)*coefMainText;
            butDef_percent = (float)(butDef_percent<=0.25?0.25:butDef_percent);
            defaultOn = false;
            text1.text = temp.Substring((int)but1_indexOf);
            m_RectTransform_1.offsetMax = new Vector2(m_RectTransform_1.offsetMax.x, (butDef_percent)*textAreaPixel);
            count = 1;
            m_RectTransform_2.offsetMax = new Vector2(m_RectTransform_2.offsetMax.x, -1080f);
            m_RectTransform_2.offsetMin = new Vector2(m_RectTransform_2.offsetMin.x, 0);
            m_RectTransform_3.offsetMax = new Vector2(m_RectTransform_3.offsetMax.x, -1080f);
            m_RectTransform_3.offsetMin = new Vector2(m_RectTransform_3.offsetMin.x, 0);
        }else if (but3_indexOf == -1){
            butDef_percent = (float)(1-but1_indexOf/temp.Length)*coefMainText;
            butDef_percent = (float)(butDef_percent<=0.25?0.25:butDef_percent);
            defaultOn = false;
            
            float coef12 = (but2_indexOf-but1_indexOf)/(temp.Length-but2_indexOf);
            coef12 = (float)(coef12<=0.5?0.667:coef12>=2?0.333:0.5);

            text1.text = temp.Substring((int)but1_indexOf, (int)but2_indexOf-(int)but1_indexOf-2);
            m_RectTransform_1.offsetMax = new Vector2(m_RectTransform_1.offsetMax.x, -(1-butDef_percent)*textAreaPixel);
            m_RectTransform_1.offsetMin = new Vector2(m_RectTransform_1.offsetMin.x, butDef_percent*coef12*textAreaPixel);

            text2.text = temp.Substring((int)but2_indexOf);
            m_RectTransform_2.offsetMax = new Vector2(m_RectTransform_2.offsetMax.x, -(1-butDef_percent)*textAreaPixel - butDef_percent*(1-coef12)*textAreaPixel);
            m_RectTransform_2.offsetMin = new Vector2(m_RectTransform_2.offsetMin.x, 0);
           
            count = 2;
            m_RectTransform_3.offsetMax = new Vector2(m_RectTransform_3.offsetMax.x, -1080f);
            m_RectTransform_3.offsetMin = new Vector2(m_RectTransform_3.offsetMin.x, 0);
        }else{
            butDef_percent = (float)(1-but1_indexOf/temp.Length);
            butDef_percent = (float)(butDef_percent<=0.25?0.25:butDef_percent);
            defaultOn = false;
            
            float coef12 = (but2_indexOf-but1_indexOf)/(but3_indexOf-but2_indexOf);
            coef12 = (float)(coef12<=0.5?0.5:coef12>=2?2:1);

            float coef13 = (but2_indexOf-but1_indexOf)/(temp.Length-but3_indexOf);
            coef13 = (float)(coef13<=0.5?0.5:coef13>=2?2:1);

            float part1 = 0;
            //float part2 = 0;
            float part3 = 0;

            if(coef12 == 0.5){
                if(coef13 == 0.5){
                    part1 = 1f/5;
                    //part2 = 2f/5;
                    part3 = 2f/5;
                }else if(coef13 == 2){
                    part1 = 2f/7;
                    //part2 = 4f/7;
                    part3 = 1f/7;
                }else{
                    part1 = 1f/4;
                    //part2 = 2f/4;
                    part3 = 1f/4;
                }
            }else if(coef12 == 2){
                if(coef13 == 0.5){
                    part1 = 2f/7;
                    //part2 = 1f/7;
                    part3 = 4f/7;
                }else if(coef13 == 2){
                    part1 = 2f/4;
                    //part2 = 1f/4;
                    part3 = 1f/4;
                }else{
                    part1 = 2f/4;
                    //part2 = 1f/4;
                    part3 = 2f/4;
                }
            } else{
                if(coef13 == 0.5){
                    part1 = 1f/4;
                    //part2 = 1f/4;
                    part3 = 2f/4;
                }else if(coef13 == 2){
                    part1 = 2f/5;
                    //part2 = 2f/5;
                    part3 = 1f/5;
                }else{
                    part1 = 1f/3;
                    //part2 = 1f/3;
                    part3 = 1f/3;
                }
            }

            text1.text = temp.Substring((int)but1_indexOf, (int)but2_indexOf-(int)but1_indexOf-2);
            m_RectTransform_1.offsetMax = new Vector2(m_RectTransform_1.offsetMax.x, -(1-butDef_percent)*textAreaPixel);
            m_RectTransform_1.offsetMin = new Vector2(m_RectTransform_1.offsetMin.x, butDef_percent*(1-part1)*textAreaPixel);

            text2.text = temp.Substring((int)but2_indexOf, (int)but3_indexOf-(int)but2_indexOf-2);
            m_RectTransform_2.offsetMax = new Vector2(m_RectTransform_2.offsetMax.x, -(textAreaPixel-butDef_percent*(1-part1)*textAreaPixel));
            m_RectTransform_2.offsetMin = new Vector2(m_RectTransform_2.offsetMin.x, textAreaPixel-(1-butDef_percent)*textAreaPixel - butDef_percent*(1-part3)*textAreaPixel);

            text3.text = temp.Substring((int)but3_indexOf);
            m_RectTransform_3.offsetMax = new Vector2(m_RectTransform_3.offsetMax.x, -(1-butDef_percent)*textAreaPixel - butDef_percent*(1-part3)*textAreaPixel);
            m_RectTransform_3.offsetMin = new Vector2(m_RectTransform_3.offsetMin.x, 0);

            count = 3;
        }

        //Default
        Debug.Log(butDef_percent);
        m_RectTransform_Default.offsetMax = new Vector2(m_RectTransform_Default.offsetMax.x, 0);
        m_RectTransform_Default.offsetMin = new Vector2(m_RectTransform_Default.offsetMin.x, (float)(butDef_percent*textAreaPixel));
        if(but1_indexOf!=-1){
            textDefault.text = temp.Substring(0, (int)but1_indexOf-1);
        }else{
            textDefault.text = temp;
        }

        bestFit = 0;
        UpdateOn = true;
        
    }

    public void ButtonDefault(){
        if(defaultOn){
            SceneManager.LoadScene("Credits");
        }else{
            Debug.Log("Кнопка Default инактивна");
        }
    }
    public void Button1(){
        UpdateText(stories.Return(1));
        Debug.Log("But1");
    }
    public void Button2(){
        UpdateText(stories.Return(2));
        Debug.Log("But2");
    }
    public void Button3(){
        UpdateText(stories.Return(3));
        Debug.Log("But3");
    }
}
*/