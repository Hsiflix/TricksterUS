using System;
using System.Collections.Generic;
using UnityEngine;

public class Texts
{
    private int id = 0;
    public TextUnit tutorial_map, tutorial_location, tutorial_lvl, NoColorDialog, StoryPhrases1, StoryPhrases2, StoryPhrases3;
    private TextUnit current;
    private TextUnit PhrasesEndlessMode1, PhrasesEndlessMode2, PhrasesEndlessMode3, PhrasesEndlessMode4, PhrasesEndlessMode5, 
                     PhrasesEndlessMode6, PhrasesEndlessMode7, PhrasesEndlessMode8, PhrasesEndlessMode20, PhrasesEndlessMode21, PhrasesEndlessMode22;
    private TextUnit PhrasesInRuins, PhrasesWinMenu, PhrasesOnLocation, PhrasesLoseMenu, PhrasesOnLvl, PhrasesChest, PhrasesTrickHouse;
    private TextUnit PhrasesInRuins_1Rr,PhrasesInRuins_2R,PhrasesInRuins_3R,PhrasesInRuins_4R,PhrasesInRuins_1H,PhrasesInRuins_2H,PhrasesInRuins_3H,PhrasesInRuins_1Jr,
                     PhrasesInRuins_2J,PhrasesInRuins_3J,PhrasesInRuins_4J,PhrasesInRuins_1Sr,PhrasesInRuins_2S,PhrasesInRuins_3S,PhrasesInRuins_4S,PhrasesInRuins_1SN,
                     PhrasesInRuins_2SN, PhrasesInRuins_3SN;
    private TextUnit WinMenu001r, WinMenu002, WinMenu003, WinMenu004, WinMenu006, WinMenu007, WinMenu008, WinMenu009, WinMenu010, WinMenu011, WinMenu012, WinMenu013,
                     WinMenu014, WinMenu015, WinMenu016, WinMenu018, WinMenu019, WinMenu022, WinMenu023, WinMenu025, WinMenu027;
    private TextUnit WinMenuChester_002,WinMenuChester_003,WinMenuChester_004,WinMenuChester_005,WinMenuChester_007,WinMenuChester_008,WinMenuChester_009,WinMenuChester_010,
                     WinMenuChester_012,WinMenuChester_013,WinMenuChester_014,WinMenuChester_015,WinMenuChester_016,WinMenuChester_017,WinMenuChester_019,WinMenuChester_020,
                     WinMenuChester_022,WinMenuChester_023,WinMenuChester_025,WinMenuChester_026,WinMenuChester_027,WinMenuChester_028,WinMenuChester_031,WinMenuChester_033,
                     WinMenuChester_034,WinMenu0achieve_r,WinMenu0achieve_002,WinMenu0achieve_004,WinMenu0achieve_005,WinMenu3achieve_r,WinMenu3achieve_003,WinMenu3achieve_005,
                     WinMenu3achieve_006,WinMenu3achieve_007; 
    private TextUnit Location_Jr, Location_Sar, Location_Snr, Location_Hr, Location_Br, Location_J_001, Location_J_002, Location_J_006, Location_Sa_002, Location_Sa_003, 
                     Location_Sa_004, Location_Sa_005, Location_Sn_004, Location_Sn_007, Location_Sn_008, Location_H_003, Location_H_005, Location_H_006;
    private TextUnit Lose_r, Lose_001, Lose_002, Lose_010, Lose_011, Lose_013, Lose_014, Lose_015, Lose_016, Lose_020, Lose_022, Lose_025, Lose_027, Lose_030, Lose_031;
    private TextUnit lvl_001, lvl_002, lvl_003, lvl_004;
    private TextUnit home_r, home_001, home_002, home_004, home_005, home_006, home_008, home_012, home_014, home_015, home_017, home_018, home_020, home_021, home_022, home_023, home_024, home_025, home_026;    
    private TextUnit mapNewRuins;
    private TextUnit AllAchivements;
        
    public Texts(string _name){
        if(_name == "AllAchivements"){
            CreateText_AllAchivements();
        }
        if(_name == "mapNewRuins"){
            CreateText_mapNewRuins();
        }
        if(_name == "tutorial_map"){ 
            CreateText_tutorial_map();
        }
        if(_name == "tutorial_location"){
            CreateText_tutorial_location();
        }
        if(_name == "tutorial_lvl"){
            CreateText_tutorial_lvl();
        }
        if(_name == "NoColorDialog"){
            CreateText_NoColorDialog();
        }
        if(_name == "StoryPhrases1"){
            CreateText_StoryPhrases1();
        }
        if(_name == "StoryPhrases2"){
            CreateText_StoryPhrases2();
        }
        if(_name == "StoryPhrases3"){
            CreateText_StoryPhrases3();
        }
        if(_name == "PhrasesEndlessMode1"){
            CreateText_PhrasesEndlessMode1();
        }
        if(_name == "PhrasesEndlessMode2"){
            CreateText_PhrasesEndlessMode2();
        }
        if(_name == "PhrasesEndlessMode3"){
            CreateText_PhrasesEndlessMode3();
        }
        if(_name == "PhrasesEndlessMode4"){
            CreateText_PhrasesEndlessMode4();
        }
        if(_name == "PhrasesEndlessMode5"){
            CreateText_PhrasesEndlessMode5();
        }
        if(_name == "PhrasesEndlessMode6"){
            CreateText_PhrasesEndlessMode6();
        }
        if(_name == "PhrasesEndlessMode7"){
            CreateText_PhrasesEndlessMode7();
        }
        if(_name == "PhrasesEndlessMode8"){
            CreateText_PhrasesEndlessMode8();
        }
        if(_name == "PhrasesEndlessMode20"){
            CreateText_PhrasesEndlessMode20();
        }
        if(_name == "PhrasesEndlessMode21"){
            CreateText_PhrasesEndlessMode21();
        }
        if(_name == "PhrasesEndlessMode22"){
            CreateText_PhrasesEndlessMode22();
        }
        if(_name == "PhrasesWinMenu"){
            CreateText_PhrasesWinMenu();
        }
        if(_name == "PhrasesOnLocation"){
            CreateText_PhrasesOnLocation();
        }
        if(_name == "PhrasesLoseMenu"){
            CreateText_PhrasesLoseMenu();
        }
        if(_name == "PhrasesOnLvl"){
            CreateText_PhrasesOnLvl();
        }
        if(_name == "PhrasesChest"){
            CreateText_PhrasesChest();
        }
        if(_name == "PhrasesTrickHouse"){
            CreateText_PhrasesTrickHouse();
        }
        if(_name == "PhrasesInRuins_1Rr"){
            CreateText_PhrasesInRuins_1Rr();
        }
        if(_name == "PhrasesInRuins_2R"){
            CreateText_PhrasesInRuins_2R();
        }
        if(_name == "PhrasesInRuins_3R"){
            CreateText_PhrasesInRuins_3R();
        }
        if(_name == "PhrasesInRuins_4R"){
            CreateText_PhrasesInRuins_4R();
        }
        if(_name == "PhrasesInRuins_1H"){
            CreateText_PhrasesInRuins_1H();
        }
        if(_name == "PhrasesInRuins_2H"){
            CreateText_PhrasesInRuins_2H();
        }
        if(_name == "PhrasesInRuins_3H"){
            CreateText_PhrasesInRuins_3H();
        }
        if(_name == "PhrasesInRuins_1Jr"){
            CreateText_PhrasesInRuins_1Jr();
        }
        if(_name == "PhrasesInRuins_2J"){
            CreateText_PhrasesInRuins_2J();
        }
        if(_name == "PhrasesInRuins_3J"){
            CreateText_PhrasesInRuins_3J();
        }
        if(_name == "PhrasesInRuins_4J"){
            CreateText_PhrasesInRuins_4J();
        }
        if(_name == "PhrasesInRuins_1Sr"){
            CreateText_PhrasesInRuins_1Sr();
        }
        if(_name == "PhrasesInRuins_2S"){
            CreateText_PhrasesInRuins_2S();
        }
        if(_name == "PhrasesInRuins_3S"){
            CreateText_PhrasesInRuins_3S();
        }
        if(_name == "PhrasesInRuins_4S"){
            CreateText_PhrasesInRuins_4S();
        }
        if(_name == "PhrasesInRuins_1SN"){
            CreateText_PhrasesInRuins_1SN();
        }
        if(_name == "PhrasesInRuins_2SN"){
            CreateText_PhrasesInRuins_2SN();
        }
        if(_name == "PhrasesInRuins_3SN"){
            CreateText_PhrasesInRuins_3SN();
        }
        if(_name == "WinMenu001r"){
            CreateText_WinMenu001r();
        }
        if(_name == "WinMenu002"){
            CreateText_WinMenu002();
        }
        if(_name == "WinMenu003"){
            CreateText_WinMenu003();
        }
        if(_name == "WinMenu004"){
            CreateText_WinMenu004();
        }
        if(_name == "WinMenu006"){
            CreateText_WinMenu006();
        }
        if(_name == "WinMenu007"){
            CreateText_WinMenu007();
        }
        if(_name == "WinMenu008"){
            CreateText_WinMenu008();
        }
        if(_name == "WinMenu009"){
            CreateText_WinMenu009();
        }
        if(_name == "WinMenu010"){
            CreateText_WinMenu010();
        }
        if(_name == "WinMenu011"){
            CreateText_WinMenu011();
        }
        if(_name == "WinMenu012"){
            CreateText_WinMenu012();
        }
        if(_name == "WinMenu013"){
            CreateText_WinMenu013();
        }
        if(_name == "WinMenu014"){
            CreateText_WinMenu014();
        }
        if(_name == "WinMenu015"){
            CreateText_WinMenu015();
        }
        if(_name == "WinMenu016"){
            CreateText_WinMenu016();
        }
        if(_name == "WinMenu018"){
            CreateText_WinMenu018();
        }
        if(_name == "WinMenu019"){
            CreateText_WinMenu019();
        }
        if(_name == "WinMenu022"){
            CreateText_WinMenu022();
        }
        if(_name == "WinMenu023"){
            CreateText_WinMenu023();
        }
        if(_name == "WinMenu025"){
            CreateText_WinMenu025();
        }
        if(_name == "WinMenu027"){
            CreateText_WinMenu027();
        }
        if(_name == "Location_Jr"){
            CreateText_Location_Jr();
        }
        if(_name == "Location_Sar"){
            CreateText_Location_Sar();
        }
        if(_name == "Location_Snr"){
            CreateText_Location_Snr();
        }
        if(_name == "Location_Hr"){
            CreateText_Location_Hr();
        }
        if(_name == "Location_Br"){
            CreateText_Location_Br();
        }
        if(_name == "Location_J_001"){
            CreateText_Location_J_001();
        }
        if(_name == "Location_J_002"){
            CreateText_Location_J_002();
        }
        if(_name == "Location_J_006"){
            CreateText_Location_J_006();
        }
        if(_name == "Location_Sa_002"){
            CreateText_Location_Sa_002();
        }
        if(_name == "Location_Sa_003"){
            CreateText_Location_Sa_003();
        }
        if(_name == "Location_Sa_004"){
            CreateText_Location_Sa_004();
        }
        if(_name == "Location_Sa_005"){
            CreateText_Location_Sa_005();
        }
        if(_name == "Location_Sn_004"){
            CreateText_Location_Sn_004();
        }
        if(_name == "Location_Sn_007"){
            CreateText_Location_Sn_007();
        }
        if(_name == "Location_Sn_008"){
            CreateText_Location_Sn_008();
        }
        if(_name == "Location_H_003"){
            CreateText_Location_H_003();
        }
        if(_name == "Location_H_005"){
            CreateText_Location_H_005();
        }
        if(_name == "Location_H_006"){
            CreateText_Location_H_006();
        }
        if(_name == "Lose_r"){
            CreateText_Lose_r();
        }
        if(_name == "Lose_001"){
            CreateText_Lose_001();
        }
        if(_name == "Lose_002"){
            CreateText_Lose_002();
        }
        if(_name == "Lose_010"){
            CreateText_Lose_010();
        }
        if(_name == "Lose_011"){
            CreateText_Lose_011();
        }
        if(_name == "Lose_013"){
            CreateText_Lose_013();
        }
        if(_name == "Lose_014"){
            CreateText_Lose_014();
        }
        if(_name == "Lose_015"){
            CreateText_Lose_015();
        }
        if(_name == "Lose_016"){
            CreateText_Lose_016();
        }
        if(_name == "Lose_020"){
            CreateText_Lose_020();
        }
        if(_name == "Lose_022"){
            CreateText_Lose_022();
        }
        if(_name == "Lose_025"){
            CreateText_Lose_025();
        }
        if(_name == "Lose_027"){
            CreateText_Lose_027();
        }
        if(_name == "Lose_030"){
            CreateText_Lose_030();
        }
        if(_name == "Lose_031"){
            CreateText_Lose_031();
        }
        if(_name == "lvl_001"){
            CreateText_lvl_001();
        }
        if(_name == "lvl_002"){
            CreateText_lvl_002();
        }
        if(_name == "lvl_003"){
            CreateText_lvl_003();
        }
        if(_name == "lvl_004"){
            CreateText_lvl_004();
        }
        if(_name == "WinMenuChester_002"){
            CreateText_WinMenuChester_002();
        }
        if(_name == "WinMenuChester_003"){
            CreateText_WinMenuChester_003();
        }
        if(_name == "WinMenuChester_004"){
            CreateText_WinMenuChester_004();
        }
        if(_name == "WinMenuChester_005"){
            CreateText_WinMenuChester_005();
        }
        if(_name == "WinMenuChester_007"){
            CreateText_WinMenuChester_007();
        }
        if(_name == "WinMenuChester_008"){
            CreateText_WinMenuChester_008();
        }
        if(_name == "WinMenuChester_009"){
            CreateText_WinMenuChester_009();
        }
        if(_name == "WinMenuChester_010"){
            CreateText_WinMenuChester_010();
        }
        if(_name == "WinMenuChester_012"){
            CreateText_WinMenuChester_012();
        }
        if(_name == "WinMenuChester_013"){
            CreateText_WinMenuChester_013();
        }
        if(_name == "WinMenuChester_014"){
            CreateText_WinMenuChester_014();
        }
        if(_name == "WinMenuChester_015"){
            CreateText_WinMenuChester_015();
        }
        if(_name == "WinMenuChester_016"){
            CreateText_WinMenuChester_016();
        }
        if(_name == "WinMenuChester_017"){
            CreateText_WinMenuChester_017();
        }
        if(_name == "WinMenuChester_019"){
            CreateText_WinMenuChester_019();
        }
        if(_name == "WinMenuChester_020"){
            CreateText_WinMenuChester_020();
        }
        if(_name == "WinMenuChester_022"){
            CreateText_WinMenuChester_022();
        }
        if(_name == "WinMenuChester_023"){
            CreateText_WinMenuChester_023();
        }
        if(_name == "WinMenuChester_025"){
            CreateText_WinMenuChester_025();
        }
        if(_name == "WinMenuChester_026"){
            CreateText_WinMenuChester_026();
        }
        if(_name == "WinMenuChester_027"){
            CreateText_WinMenuChester_027();
        }
        if(_name == "WinMenuChester_028"){
            CreateText_WinMenuChester_028();
        }
        if(_name == "WinMenuChester_031"){
            CreateText_WinMenuChester_031();
        }
        if(_name == "WinMenuChester_033"){
            CreateText_WinMenuChester_033();
        }
        if(_name == "WinMenuChester_034"){
            CreateText_WinMenuChester_034();
        }
        if(_name == "WinMenu0achieve_r"){
            CreateText_WinMenu0achieve_r();
        }
        if(_name == "WinMenu0achieve_002"){
            CreateText_WinMenu0achieve_002();
        }
        if(_name == "WinMenu0achieve_004"){
            CreateText_WinMenu0achieve_004();
        }
        if(_name == "WinMenu0achieve_005"){
            CreateText_WinMenu0achieve_005();
        }
        if(_name == "WinMenu3achieve_r"){
            CreateText_WinMenu3achieve_r();
        }
        if(_name == "WinMenu3achieve_003"){
            CreateText_WinMenu3achieve_003();
        }
        if(_name == "WinMenu3achieve_005"){
            CreateText_WinMenu3achieve_005();
        }
        if(_name == "WinMenu3achieve_006"){
            CreateText_WinMenu3achieve_006();
        }
        if(_name == "WinMenu3achieve_007"){
            CreateText_WinMenu3achieve_007();
        }
        if(_name == "home_r"){
            CreateText_home_r();
        }
        if(_name == "home_001"){
            CreateText_home_001();
        }
        if(_name == "home_002"){
            CreateText_home_002();
        }
        if(_name == "home_004"){
            CreateText_home_004();
        }
        if(_name == "home_005"){
            CreateText_home_005();
        }
        if(_name == "home_006"){
            CreateText_home_006();
        }
        if(_name == "home_008"){
            CreateText_home_008();
        }
        if(_name == "home_012"){
            CreateText_home_012();
        }
        if(_name == "home_014"){
            CreateText_home_014();
        }
        if(_name == "home_015"){
            CreateText_home_015();
        }
        if(_name == "home_017"){
            CreateText_home_017();
        }
        if(_name == "home_018"){
            CreateText_home_018();
        }
        if(_name == "home_020"){
            CreateText_home_020();
        }
        if(_name == "home_021"){
            CreateText_home_021();
        }
        if(_name == "home_022"){
            CreateText_home_022();
        }
        if(_name == "home_023"){
            CreateText_home_023();
        }
        if(_name == "home_024"){
            CreateText_home_024();
        }
        if(_name == "home_025"){
            CreateText_home_025();
        }
        if(_name == "home_026"){
            CreateText_home_026();
        }
    }

    public TextUnit GetUnit(){
        return current;
    }

    private void CreateText_AllAchivements(){
        AllAchivements = new TextUnit(id, "AllAchivements");
        current = AllAchivements;
        AllAchivements.AddText("","",
        "Yuhuuu, well done! You have completed all levels perfectly! You are now the chosen one, here is your reward! [+500000 coins]",
        "Юхууу, вы молодец! Вы прошли все уровни на отлично! Вы теперь избранный, вот ваша награда! [+500000 монет]");
        AllAchivements.AddText(
        "Yes, the chosen one, of course, AHAHAHAHAHAA",
        "Ну да, избранный, конечно, АХАХАХАХАА",
        "The chosen one!",
        "Избранный!");
        id++;
    }

    private void CreateText_mapNewRuins(){
        mapNewRuins = new TextUnit(id, "mapNewRuins");
        current = mapNewRuins;
        mapNewRuins.AddText("","",
        "Here are the new ruins! Click on the ruins icon to set off for treasures!",
        "Вот, новые руины! Нажми по иконке руин, чтобы отправиться за сокровищами!");
        id++;
    }

    private void CreateText_PhrasesEndlessMode1(){
        PhrasesEndlessMode1 = new TextUnit(id, "PhrasesEndlessMode1");
        current = PhrasesEndlessMode1;
        PhrasesEndlessMode1.AddText("", "",
        "Have you decided to participate in the tournament? It is interesting!",
        "Вы решили поучаствовать в турнире? Это интересно!");
        PhrasesEndlessMode1.AddText("", "",
        "I heard that they give money for it, if you win several times!",
        "Я слышал, что за это дают деньги, если выиграть несколько раз!");
        PhrasesEndlessMode1.AddText("", "",
        "Good luck, everyone plays well here! Well, almost all...",
        "Удачи, тут все хорошо играют! Ну, почти все...");
        id++;
    }
    private void CreateText_PhrasesEndlessMode2(){
        PhrasesEndlessMode2 = new TextUnit(id, "PhrasesEndlessMode2");
        current = PhrasesEndlessMode2;
        PhrasesEndlessMode2.AddText("",
        "",
        "You were good at the last game!",
        "Вы были хороши в последней игре!");
        PhrasesEndlessMode2.AddText("Ha, not really..",
        "Ха, так себе..",
        "He did good!",
        "Он был молодец!");
        id++;
    }
    private void CreateText_PhrasesEndlessMode3(){
        PhrasesEndlessMode3 = new TextUnit(id, "PhrasesEndlessMode3");
        current = PhrasesEndlessMode3; //@SC@
        PhrasesEndlessMode3.AddText("",
        "",
        "@SC@As far as I know, no one has won more than 50 times",
        "@SC@Насколько знаю, никто еще не выигрывал больше 50 раз");
        PhrasesEndlessMode3.AddText("",
        "",
        "@SC@Ha!",
        "@SC@Ха!");
        PhrasesEndlessMode3.AddText("",
        "",
        "@SC@Only Shing Sung reached 50, you are unlikely to get to him",
        "@SC@До 50 доходил лишь Шинг Сун, вряд ли ты до него доберешься");
        PhrasesEndlessMode3.AddText("",
        "",
        "@SC@ha!",
        "@SC@ха!");
        PhrasesEndlessMode3.AddText("Pff, of course, will not reach",
        "Пфф, конечно, не дойдет",
        "Do not listen to them!",
        "Не слушайте их!");
        id++;
    }
    private void CreateText_PhrasesEndlessMode4(){
        PhrasesEndlessMode4 = new TextUnit(id, "PhrasesEndlessMode4");
        current = PhrasesEndlessMode4;
        PhrasesEndlessMode4.AddText("God, how long can you play on this tournament???",
        "Боже, сколько можно проходить этот турнир???",
        "@SC@Endlessly, it is called the 'Tournament of Infinity'",
        "@SC@Бесконечно, он называется 'Турнир бесконечности'");
        PhrasesEndlessMode4.AddText("Mother...",
        "Твою ж...",
        "Shhhh!",
        "Тсссс!");
        id++;
    }
    private void CreateText_PhrasesEndlessMode5(){
        PhrasesEndlessMode5 = new TextUnit(id, "PhrasesEndlessMode5");
        current = PhrasesEndlessMode5;
        PhrasesEndlessMode5.AddText("Lend me a couple of coins for kom later, be a good lad",
        "Подкинь пару монеток мне на компотом, будь другом","","");
        PhrasesEndlessMode5.AddText("Let's let bygones be gone, and so on",
        "Забудем старые обиды, все дела","","");
        PhrasesEndlessMode5.AddText("Otherwise, I'll show!",
        "А то я тебе покажу, где раки зимуют!","","");
        id++;
    }
    private void CreateText_PhrasesEndlessMode6(){
        PhrasesEndlessMode6 = new TextUnit(id, "PhrasesEndlessMode6");
        current = PhrasesEndlessMode6;
        PhrasesEndlessMode6.AddText("Seriously, let's take another monkey",
        "Не ну серьезно, давай возьмем другую мартышку","","");
        PhrasesEndlessMode6.AddText("This one is defective and gambling",
        "Эта бракованная и азартная к тому же",
        "He is cool! We haven’t had better than him yet!",
        "Он классный! Лучше его у нас еще не было!");
        PhrasesEndlessMode6.AddText("Well, yes, the rest were even dumber or more cunning",
        "Ну да, остальные были еще глупее или хитрее","","");
        PhrasesEndlessMode6.AddText("some kicked the bucket, others fled with our gold...",
        "одни откинули ласты, другие убежали с нашим золотом...","","");
        PhrasesEndlessMode6.AddText("But he is such... AAAAA... such... no words..",
        "Но он такой...ААААА...такой...слов нет...","","");
        id++;
    }
    private void CreateText_PhrasesEndlessMode7(){
        PhrasesEndlessMode7 = new TextUnit(id, "PhrasesEndlessMode7");
        current = PhrasesEndlessMode7;
        PhrasesEndlessMode7.AddText("...",
        "...",
        "!!!",
        "!!!");
        PhrasesEndlessMode7.AddText("...",
        "...",
        "@SC@???",
        "@SC@???");
        id++;
    }
    private void CreateText_PhrasesEndlessMode8(){
        PhrasesEndlessMode8 = new TextUnit(id, "PhrasesEndlessMode8");
        current = PhrasesEndlessMode8;
        PhrasesEndlessMode8.AddText("Let's go to the jungle at least",
        "Пошли уже в джунгли хотя бы","","");
        PhrasesEndlessMode8.AddText("I already miss those colorful snakes.",
        "Я уже соскучился по тем разноцветным змеям.",
        "They are poisonous",
        "Они ядовитые");
        PhrasesEndlessMode8.AddText(" And I think why so all the colors have changed, we must take a nap...",
        "А я-то думаю чего так все цвета поменяло, надо вздремнуть...","","");
        id++;
    }
    private void CreateText_PhrasesEndlessMode20(){
        PhrasesEndlessMode20 = new TextUnit(id, "PhrasesEndlessMode20");
        current = PhrasesEndlessMode20;
        PhrasesEndlessMode20.AddText("You have all time in the world? Who will open the chests???",
        "У тебя что дочера времени? Кто сундуки открывать будет???",
        "",
        "");
        PhrasesEndlessMode20.AddText("Tournament? What's next? Will sail away with the money to Tortaya Fuga? I'm watching you!",
        "Турнир? Что дальше? Уплывешь с денежками на Тортую Фугу? Я за тобой слежу!",
        "",
        "");
        PhrasesEndlessMode20.AddText("",
        "",
        "It turns out you can earn money here! Oooh!",
        "Тут оказывается можно деньги заработать! Ууу!");
        PhrasesEndlessMode20.AddText("",
        "",
        "Do not leave! Otherwise then your points will be lost!",
        "Не уходите! А то ваши очки пропадут!");
        PhrasesEndlessMode20.AddText("",
        "",
        "If you try hard enough, you can earn a lot of money!",
        "Если будете стараться, то можете заработать много денег!");
        PhrasesEndlessMode20.AddText("",
        "",
        "Na-na-na, na-na-na, na-na, na, na-na!",
        "На-на-на, на-на-на, на-на, на, на-на!");
        PhrasesEndlessMode20.AddText("",
        "",
        "You can do better, go ahead!",
        "Вы можете лучше, вперед!");
        PhrasesEndlessMode20.AddText("",
        "",
        "@SC@Can you really break the record???",
        "@SC@Неужели вы побьете рекорд???");
        id++;
    }
    private void CreateText_PhrasesEndlessMode21(){
        PhrasesEndlessMode21 = new TextUnit(id, "PhrasesEndlessMode21");
        current = PhrasesEndlessMode21;
        PhrasesEndlessMode21.AddText("","",
        "Next time I will root for you harder!",
        "В следующий раз буду болеть за вас сильнее!");
        PhrasesEndlessMode21.AddText("You shouldn't have come to the tournament, you know",
        "Ну и нечиг было на турнир ходить, знайте ли","","");
        PhrasesEndlessMode21.AddText("","",
        "It is so complicated here!",
        "Как же тут сложно!");
        PhrasesEndlessMode21.AddText("Even Chester is not here, so what have you forgotten here, monkey?",
        "Тут даже Сундукера нет, ну и чего ты тут забыла, мартышка?","","");
        PhrasesEndlessMode21.AddText("","",
        "You'll be lucky next time!",
        "В следующий раз повезет!");
        PhrasesEndlessMode21.AddText("Get back to business, monkey! You are already losing here anyway!",
        "Вернись к делам, мартышка! Ты тут и так проигрываешь!","","");
        PhrasesEndlessMode21.AddText("","",
        "Maybe though a little ginseng?",
        "Может все-таки немного женьшеня?");
        PhrasesEndlessMode21.AddText("Luuul",
        "Лууул","","");
        id++;
    }
    private void CreateText_PhrasesEndlessMode22(){
        PhrasesEndlessMode22 = new TextUnit(id, "PhrasesEndlessMode22");
        current = PhrasesEndlessMode22;
        PhrasesEndlessMode22.AddText("","",
        "Yeeeah!",
        "Ухууу!");
        PhrasesEndlessMode22.AddText("*mumbles*",
        "*бормочет*","","");
        PhrasesEndlessMode22.AddText("","",
        "There you go!",
        "Вот так-то!");
        PhrasesEndlessMode22.AddText("Are you serious?? How? It just was an easy level..",
        "Да ты серьезно?? Как? Это просто был легкий уровень..","","");
        PhrasesEndlessMode22.AddText("","",
        "That’s the spirit!",
        "Так держать!");
        PhrasesEndlessMode22.AddText("Come on!",
        "Да ладно!","","");
        PhrasesEndlessMode22.AddText("","",
        "We’ll break the record soon!",
        "Скоро рекорд побьем!");
        PhrasesEndlessMode22.AddText("You are a cheater!",
        "Да ты читер!","","");
        PhrasesEndlessMode22.AddText("","",
        "A little more and we'll make a lot of money!",
        "Еще немного и заработаем много денег!");
        PhrasesEndlessMode22.AddText("No, well, at least you will lend me a couple of coins on kom, will you, my old friend?",
        "Не, ну по крайней мере ты мне кинешь пару монеток на пом, не так ли, мой старый друг?","","");
        PhrasesEndlessMode22.AddText("","",
        "Well done! You did well!",
        "Молодец! Вы молодец!");
        id++;
    }
    private void CreateText_PhrasesInRuins_1Rr(){
        PhrasesInRuins_1Rr = new TextUnit(id, "PhrasesInRuins_1Rr");
        current = PhrasesInRuins_1Rr;
        PhrasesInRuins_1Rr.AddText("","",
        "Ooh, such a place! We have not been here yet!",
        "Ууу, вот это место! Мы здесь еще не были!");
        PhrasesInRuins_1Rr.AddText("","",
        "Such antiquities! Wow!",
        "Такие древности! Ух!");
        id++;
    }
    private void CreateText_PhrasesInRuins_2R(){
        PhrasesInRuins_2R = new TextUnit(id, "PhrasesInRuins_2R");
        current = PhrasesInRuins_2R;
        PhrasesInRuins_2R.AddText("Why did you bring this cat here, huh??",
        "Ты зачем принес сюда этого кота, а??",
        "","");
        PhrasesInRuins_2R.AddText("He already scratched me twice! lamn monkey...",
        "Он меня уже два раза поцарапал! Чертова мартышка...",
        "","");
        id++;
    }
    private void CreateText_PhrasesInRuins_3R(){
        PhrasesInRuins_3R = new TextUnit(id, "PhrasesInRuins_3R");
        current = PhrasesInRuins_3R;
        PhrasesInRuins_3R.AddText("So, another five minutes and I return home to drink sweet kom!",
        "Так, еще пять минут и я возвращаюсь домой пить сладкий пом!",
        "","");
        PhrasesInRuins_3R.AddText("Faster, monkey!",
        "Быстрее, мартышка!",
        "","");
        id++;
    }
    private void CreateText_PhrasesInRuins_4R(){
        PhrasesInRuins_4R = new TextUnit(id, "PhrasesInRuins_4R");
        current = PhrasesInRuins_4R;
        PhrasesInRuins_4R.AddText("","",
        "So many bones!",
        "Столько костей!");
        PhrasesInRuins_4R.AddText("","",
        "@SC@Do not step on my relatives! They still feel everything!",
        "@SC@Не наступайте на моих сородичей! Они все еще все чувствуют!");
        PhrasesInRuins_4R.AddText("","",
        "@SC@Ha!",
        "@SC@Ха!");
        PhrasesInRuins_4R.AddText("Oh!",
        "Ой!","","");
        id++;
    }
    private void CreateText_PhrasesInRuins_1H(){
        PhrasesInRuins_1H = new TextUnit(id, "PhrasesInRuins_1H");
        current = PhrasesInRuins_1H;
        PhrasesInRuins_1H.AddText("","",
        "Here's a hint if you can’t get through :)",
        "Вот вам подсказку, если не можете пройти :)");
        PhrasesInRuins_1H.AddText("Of course he can't, I've solved the puzzle long time ago",
        "Да куда этой мартышке, я уже давно все разгадал",
        "You can still try to get through by yourself",
        "Все еще можете попробовать пройти сами");
        PhrasesInRuins_1H.AddText("Be quiet! Let the monkey think",
        "Так, тихо! Дай мартышке подумать","","");
        PhrasesInRuins_1H.AddText("We need him to get the k... khhm... gold, emeralds, diamonds!",
        "Нам нужно, чтобы он добыл кл...кхкх..золото, изумруды, бриллианты!",
        "You're lying",
        "Врешь ты");
        id++;
    }
    private void CreateText_PhrasesInRuins_2H(){
        PhrasesInRuins_2H = new TextUnit(id, "PhrasesInRuins_2H");
        current = PhrasesInRuins_2H;
        PhrasesInRuins_2H.AddText("Here! Take your hint, just solve it faster, jeez",
        "На! Лови свою подсказку, только давай быстрее уже разгадывай","","");
        PhrasesInRuins_2H.AddText("We're all waiting here sooo long...",
        "А то мы тут все ждем!",
        "Don't rush him, Wulf!",
        "Не торопи его, Вульф!");
        PhrasesInRuins_2H.AddText("Oh.. Monkey and her assistant - a gnome",
        "Ох..Мартышка и ее ассистент – гном",
        "You're a chool! We are not gnomes",
        "Ты цурак! Мы не гномы");
        PhrasesInRuins_2H.AddText("",
        "",
        "We are tricksters!!!",
        "Мы трикстеры!!!");
        PhrasesInRuins_2H.AddText("Me - yes, and you are a dwarf-kiss-up",
        "Я - да, а ты подлиза-гном",
        "...",
        "...");
        id++;
    }
    private void CreateText_PhrasesInRuins_3H(){
        PhrasesInRuins_3H = new TextUnit(id, "PhrasesInRuins_3H");
        current = PhrasesInRuins_3H;
        PhrasesInRuins_3H.AddText("Come on, come on, just a little bit is left, for heck's sake!",
        "Давай-давай, немного осталось, черт побери!",
        "Here is a hint for you!",
        "Вот вам подсказку!");
        id++;
    }
    private void CreateText_PhrasesInRuins_1Jr(){
        PhrasesInRuins_1Jr = new TextUnit(id, "PhrasesInRuins_1Jr");
        current = PhrasesInRuins_1Jr;
        PhrasesInRuins_1Jr.AddText("","",
        "What music! You have a talent!",
        "Какая музыка! У вас талант!");
        PhrasesInRuins_1Jr.AddText("","",
        "Mmmm, great",
        "Мммм, прекрасно");
        PhrasesInRuins_1Jr.AddText("","",
        "Wow, lots of different signs, awesome!",
        "Ого, какие знаки всякие, класс!");
        id++;
    }
    private void CreateText_PhrasesInRuins_2J(){
        PhrasesInRuins_2J = new TextUnit(id, "PhrasesInRuins_2J");
        current = PhrasesInRuins_2J;
        PhrasesInRuins_2J.AddText("Ugh, it's so damp in here!",
        "Тьфу ты, сыро-то как!","","");
        PhrasesInRuins_2J.AddText("Let's go back to the island, Wunsch",
        "Давай вернемся обратно на остров, Вунш","","");
        PhrasesInRuins_2J.AddText("I'm afraid of enclosed spaces",
        "Я боюсь замкнутых пространств",
        "It was cold in the basement of the castle...",
        "В подвале замка было холодно...");
        PhrasesInRuins_2J.AddText("Shhh! Are you crazy, duruktuktuk?",
        "Тссс! Ты вообще с ума сошел, дуруктуктук?","","");
        PhrasesInRuins_2J.AddText("What if he hears us?",
        "А вдруг он услышит?",
        "Oh! Sorry...",
        "Ой! Прости...");
        PhrasesInRuins_2J.AddText("*whisper*",
        "*шепотом*",
        "Oh! Sorry...",
        "Ой! Прости...");
        PhrasesInRuins_2J.AddText("Gnevglaz will forgive!",
        "Гневглаз простит!","","");
        id++;
    }
    private void CreateText_PhrasesInRuins_3J(){
        PhrasesInRuins_3J = new TextUnit(id, "PhrasesInRuins_3J");
        current = PhrasesInRuins_3J;
        PhrasesInRuins_3J.AddText("Stop it!",
        "Прекрати!","","");
        PhrasesInRuins_3J.AddText("Stop banging on those lamn drums!",
        "Прекрати стучать по этим чертовым барабанам!",
        "@SC@And on the skull too! Ha!",
        "@SC@И по черепу тоже! Ха!");
        id++;
    }
    private void CreateText_PhrasesInRuins_4J(){
        PhrasesInRuins_4J = new TextUnit(id, "PhrasesInRuins_4J");
        current = PhrasesInRuins_4J;
        PhrasesInRuins_4J.AddText("","",
        "I heard stories that the aborigines who lived here were the wildest of all",
        "Я слышал истории, что аборигены жившие тут были самыми дикими из всех");
        PhrasesInRuins_4J.AddText("","",
        "That's why the biggest amount of bones is here",
        "Поэтому тут больше всего костей");
        PhrasesInRuins_4J.AddText("","",
        "@SC@Ha! I confirm!",
        "@SC@Ха! Подтверждаю!");
        PhrasesInRuins_4J.AddText("","",
        "@SC@These were bastardest chads, there was no way to get rid of them, ha!",
        "@SC@Эти были еще теми чадами, от них было не отвязаться, ха!");
        id++;
    }
    private void CreateText_PhrasesInRuins_1Sr(){
        PhrasesInRuins_1Sr = new TextUnit(id, "PhrasesInRuins_1Sr");
        current = PhrasesInRuins_1Sr;
        PhrasesInRuins_1Sr.AddText("","",
        "Ooooh, Murka is painted here on the walls for some reason!",
        "Ууу, тут на стенах Мурка нарисована зачем-то!");
        PhrasesInRuins_1Sr.AddText("There it's damp, here it's dry, what was wrong with these aborigines....",
        "Там сыро, тут сухо, да что было не так с этими аборигенами....","","");
        PhrasesInRuins_1Sr.AddText("Oh come on! Even the kitten already have cracked it for sure!",
        "Ой да ладно! До этого даже эта котяра уже доперла по-любому!",
        "Oh, levers, they are most likely needed to solve the riddle!",
        "О, рычаги, они скорее всего нужны для решения загадки!");
        id++;
    }
    private void CreateText_PhrasesInRuins_2S(){
        PhrasesInRuins_2S = new TextUnit(id, "PhrasesInRuins_2S");
        current = PhrasesInRuins_2S;
        PhrasesInRuins_2S.AddText("God, monkey, can’t you see?? It is obvious!",
        "Боже, мартышка, ну ты не видишь?? Это же очевидно!","","");
        PhrasesInRuins_2S.AddText("The lights turn on when you press the levers in the correct order!!!!",
        "Лампочки загораются, когда ты в правильном порядке нажимаешь на рычаги!!!!","","");
        PhrasesInRuins_2S.AddText("How can you not see this, ohhhh....",
        "Как можно этого не видеть, охххх....","","");
        id++;
    }
    private void CreateText_PhrasesInRuins_3S(){
        PhrasesInRuins_3S = new TextUnit(id, "PhrasesInRuins_3S");
        current = PhrasesInRuins_3S;
        PhrasesInRuins_3S.AddText("Come on, come on, faster, I'm tired of looking at these cats on the walls",
        "Давай-давай, быстрее, мне надоело смотреть на этих котов на стенах","","");
        PhrasesInRuins_3S.AddText("*Murka bit Wolfe*",
        "*Мурка укусила Вульфа*","","");
        PhrasesInRuins_3S.AddText("Oh, oh you're a creature! I'll show you!",
        "Ай, ах ты существо! Ну я тебе покажу!","","");
        PhrasesInRuins_3S.AddText("*Bit again*",
        "*Снова укусила*","","");
        PhrasesInRuins_3S.AddText("And, wait-wait, okay, hairy creature, a truce, a truce",
        "А, стой-стой, ладно, существо волосатое, перемирие","","");
        PhrasesInRuins_3S.AddText("But this is only for the monkey and gold!",
        "Но это только ради мартышки и золота!","","");
        id++;
    }
    private void CreateText_PhrasesInRuins_4S(){
        PhrasesInRuins_4S = new TextUnit(id, "PhrasesInRuins_4S");
        current = PhrasesInRuins_4S;
        PhrasesInRuins_4S.AddText("","",
        "System of levers!",
        "Система рычагов!");
        PhrasesInRuins_4S.AddText("","",
        "They say that the aborigines who lived here were the smartest",
        "Говорят, аборигены жившие здесь были самыми умными");
        PhrasesInRuins_4S.AddText("*yawns*",
        "*зевает*",
        "Nobody could get ahead of them!",
        "Их никто не мог опередить!");
        PhrasesInRuins_4S.AddText("Can you talk even more boring?",
        "А можешь еще скучнее рассказывать?","","");
        PhrasesInRuins_4S.AddText("Maybe I’ll fall asleep at last",
        "Может, усну наконец","","");
        PhrasesInRuins_4S.AddText("Otherwise the monkey seems to have liked to solve this “difficult puzzle”...",
        "А то мартышке похоже понравилось решать эту “сложнейшую головомку”...","","");
        id++;
    }
    private void CreateText_PhrasesInRuins_1SN(){
        PhrasesInRuins_1SN = new TextUnit(id, "PhrasesInRuins_1SN");
        current = PhrasesInRuins_1SN;
        PhrasesInRuins_1SN.AddText("Brrrrr, c-c-cooold!",
        "Бррррр, х-х-холодно!",
        "I had to take warm linings, I told you, chool",
        "Надо было брать теплые подкладки, я тебе говорил, цурачок");
        PhrasesInRuins_1SN.AddText("S-s-shut up! Decide faster, m-m-m-monkey!",
        "З-з-заткнись! Решай быстрее, м-м-м-мартышка!","","");
        id++;
    }
    private void CreateText_PhrasesInRuins_2SN(){
        PhrasesInRuins_2SN = new TextUnit(id, "PhrasesInRuins_2SN");
        current = PhrasesInRuins_2SN;
        PhrasesInRuins_2SN.AddText("","",
        "Take your time, this is probably a very smart system",
        "Не торопитесь, здесь, наверно, очень тонкая система!");
        PhrasesInRuins_2SN.AddText("","",
        "There is little information about the strong people",
        "Про сильный народ мало информации");
        PhrasesInRuins_2SN.AddText("","",
        "I only know that they were the most cold-blooded of all",
        "Знаю лишь то, что они были самыми хладнокровными из всех");
        PhrasesInRuins_2SN.AddText("NO WAY, S-S-S-SERIOUSLY????",
        "ДА ЛАДНО, БЛИН, СЕР-Р-Р-РЬЕЗНО????","","");
        id++;
    }
    private void CreateText_PhrasesInRuins_3SN(){
        PhrasesInRuins_3SN = new TextUnit(id, "PhrasesInRuins_3SN");
        current = PhrasesInRuins_3SN;
        PhrasesInRuins_3SN.AddText("Can we make a fur coat out of it?",
        "Мож-ж-жет сделаем шубку из нее?",
        "Poor murka, she is cold",
        "Бедная мурка, ей холодно");
        PhrasesInRuins_3SN.AddText("Because here is a more important person f-f-freezes!",
        "А то тут поважнее персона м-м-мерзнет вообще-то!","","");
        id++;
    }
    private void CreateText_PhrasesWinMenu(){
        PhrasesWinMenu = new TextUnit(id, "PhrasesWinMenu");
        current = PhrasesWinMenu;
        
        id++;
    }
    private void CreateText_PhrasesOnLocation(){
        PhrasesOnLocation = new TextUnit(id, "PhrasesOnLocation");
        current = PhrasesOnLocation;
        
        id++;
    }
    private void CreateText_PhrasesLoseMenu(){
        PhrasesLoseMenu = new TextUnit(id, "PhrasesLoseMenu");
        current = PhrasesLoseMenu;
        
        id++;
    }
    private void CreateText_PhrasesOnLvl(){
        PhrasesOnLvl = new TextUnit(id, "PhrasesOnLvl");
        current = PhrasesOnLvl;
        
        id++;
    }
    private void CreateText_PhrasesChest(){
        PhrasesChest = new TextUnit(id, "PhrasesChest");
        current = PhrasesChest;
        
        id++;
    }
    private void CreateText_PhrasesTrickHouse(){
        PhrasesTrickHouse = new TextUnit(id, "PhrasesTrickHouse");
        current = PhrasesTrickHouse;
        
        id++;
    }

    private void CreateText_tutorial_map(){
        tutorial_map = new TextUnit(id, "tutorial_map");
        current = tutorial_map;
        tutorial_map.AddText("Hello! Click on the circle on the map to begin the training level if you wish!"
        ,"Привет! Нажми на кружок на карте, чтобы начать обучающий уровень, если хочешь!");
        id++;
    }

    private void CreateText_tutorial_location(){
        tutorial_location = new TextUnit(id, "tutorial_location");
        current = tutorial_location;
        tutorial_location.AddText("This is a tutorial!"
        ,"Это обучающий уровень!");
        tutorial_location.AddText("You need to click on this chest"
        ,"Тебе нужно нажать на этот сундук");
        id++;
    }

    private void CreateText_tutorial_lvl(){
        tutorial_lvl = new TextUnit(id, "tutorial_lvl");
        current = tutorial_lvl;
        tutorial_lvl.AddText("Hello again!"
        ,"Снова привет!");
        tutorial_lvl.AddText("You need all the balls to be that color"
        ,"Тебе нужно, чтобы все шарики были такого цвета.");
        tutorial_lvl.AddText("To change the color of other balls, you need to click on the ball of your color..."
        ,"Чтобы поменять цвет других шариков, нужно нажать на шарик своего цвета...");
        tutorial_lvl.AddText("To change the color of other balls, you need to click on the ball of your color..."
        ,"Чтобы поменять цвет других шариков, нужно нажать на шарик своего цвета...");
        tutorial_lvl.AddText("Yes, just poke at your ball, duruktuktuk, until it clings to others"
        ,"Да просто тыкни по своему шарику, дуруктуктук, пока он не зацепится за другие.");
        tutorial_lvl.AddText("Poke!"
        ,"Тыкни!");
        tutorial_lvl.AddText("And so poke all your balls until you win! That's all, let's get out from here!!"
        ,"И так тыкай на все свои шарики, пока не выиграешь! Всё, пошли отсюда!");
        tutorial_lvl.AddText("If it becomes difficult, you can click on this button if you give a couple of coins in the pause menu."
        ,"Если станет сложно, можешь нажать на эту кнопку, если дашь пару монеток в меню паузы.");
        id++;
    }

    private void CreateText_NoColorDialog(){
        NoColorDialog = new TextUnit(id, "NoColorDialog");
        current = NoColorDialog;
        NoColorDialog.AddText("Your ball is not there, you must click on the restart button!"
        ,"Вашего шарика нет, надо нажать на кнопку перезапуска уровня!"
        ,"Ha! Loser! Your ball is gone, duruktuktuk"
        ,"Ха! Лузер! Твоего шарика нет, дуруктуктук");
        NoColorDialog.AddText("Oh no! Your ball is gone! Click on the restart button to get a new one!"
        ,"О нет! Шарик ваш пропал! Нажмите на кнопку перезапуска, чтобы получить новый!"
        ,"AHAHAHAH! There is no ball of his, poor monkey!"
        ,"АХАХАХАХ! Шарика нет его, бедняжка!");
        NoColorDialog.AddText("Ahhhhh! There is no ball! Click on the restart button to get it!"
        ,"Аааааа! Шарика нет! Нажмите на кнопку перезапуска, чтобы получить его!"
        ,"OHOHOHO!!!! NO BALL!!! HAHAHAHA"
        ,"ОХОХОХОХО!!!! НЕТ ШАРИКА!!! ХАХАХАХА");
        NoColorDialog.AddText("No! There is no ball! There is no way to go without it!"
        ,"Нет! Шарика нет! Без него не пройти!"
        ,"duruktuktuk! There is no ball! Come on, faster, I'm tired of hanging around here!"
        ,"дуруктуктук! Шарика нет! Давай быстрее, мне надоело тут торчать");
        id++;
    }

    private void CreateText_StoryPhrases1(){
        StoryPhrases1 = new TextUnit(id, "StoryPhrases1");
        StoryPhrases1.AddText("For the first time! For the first time, I have to praise you, monkey!"
        ,"Впервые! Впервые я обязан тебя похвалить, мартышка!");
        StoryPhrases1.AddText("You're doing good! Don’t look at me like that, yes, sometimes I am a trickster too..",
        "Ты молодец! Не смотри на меня так, да, я тоже иногда бываю трикстером..",
        "Only two left!",
        "Осталось всего два!");
        StoryPhrases1.AddText("Be quiet, tuktuk! Haha, don’t pay attention, he’s just a chool"
        ,"Молчи, туктук! Хаха, не обращай внимания, он просто цурачок");
        StoryPhrases1.AddText("In childhood he fell out of the crib and here we are.. you have to endure, what else to do..",
        "В детстве упал из кроватки и все.. приходится терпеть, что поделать..",
        "But we need these keys..."
        ,"Но нам нужны эти ключи...");
        StoryPhrases1.AddText("Oh.. well, you are an idiot.. He means that we need these keys to open the door to the last ruins!"
        ,"Ох.. ну ты и идиот.. Он имеет в виду, что нам нужны эти ключи, чтобы открыть дверь в последние руины!");
        StoryPhrases1.AddText("To get the biggest treasure! You have never seen such wealth! There are legends about this place! For which we do not have time, let's go, monkey.",
        "Чтобы получить самое большое сокровище! Таких богатств  ты еще не видел! Об этом месте ходят легенды! На которые у нас нет времени, все пошли, мартышка.");
        current = StoryPhrases1;
        id++;
    }

    private void CreateText_StoryPhrases2(){
        StoryPhrases2 = new TextUnit(id, "StoryPhrases2");
        current = StoryPhrases2;
        StoryPhrases2.AddText("Yeeeah, well done! One step closer to great treasures!"
        ,"Ухуууу, молодец! Еще на шаг ближе к большим сокровищам!");
        StoryPhrases2.AddText("A little more and I will stop calling you names, monkey!"
        ,"Еще немного и я перестану тебя обзывать, мартышка!"
        ,"@SC@Who are you kidding, dwarf?"
        ,"@SC@Кого ты обманываешь, гном?");
        StoryPhrases2.AddText("I AM NOT DWARF! I am a TRIXTER! TRIXTER!"
        ,"Я НЕ ГНОМ! Я ТРИКСТЕР! ТРИКСТЕР!"
        ,"@SC@Who are you kidding, dwarf?"
        ,"@SC@Кого ты обманываешь, гном?");
        StoryPhrases2.AddText("You are lucky that you have stiff skin and that I have incredibly sensitive hands!",
        "Тебе повезло, что у тебя жесткая кожа и что у меня невероятно чувствительные руки!");
        id++;
    }

    private void CreateText_StoryPhrases3(){
        StoryPhrases3 = new TextUnit(id, "StoryPhrases3");
        current = StoryPhrases3;
        StoryPhrases3.AddText("Yes! Yes! YES! At last! At last!! Wunsh! Take the last key! Faster!"
        ,"Да! Да! ДА! Наконец-то! Наконец-то!! Вунш! Бери последний ключ! Быстрее!");
        StoryPhrases3.AddText("",""
        ,"Sorry, sir, but we really need these keys. Forgive me for deceiving you, that there were no great treasures, the Kikings were not the richest people..."
        ,"Простите, господин, но нам правда очень нужны эти ключи. Простите, что обманули вас, что тут не было больших сокровищ, кикинги были не самым богатым народом...");
        StoryPhrases3.AddText("Stop chatting with him! Let's get out! Bye-bye, monkey! You were insanely plupupid, hahahahahh!"
        ,"Хватит болтать с ним! Валим! Прошай, мартышка! Ты была безумно крулупой, хахахахахх!"
        ,"Farewell! Good luck to you!"
        ,"Прощайте! Удачи вам!");
        id++;
    }

    private void CreateText_WinMenu001r(){
        WinMenu001r = new TextUnit(id, "WinMenu001r");
        current = WinMenu001r;
        WinMenu001r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "You did good! Keep it up!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Вы молодец! Так держать!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu001r.AddText(
            "You are a chool anyway!",//Злой трикстер ENG
            "Ты все равно пулупец!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu001r.AddText(
            "Would be better if you lost, we would hear firework...",//Злой трикстер ENG
            "Лучше б проиграл, послушали бы феерверк...",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu001r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "You did great!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Вы молодец!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
        WinMenu001r.AddText(
            "Wake me up when this one loses",//Злой трикстер ENG
            "Разбудите меня, когда этот вот проиграет",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu001r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Yeeeah! Congratulations!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Ухуууу! Поздравляю!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu001r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "You are almost there! Keep it up!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Вы почти у цели! Так держать!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu001r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Ha! Won! No way! In my time, we did it faster!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ха! Выиграл! Неужели! В мое время мы это быстрее делали!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu001r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Ha!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ха!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu001r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Mmmm... Won. Not bad, not bad",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Мммм... Выиграл. Неплохо-неплохо" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu001r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Could have finished faster, we've had a nap here already",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Мог бы и побыстрее закончить, мы тут уже поспать успели" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu001r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Oh god, have you really won..oooh..cool",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@О, боже, неужели ты выиграл..уууу..клёво" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu001r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Hm ... so sleepy. It's probably because of your slow playing",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Хм...чё-т сонливо. Это наверное от того, как медленно ты играешь" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu001r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Heck! You won again!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Чёрт! Ты опять выиграл!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu001r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Nooooooooooooo!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Нееееееееееееееееет!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu001r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Jack Sparrow! AAA. I just said it, just said it",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Джек Воробей! ААА. Я просто это сказал, просто сказал" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu002(){
        WinMenu002 = new TextUnit(id, "WinMenu002");
        current = WinMenu002;
        WinMenu002.AddText(
            "Oh, you passed the level",//Злой трикстер ENG
            "О, ты прошел уровень.",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu002.AddText(
            "Even my grandmother passed him, heh, I mean...",//Злой трикстер ENG
            "Даже моя бабка его проходила, хех, в смысле...",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu002.AddText(
            "Keep it up, you did good! *whisper* no",//Злой трикстер ENG
            "Так держать, ты молодец! *шепотом* нет",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu003(){
        WinMenu003 = new TextUnit(id, "WinMenu003");
        current = WinMenu003;
        WinMenu003.AddText(
            "Ha, are you kidding??",//Злой трикстер ENG
            "Ха, ты шутишь??",//Злой трикстер RUS
            "You are so smart! I would never pass this level!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Вы такой умный! Я бы никогда не прошел этот уровень!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu003.AddText(
            "Yes, I can pass it with my eyes closed",//Злой трикстер ENG
            "Да я могу его пройти с закрытыми глазами",//Злой трикстер RUS
            "So many mechanisms...",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Столько механизмов..." //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu003.AddText(
            "it will be more interesting further, ahaha!!!",//Злой трикстер ENG
            "вот дальше будет интереснее, ахаха!!!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu004(){
        WinMenu004 = new TextUnit(id, "WinMenu004");
        current = WinMenu004;
        WinMenu004.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Yes, you won! It remains only 10..15..30...",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Да, вы победили! Осталось всего 10..15..30..." //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu004.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "I do not count very well, but there are very few levels left",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "я не очень хорошо считаю, но осталось совсем немного уровней" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu004.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "..probably..",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "..наверно.." //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu006(){
        WinMenu006 = new TextUnit(id, "WinMenu006");
        current = WinMenu006;
        WinMenu006.AddText(
            "Oh look at him, he won! Serve bread and salt??",//Злой трикстер ENG
            "О, смотрите на него, он победил! Хлеб с солью подать??",//Злой трикстер RUS
            "He is a good lad, do not offend him, Wulf",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Он хороший, не обижай его, Вульф" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu006.AddText(
            "Hotshot...",//Злой трикстер ENG
            "Выпендрежник...",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu006.AddText(
            "He is a kadder, that’s who he is! Can we find another monkey?",//Злой трикстер ENG
            "Палдюка он, вот кто он! Может найдем другую мартышку?",//Злой трикстер RUS
            "Ohhh..",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Охх.." //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu007(){
        WinMenu007 = new TextUnit(id, "WinMenu007");
        current = WinMenu007;
        WinMenu007.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "I heard that if you collect those bugs",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Я слышал, что если собирать тех жучков" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, наприм��р "@SC@Привет!"
        );
        WinMenu007.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "you can sell them in distant lands!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "можно продать их в дальних землях! " //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu008(){
        WinMenu008 = new TextUnit(id, "WinMenu008");
        current = WinMenu008;
        WinMenu008.AddText(
            "Ye-ye, I won once! It doesn’t mean anything",//Злой трикстер ENG
            "Да-да, разок выиграл! Это ничего не значит",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu008.AddText(
            "there are many more chests ahead!",//Злой трикстер ENG
            "еще много сундуков впереди!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu009(){
        WinMenu009 = new TextUnit(id, "WinMenu009");
        current = WinMenu009;
        WinMenu009.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "How far have we come! Let's get all the gold in the world!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Как далеко мы зашли! Давайте добудем все золото на свете!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu009.AddText(
            "'with your ability to open locks', pff, seneak ..",//Злой трикстер ENG
            "'с вашим умением открывать замки', пфф, подкиза..",//Злой трикстер RUS
            "With your ability to open locks, it will be easy!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "С вашим умением открывать замки это будет легко! " //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu010(){
        WinMenu010 = new TextUnit(id, "WinMenu010");
        current = WinMenu010;
        WinMenu010.AddText(
            "Sometimes it seems that we have different mothers...",//Злой трикстер ENG
            "Иногда мне кажется, что у нас разные мамы...",//Злой трикстер RUS
            "Ooooh, you won, we won!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Уууухууу, вы победили, мы победили!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu011(){
        WinMenu011 = new TextUnit(id, "WinMenu011");
        current = WinMenu011;
        WinMenu011.AddText(
            "...",//Злой трикстер ENG
            "...",//Злой трикстер RUS
            "???",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "???" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu011.AddText(
            "!!!",//Злой трикстер ENG
            "!!!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu012(){
        WinMenu012 = new TextUnit(id, "WinMenu012");
        current = WinMenu012;
        WinMenu012.AddText(
            "what do you mean instead of a meal??",//Злой трикстер ENG
            "в смысле вместо обеда?",//Злой трикстер RUS
            "Victory! Victory instead of a meal!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Победа! Победа вместо обеда!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu012.AddText(
            "Go cook, I wanna eat",//Злой трикстер ENG
            "Пошел готовить, я жрать хочу",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu012.AddText(
            "the monkey’s been solving this level eternity",//Злой трикстер ENG
            "мартышка целую вечность эту задачку решала",//Злой трикстер RUS
            "",//Добрый три��стер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu013(){
        WinMenu013 = new TextUnit(id, "WinMenu013");
        current = WinMenu013;
        WinMenu013.AddText(
            "Woooh, he won...",//Злой трикстер ENG
            "Ууух, выиграл он...",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu013.AddText(
            "It was difficult, admit it, that was hard!",//Злой трикстер ENG
            "Это было сложно, признай, что это было сложно!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu013.AddText(
            "You shall admit it! Admit!",//Злой трикстер ENG
            "Ты должен признать! Признай!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu014(){
        WinMenu014 = new TextUnit(id, "WinMenu014");
        current = WinMenu014;
        WinMenu014.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "I’m super glad, that we have finally met first-class pirate!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Я очень рад, что мы наконец встретили первоклассного пирата!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu014.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Pirates opened a chest before you and sailed to Tortaya Fuga",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Пираты до вас открывали один сундук и уплывали на Тортую Фугу" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu014.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "and other such places, it’s not fair",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "и другие подобные заведения, это бесчестно" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu014.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "good that’s you’re not like that!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "хорошо, что вы не такой!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu015(){
        WinMenu015 = new TextUnit(id, "WinMenu015");
        current = WinMenu015;
        WinMenu015.AddText(
            "Smash these lamn beetles! I mean... collect them!",//Злой трикстер ENG
            "Раздави этих чертовых жуков! То есть... собирай их!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu015.AddText(
            "Aaa, they piss me so much!",//Злой трикстер ENG
            "Ааа, они так бесят!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu015.AddText(
            "You’ll be given money for them after, just smash, gather and smash(collect)!",//Злой трикстер ENG
            "Тебе дадут денег потом за них, просто дави, собирай и дави(собирай)!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu015.AddText(
            "Maybe I will even respect you finally, huh, hahahahah, ahahahahahah!",//Злой трикстер ENG
            "Может, я даже уважать тебя стану, хах, хахахах, ахахахахахах!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu016(){
        WinMenu016 = new TextUnit(id, "WinMenu016");
        current = WinMenu016;
        WinMenu016.AddText(
            "Don’t invite him! He’ll stick to us!",//Злой трикстер ENG
            "Не надо его звать! Еще пришьется к нам!",//Злой трикстер RUS
            "Come visit us time to time, we can talk about something",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Приходите иногда к нам в гости, мы можем там поговорить с вами" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu018(){
        WinMenu018 = new TextUnit(id, "WinMenu018");
        current = WinMenu018;
        WinMenu018.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Oh that Chester, I remember him when he was still alive",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Ох уж этот Сундукер, помню его еще когда он был живым" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu018.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Ha! And you’re still a duruktuktuk! Ha-ha-ha-ha-ha-ha!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ха! А ты остался все таким же дуруктуктуком! Ха-ха-хо-хо-ха-ха!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu018.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Also a cad, it’s obvious - a pirate",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Еще и хам, сразу видно - пират" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu018.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "but you are not like that, you are the best pirate!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "но вы не такой, вы самый лучший пират!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu018.AddText(
            "Seneak!",//Злой трикстер ENG
            "Покиза!",//Злой трикстер RUS
            "@SC@Seneak!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Покиза!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu019(){
        WinMenu019 = new TextUnit(id, "WinMenu019");
        current = WinMenu019;
        WinMenu019.AddText(
            "Jungle, sand, frost, what's next - the ocean??",//Злой трикстер ENG
            "Джунгли, пески, морозы, что дальше - океан??",//Злой трикстер RUS
            "And I love oceans, dolphins swim there!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "А я люблю океан, там дельфины плавают!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu019.AddText(
            "And the sharks! Don't you want to swim there sometime?",//Злой трикстер ENG
            "И акулы! Не хочешь поплавать как-нибудь?",//Злой трикстер RUS
            "You are so evil, Wulf",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Ты такой злой, Вульф" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu019.AddText(
            "Why shouldn’t I be evil",//Злой трикстер ENG
            "А чего ж мне не быть злым",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu019.AddText(
            "if someone suddenly decided to 'support' the monkey",//Злой трикстер ENG
            "если кто-то вдруг решил 'поддержать' мартышку",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu019.AddText(
            "and go on an 'interesting adventure'",//Злой трикстер ENG
            "и отправиться вместе с ним в 'интересное приключение'",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu019.AddText(
            "so you think that I look like Didiana Shonse? No!",//Злой трикстер ENG
            "я по-твоему похож на Дидиана Шонса? Нет!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu019.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Well, at least he had all the teeth, you're right..",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Ну он по крайней мере был со всеми зубами, ты прав.." //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu019.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Come here!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "А ну иди сюда!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu022(){
        WinMenu022 = new TextUnit(id, "WinMenu022");
        current = WinMenu022;
        WinMenu022.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Only you and another pirate were here",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Лишь вы и еще один пират были здесь" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu022.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "but only you managed to win, congratulations!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "но только вы смогли победить, поздравляю!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu023(){
        WinMenu023 = new TextUnit(id, "WinMenu023");
        current = WinMenu023;
        WinMenu023.AddText(
            "Enough. Already. Winning.",//Злой трикстер ENG
            "Хватит. Уже. Побеждать.",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu023.AddText(
            "Otherwise I will soon think that you have brains! And get mad!",//Злой трикстер ENG
            "А то я скоро подумаю, что у тебя есть мозги! И разозлюсь!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu025(){
        WinMenu025 = new TextUnit(id, "WinMenu025");
        current = WinMenu025;
        WinMenu025.AddText(
            "What, the cerebellum has boiled, yeah?",//Злой трикстер ENG
            "Что, мозжечок вскипел, да?",//Злой трикстер RUS
            "Brain, chool",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Мозг, цурачок" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu025.AddText(
            "Get out of here! You!",//Злой трикстер ENG
            "А ты вообще иди отсюда!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu027(){
        WinMenu027 = new TextUnit(id, "WinMenu027");
        current = WinMenu027;
        WinMenu027.AddText(
            "You ought to bring all this gold to us!",//Злой трикстер ENG
            "Чтобы принес все это золото нам!",//Злой трикстер RUS
            "But we will give him most of this money",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Но мы же отдадим ему большую часть этих денег" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu027.AddText(
            "Be quiet, tuktuk!",//Злой трикстер ENG
            "Молчи, туктук!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenuChester_002(){
        WinMenuChester_002 = new TextUnit(id, "WinMenuChester_002");
        current = WinMenuChester_002;
        WinMenuChester_002.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Yohoho and a thousand devils! So you won?",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Йохохо и тысяча чертей! То есть ты выиграл?" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_002.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Hmmm, something is wrong here",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Хммм, что-то тут не так" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_002.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@the rest here have already kicked the bucket, bloody devil!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@остальные тут уже откидывали ласты, вот чертяка!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenuChester_003(){
        WinMenuChester_003 = new TextUnit(id, "WinMenuChester_003");
        current = WinMenuChester_003;
        WinMenuChester_003.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Do I hear coins ringing or it just seems to me??",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Я слышу звон монет или мне кажется??" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_003.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Mmmm, how nice...",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Мммм, как приятно..." //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenuChester_004(){
        WinMenuChester_004 = new TextUnit(id, "WinMenuChester_004");
        current = WinMenuChester_004;
        WinMenuChester_004.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Ha!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ха!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_004.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Ha!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ха!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenuChester_005(){
        WinMenuChester_005 = new TextUnit(id, "WinMenuChester_005");
        current = WinMenuChester_005;
        WinMenuChester_005.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@If you suddenly see my oval pudding, tell me!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Если вдруг увидишь мой овальный пудинг, скажи!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_005.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Otherwise with your long games I started to want to eat...",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@А то с твоими долгими играми мне есть захотелось..." //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenuChester_007(){
        WinMenuChester_007 = new TextUnit(id, "WinMenuChester_007");
        current = WinMenuChester_007;
        WinMenuChester_007.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Ha! Throw a couple of coins",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ха! Подкинь пару монеток" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_007.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@I need to pay off a sinful loan here",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@мне тут на погашение греховного кредита нужно" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_007.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@you have the myriad of them anyway, come on, commander",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@у тебя все равно их тьма, давай, командир" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_007.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Eh.. greedy..",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Эх.. жадина.." //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenuChester_008(){
        WinMenuChester_008 = new TextUnit(id, "WinMenuChester_008");
        current = WinMenuChester_008;
        WinMenuChester_008.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Ha! If you suddenly see a chusy skeleton",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ха! Если вдруг увидешь чузатого скелетика" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_008.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@let me know, he owes me a couple of coins",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@дай знать, он мне задолжал пару монет" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_008.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@His name is Sans. Merci beaucoup!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Зовут его Санс. Мерси боку!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenuChester_009(){
        WinMenuChester_009 = new TextUnit(id, "WinMenuChester_009");
        current = WinMenuChester_009;
        WinMenuChester_009.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Ha! Ha! Ha!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ха! Ха! Ха!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_009.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@You think you're smart?",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ты думаешь, ты умен?" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_009.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@No, friend, just the people who made this mechanism are stupid!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Нет, друг, просто люди, сделавшие этот механизм - глупы!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_009.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@So what if I couldn’t open this chest in my time, leave me alone...",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ну и что, что я не смог время в свое открыть этот сундук, отстань..." //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_009.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@You will still join me later!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ты еще присоединишься ко мне!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenuChester_010(){
        WinMenuChester_010 = new TextUnit(id, "WinMenuChester_010");
        current = WinMenuChester_010;
        WinMenuChester_010.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Whoa whoa whoa! You won! Miracles!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Воу-воу-воу! Ты победил! Чудеса!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_010.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Congratulations, colleague, drink a glass of kom for me",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Поздравляю, коллега, выпей за меня потом кружечку пома" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_010.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@and bring me a little as well, please, please",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@и принеси мне немножко, пожалуйста, прошу" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenuChester_012(){
        WinMenuChester_012 = new TextUnit(id, "WinMenuChester_012");
        current = WinMenuChester_012;
        WinMenuChester_012.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Ha! My old bones can't look at how you go through it",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ха! Мои старые кости не могут смотреть на то, как ты проходишь это" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_012.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@it was terrible",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@это было ужасно" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_012.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@use more help from the Tricksters, otherwise it's so boring",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@используй больше помощи Трикстеров, а то так скучно" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenuChester_013(){
        WinMenuChester_013 = new TextUnit(id, "WinMenuChester_013");
        current = WinMenuChester_013;
        WinMenuChester_013.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Yohoho! It was almost good, millennial!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Йохохо! Это было почти хорошо, миллениал!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_013.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Ha!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ха!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenuChester_014(){
        WinMenuChester_014 = new TextUnit(id, "WinMenuChester_014");
        current = WinMenuChester_014;
        WinMenuChester_014.AddText(
            "So I say, this is terrible...",//Злой трикстер ENG
            "Вот и я говорю, это ужасно...",//Злой трикстер RUS
            "@SC@It’s good that my comrades can’t see it anymore",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Хорошо, что это уже не могут увидеть мои товарищи" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_014.AddText(
            "Rrr..",//Злой трикстер ENG
            "Ррр..",//Злой трикстер RUS
            "You did great!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Вы молодец!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenuChester_015(){
        WinMenuChester_015 = new TextUnit(id, "WinMenuChester_015");
        current = WinMenuChester_015;
        WinMenuChester_015.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Ha!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ха!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_015.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@You're doing fine!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ты молодец!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_015.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Well, you have to praise at least once! Haha!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ну надо ж тебе хоть раз похвалить! Хаха!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenuChester_016(){
        WinMenuChester_016 = new TextUnit(id, "WinMenuChester_016");
        current = WinMenuChester_016;
        WinMenuChester_016.AddText(
            "4",//Злой трикстер ENG
            "4",//Злой трикстер RUS
            "@SC@5",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@5" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_016.AddText(
            "2",//Злой трикстер ENG
            "2",//Злой трикстер RUS
            "@SC@3",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@3" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_016.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@1",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@1" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_016.AddText(
            "Loser! Hhahahha!",//Злой трикстер ENG
            "Луузер! Ххахахха!",//Злой трикстер RUS
            "@SC@Loser! Hhahahha!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Луузер! Ххахахха!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_016.AddText(
            "We are a great team, knuckle!",//Злой трикстер ENG
            "Мы отличная команда, костяшка!",//Злой трикстер RUS
            "@SC@Yes, positive dwarf!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Да, позитивный гном!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_016.AddText(
            "What did you say????",//Злой трикстер ENG
            "Что ты сказал????",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenuChester_017(){
        WinMenuChester_017 = new TextUnit(id, "WinMenuChester_017");
        current = WinMenuChester_017;
        WinMenuChester_017.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Have you heard the story of Keralt? So I don’t...",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Слышал историю о Керальте? Вот и я нет..." //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_017.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@I heard that it’s a cool story and that’s all...",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Слышал, что классная история и все..." //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_017.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Why did I ask? Because I'm a chool, ha!!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Почему я спросил? Турак потому что, ха!!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenuChester_019(){
        WinMenuChester_019 = new TextUnit(id, "WinMenuChester_019");
        current = WinMenuChester_019;
        WinMenuChester_019.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@No, it’s true that it’s better to be a skeleton than a bag of bones",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Нет, ну правда скелетом быть лучше, чем мешком с костями" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_019.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@at least we have no itching, hahaha!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@у нас по крайней мере ничего не чешется, хахаха!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }


    private void CreateText_WinMenuChester_020(){
        WinMenuChester_020 = new TextUnit(id, "WinMenuChester_020");
        current = WinMenuChester_020;
        WinMenuChester_020.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Oh, you won the first time, huh?",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@О, что, первый раз выиграл, да?" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_020.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Well done, no one has done this before",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Молодец, никто так ещё до этого не делал" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_020.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@no one of that 3rd hundred, oh yes",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@ни один из той 3-й сотни, о да" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenuChester_022(){
        WinMenuChester_022 = new TextUnit(id, "WinMenuChester_022");
        current = WinMenuChester_022;
        WinMenuChester_022.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@So, look",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Так, смотри" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_022.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@you take all the gold and send it to Underworld by mail to Mr. Sans",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@забираешь всё золотишко и отправляешь почтой в Андерворлд мистеру Сансу" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_022.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@I'll explain everything later!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Потом всё объясню!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenuChester_023(){
        WinMenuChester_023 = new TextUnit(id, "WinMenuChester_023");
        current = WinMenuChester_023;
        WinMenuChester_023.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Ahahahah.ahahahahaha.ahahahaa",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ахахахах.ахахахахаха.ахахахаа" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_023.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Wait, have you seriously won? Oh..",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Подожди, ты серьёзно выиграл? Ох.." //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenuChester_025(){
        WinMenuChester_025 = new TextUnit(id, "WinMenuChester_025");
        current = WinMenuChester_025;
        WinMenuChester_025.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Wulf told you to get out of here",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Вульф сказал, чтоб ты валил отсюда" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_025.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@I don’t know what he’s talking about, I just passed his words",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Не знаю, о чём он, я просто передал" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenuChester_026(){
        WinMenuChester_026 = new TextUnit(id, "WinMenuChester_026");
        current = WinMenuChester_026;
        WinMenuChester_026.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@You know, I've been living for over a thousand years",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Знаешь, я живу уже более тысячи лет" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_026.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@I even remember the last pirate who lived here",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Я даже помню последнего пирата, который здесь обитал" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_026.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@He was very impatient and loved solitude. And that is me!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Он был очень нетерпеливым и любил одиночество. И это я!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_026.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Go collect our gold before I find my leg knuckle and kill you!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Иди собирай наше золотишко, пока я не нашёл свою костяшку ноги и не убил тебя!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenuChester_027(){
        WinMenuChester_027 = new TextUnit(id, "WinMenuChester_027");
        current = WinMenuChester_027;
        WinMenuChester_027.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Heck! Heck. Heck!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Чёрт! Чёрт. Чёрт!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_027.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@You collect gold again, which I honestly stole from old women!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ты опять собираешь золото, которое я честно воровал у старушек!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenuChester_028(){
        WinMenuChester_028 = new TextUnit(id, "WinMenuChester_028");
        current = WinMenuChester_028;
        WinMenuChester_028.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@lamn savages!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Чёртовы дикари!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_028.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Because of them, your dirty paws touch my rubies!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Из-за них твои грязные лапы трогают мои рубины!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenuChester_031(){
        WinMenuChester_031 = new TextUnit(id, "WinMenuChester_031");
        current = WinMenuChester_031;
        WinMenuChester_031.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@I heard that dumbasses and pirates win",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Слышал, что выигрывают тупицы и пираты" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_031.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@You are not a pirate. Savvy?",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ты не пират. Смекаешь?" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenuChester_033(){
        WinMenuChester_033 = new TextUnit(id, "WinMenuChester_033");
        current = WinMenuChester_033;
        WinMenuChester_033.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@I want, lamn it, to write. I hecking want. Ooooh..",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Хочу, блин, писать. Я чертовски хочу. Уууу.." //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_033.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Ah, no, it seemed",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@А, не, показалось" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenuChester_034(){
        WinMenuChester_034 = new TextUnit(id, "WinMenuChester_034");
        current = WinMenuChester_034;
        WinMenuChester_034.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Why is my life looks like a game?",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Почему моя жизнь похожа на игру?" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_034.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@It's normal to be dead, but alive at the same time, right?",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Это же нормально быть мёртвым, но при этом живым, да?" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenuChester_034.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Oh, these philosophical questions",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ох уж эти философские вопросы" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }


    private void CreateText_WinMenu0achieve_r(){
        WinMenu0achieve_r = new TextUnit(id, "WinMenu0achieve_r");
        current = WinMenu0achieve_r;
        WinMenu0achieve_r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Haha, 0 achievements!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Хаха, 0 достижений!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu0achieve_r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Ahahahha! To collect 0 achievements, what a duruktuktuk! Wulf affects me badly...",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ахахахха! Собрать 0 достижений, ну и дуруктуктук! Вульф на меня плохо влияет..." //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu0achieve_002(){
        WinMenu0achieve_002 = new TextUnit(id, "WinMenu0achieve_002");
        current = WinMenu0achieve_002;
        WinMenu0achieve_002.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@0 achievements ...0 achievements ...0 ...",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@0 достижений...0 достижений...0..." //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu0achieve_002.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Well, at least collect one! Even Wulf can do it! Ha!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ну одно хотя бы собери! Это даже Вульф сможет сделать! Ха!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu0achieve_002.AddText(
            "If you were alive, I would have killed you, knuckle!",//Злой трикстер ENG
            "Будь ты жив, я бы тебя убил, костяшка!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu0achieve_004(){
        WinMenu0achieve_004 = new TextUnit(id, "WinMenu0achieve_004");
        current = WinMenu0achieve_004;
        WinMenu0achieve_004.AddText(
            "0! HAHAHAHA!",//Злой трикстер ENG
            "0! ХАХАХАХА!",//Злой трикстер RUS
            "@SC@0!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@0!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu0achieve_005(){
        WinMenu0achieve_005 = new TextUnit(id, "WinMenu0achieve_005");
        current = WinMenu0achieve_005;
        WinMenu0achieve_005.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Well, can you take at least one asterisk?",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ну одну-то звездочку можешь взять?" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu0achieve_005.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Otherwise ma hommies won't get it",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@А то пацаны не поймут" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }

    private void CreateText_WinMenu3achieve_r(){
        WinMenu3achieve_r = new TextUnit(id, "WinMenu3achieve_r");
        current = WinMenu3achieve_r;
        WinMenu3achieve_r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Wow! Not bad! I respect, pirate!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Воооу! Неплохо! Уважаю, пират!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu3achieve_r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Wooooooooo! You're doing fine! Ha!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Вуууухууу! Ты молодец! Ха!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu3achieve_r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Money, money comes, 3 achievements! Yeah! Ha!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Деньги, денюжки сыпятся, 3 достижения! Дааа! Ха!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu3achieve_003(){
        WinMenu3achieve_003 = new TextUnit(id, "WinMenu3achieve_003");
        current = WinMenu3achieve_003;
        WinMenu3achieve_003.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Wabadubadubdub! That's how you do it!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Вабадабадабдаб! Вот это ты мочишь!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu3achieve_003.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@All 3 achievements! Wooooo!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Все 3 достижения! Вухуу!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu3achieve_003.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Exactly!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Вот именно!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu3achieve_005(){
        WinMenu3achieve_005 = new TextUnit(id, "WinMenu3achieve_005");
        current = WinMenu3achieve_005;
        WinMenu3achieve_005.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@All what’s left...wait, 3 achievements!!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Осталось всего...стоп, 3 достижения!!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu3achieve_005.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Oh yeah!!! Well done!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@О да!!! Молодец!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu3achieve_006(){
        WinMenu3achieve_006 = new TextUnit(id, "WinMenu3achieve_006");
        current = WinMenu3achieve_006;
        WinMenu3achieve_006.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@3! 3!! 3 achievements!!! Have you seen it, huh??",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@3! 3!! 3 достижения!!! Видели, а??" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu3achieve_006.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@None of you, old shriveled pirates, could do this",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Никто из вас, старых пиратов сморщенных не смог это сделать" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu3achieve_006.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@that's why you are here! They grumble, and you're doing stuff!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@поэтому вы и здесь! Они ворчат, а ты молодец!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_WinMenu3achieve_007(){
        WinMenu3achieve_007 = new TextUnit(id, "WinMenu3achieve_007");
        current = WinMenu3achieve_007;
        WinMenu3achieve_007.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@That was long as hell, for sure, you took your time",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Долго, конечно, ты тянул" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu3achieve_007.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@but you managed to take all 3 achievements!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@но смог взять все 3 достижения!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        WinMenu3achieve_007.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Congratulations, bag of bones!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Поздравляю, мешок с костями!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }


    private void CreateText_Location_Jr(){
        Location_Jr = new TextUnit(id, "Location_Jr");
        current = Location_Jr;
        Location_Jr.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "At least it's beautiful here, sometimes",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "По крайней мере тут красиво, иногда" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_Jr.AddText(
            "Oh mushrooms!",//Злой трикстер ENG
            "О, грибы!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_Jr.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "I even saw pink trees here! Very beautiful!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Я видел здесь даже розовые деревья! Очень красиво!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Location_Sar(){
        Location_Sar = new TextUnit(id, "Location_Sar");
        current = Location_Sar;
        Location_Sar.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Hooot",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Жарааа" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_Sar.AddText(
            "The sun! Enough of the oven!",//Злой трикстер ENG
            "Солнце! Хватит печь!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Location_Snr(){
        Location_Snr = new TextUnit(id, "Location_Snr");
        current = Location_Snr;
        Location_Snr.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "I haven't seen a place cooler that this",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Холоднее места я еще не видел" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_Snr.AddText(
            "I'll never a place cooler than this",//Злой трикстер ENG
            "Холоднее места я уже никогда не увижу",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_Snr.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Wow, such beautiful arches!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Ого, какие красивые арки!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_Snr.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Ah, I'd like to climb on one of those peaks!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Эх, вот бы взобраться на одну из этих вершин!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_Snr.AddText(
            "So, monkey, let's quickly finish with this level, okay?????",//Злой трикстер ENG
            "Так, мартышка, давай побыстрее разберемся с этим уровнем, окей?????",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Location_Hr(){
        Location_Hr = new TextUnit(id, "Location_Hr");
        current = Location_Hr;
        Location_Hr.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Wow! These are the most difficult levels! Nobody has opened them yet!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Ого! Это самые сложные уровни! Их никто еще не открывал!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_Hr.AddText(
            "I don’t know why you are here, you can’t open even the easy ones",//Злой трикстер ENG
            "Не знаю, зачем ты тут, ты даже простые не можешь нормально открыть",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_Hr.AddText(
            "Okay, here we can cheer for you, anyway it will not help you",//Злой трикстер ENG
            "Не, ну тут и поболеть можно, все равно тебе это не поможет",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_Hr.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "This is all scary!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Страшно выглядит это все!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_Hr.AddText(
            "Just try not to win!",//Злой трикстер ENG
            "Только попробуй не выиграть!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_Hr.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Cool place!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Крутое место!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Location_Br(){
        Location_Br = new TextUnit(id, "Location_Br");
        current = Location_Br;
        Location_Br.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Oh, this is a boat! Sunken!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "О, это лодка! Затонувшая!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_Br.AddText(
            "Neknus! Taob a si siht, Ho!",//Злой трикстер ENG
            "Яашвунотаз! Акдол отэ, о!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Location_J_001(){
        Location_J_001 = new TextUnit(id, "Location_J_001");
        current = Location_J_001;
        Location_J_001.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Ay, something is creeping over me!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Ай, по мне что-то ползет!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_J_001.AddText(
            "No way, I won’t touch it!",//Злой трикстер ENG
            "Щас, я это трогать не буду!",//Злой трикстер RUS
            "Take it from me, Wulf!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Убери с меня это, Вульф!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_J_001.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Aaaaaa!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Аааааа!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Location_J_002(){
        Location_J_002 = new TextUnit(id, "Location_J_002");
        current = Location_J_002;
        Location_J_002.AddText(
            "Worse place I have not seen",//Злой трикстер ENG
            "Хуже места я еще не видел",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_J_002.AddText(
            "Give me a kub and a fint of kom, not these green bushes",//Злой трикстер ENG
            "Дайте мне каб и финту пома, а не эти зеленые заросли",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_J_002.AddText(
            "aah, it's itching!",//Злой трикстер ENG
            "ааа, чешется!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Location_J_006(){
        Location_J_006 = new TextUnit(id, "Location_J_006");
        current = Location_J_006;
        Location_J_006.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Oh, nostalgia!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Эх, ностальгия!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_J_006.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@We didn’t especially like these savages",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Этих дикарей мы не любили особенно" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_J_006.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@they communicated like monkeys and behaved uncivilized",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@они общались как обезьяны и вели себя некультурно" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_J_006.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@we, pirates, don’t like this",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@мы, пираты, такое не любим" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Location_Sa_002(){
        Location_Sa_002 = new TextUnit(id, "Location_Sa_002");
        current = Location_Sa_002;
        Location_Sa_002.AddText(
            "Is that snake creeping under your feet, Wunsch?",//Злой трикстер ENG
            "Это змея ползет под твоими ногами, Вунш?",//Злой трикстер RUS
            "WHAT?!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "ЧТО?!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Location_Sa_003(){
        Location_Sa_003 = new TextUnit(id, "Location_Sa_003");
        current = Location_Sa_003;
        Location_Sa_003.AddText(
            "Fufufu, scarabs! God I hate insects!",//Злой трикстер ENG
            "Фуфуфу, скарабеи! Как же я ненавижу насекомых!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_Sa_003.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Well, at least in some ways we are alike!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Ну хоть в чем-то мы похожи!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_Sa_003.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Ha! I am with you gentlemen!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ха! Я с вами господа!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Location_Sa_004(){
        Location_Sa_004 = new TextUnit(id, "Location_Sa_004");
        current = Location_Sa_004;
        Location_Sa_004.AddText(
            "We have a sea near our house as well!",//Злой трикстер ENG
            "Море и у нашего дома есть!",//Злой трикстер RUS
            "Well here the sea is close at least!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Ну тут море близко по крайней мере!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_Sa_004.AddText(
            "That's why you got attached to this monkey, I myself completely trust him!",//Злой трикстер ENG
            "Вот зачем ты привязался к этой мартышке, я вот ему полностью доверяю!",//Злой трикстер RUS
            "Do not kid my slippers..",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Не смеши мои тапочки.." //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_Sa_004.AddText(
            "Still home return offer remains",//Злой трикстер ENG
            "Все еще предложение с возвращением домой остается",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Location_Sa_005(){
        Location_Sa_005 = new TextUnit(id, "Location_Sa_005");
        current = Location_Sa_005;
        Location_Sa_005.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Oh, these people, I liked them the most!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ох, этот народ, мне он нравился больше всего!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_Sa_005.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Gears are everywhere, cats are everywhere!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Механизмы повсюду, везде нарисованные коты!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_Sa_005.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@It was they who put these lamn locks with a mechanism in the chests!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Это именно они поставили эти чертовы замки с механизмом в сундуки!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Location_Sn_004(){
        Location_Sn_004 = new TextUnit(id, "Location_Sn_004");
        current = Location_Sn_004;
        Location_Sn_004.AddText(
            "All sorts of runes, arches, ruins..",//Злой трикстер ENG
            "Руны всякие, арки, руины..",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_Sn_004.AddText(
            "it would be better if the damned Kikings did the heating!",//Злой трикстер ENG
            "лучше бы отопление сделали чертовы кикинги!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_Sn_004.AddText(
            "... brrr...",//Злой трикстер ENG
            "...бррр...",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Location_Sn_007(){
        Location_Sn_007 = new TextUnit(id, "Location_Sn_007");
        current = Location_Sn_007;
        Location_Sn_007.AddText(
            "Wh-What the hell is about beauty in here??? I already d-d-don’t feel the legs!",//Злой трикстер ENG
            "К-к-какая к черту красота??? Я уже ног н-н-не чувствую!",//Злой трикстер RUS
            "Look what a beauty, and you're all 'home, home'..",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Посмотри какая красота, а ты все 'домой, домой'.." //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Location_Sn_008(){
        Location_Sn_008 = new TextUnit(id, "Location_Sn_008");
        current = Location_Sn_008;
        Location_Sn_008.AddText(
            "Maybe you won’t talk about it near the monkey, duruktuktuk?",//Злой трикстер ENG
            "Может не будешь об этом говорить при мартышке, дуруктуктук?",//Злой трикстер RUS
            "Mom would like it here, she loved tough, strong people and snow",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Маме бы тут понравилось, она любила жестких, сильных людей и снег" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_Sn_008.AddText(
            "What a tuktuk!",//Злой трикстер ENG
            "Ну и туктук!",//Злой трикстер RUS
            "I trust the master!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Я доверяю господину!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Location_H_003(){
        Location_H_003 = new TextUnit(id, "Location_H_003");
        current = Location_H_003;
        Location_H_003.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Here it will be necessary to think",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Вот тут надо будет подумать" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_H_003.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "and there is no guarantee that even this will help",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "и не факт, что даже это поможет, тут нужна" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_H_003.AddText(
            "\"Think\" ha...",//Злой трикстер ENG
            "\"Подумать\", ха...",//Злой трикстер RUS
            "it probably needs some kind of trick...",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "наверно, какая-то хитрость..." //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Location_H_005(){
        Location_H_005 = new TextUnit(id, "Location_H_005");
        current = Location_H_005;
        Location_H_005.AddText(
            "And take for me as well, at least some benefit will be..",//Злой трикстер ENG
            "И мне возьми, хоть какая-то польза будет..",//Злой трикстер RUS
            "I will root and keep a mug of kom for you!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Буду держать за вас кулачки и кружку пома!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Location_H_006(){
        Location_H_006 = new TextUnit(id, "Location_H_006");
        current = Location_H_006;
        Location_H_006.AddText(
            "Tick-tock, tick-tock...",//Злой трикстер ENG
            "Тик-так, тик-так...",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_H_006.AddText(
            "That's the time that you waste on some bloody useless things",//Злой трикстер ENG
            "Это время, которое ты тратишь на какую-то фигню",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Location_H_006.AddText(
            "instead of opening the right chests!!",//Злой трикстер ENG
            "вместо открывания правильных сундуков!!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Lose_r(){
        Lose_r = new TextUnit(id, "Lose_r");
        current = Lose_r;
        Lose_r.AddText(
            "Rrrr! Let me enjoy the moment!",//Злой трикстер ENG
            "Рррр! Дай насладиться моментом!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_r.AddText(
            "Oooooooooh, yes!!!",//Злой трикстер ENG
            "Уууууу, да!!!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Ohh, that's hurtful... That's ok, don't be upset",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Оооу, обидно... Ничего, не расстраивайся" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_r.AddText(
            "Yeahhhhhh!!!!!",//Злой трикстер ENG
            "Дааааааа!!!!!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Next time you'll get it!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "В следующий раз точно выйдет!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_r.AddText(
            "Aahahahahahahah! In your face, yes !!!!",//Злой трикстер ENG
            "Аахахахахахахах! Так тебе, да!!!!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Hurtful.. But that's alright! Next time will be yours!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Обидно.. Но ничего! В следующий раз точно выйдет!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Why everyone having fun, monsters",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Почему все радуются, изверги" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_r.AddText(
            "Loser!",//Злой трикстер ENG
            "Лузер!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Almost there! Do not give up!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Почти вышло! Не сдавайтесь!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_r.AddText(
            "Kleeeee!",//Злой трикстер ENG
            "Клиии",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_r.AddText(
            "AHAHAHAHAHAH",//Злой трикстер ENG
            "АХАХАХАХА",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_r.AddText(
            "Eeeee boy! Uh, I mean... it's not from here..",//Злой трикстер ENG
            "Ееее бой! Э, в смысле..это не отсюда..",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Nearly! Nearly!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Почти! Почти!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Just a little more!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Еще бы немного!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "You have passed so many levels, and you'll pass this one as well!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Вы столько прошли и это пройдете!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_r.AddText(
            "Pass this lamn level already! AAAA",//Злой трикстер ENG
            "Пройди уже этот чертов уровень! АААА",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Lose_001(){
        Lose_001 = new TextUnit(id, "Lose_001");
        current = Lose_001;
        Lose_001.AddText(
            "Hahahahahahahahhah! Lost! Lost! Haaaaa!",//Злой трикстер ENG
            "Хахахахахахахаххах! Проиграл! Проиграл! Хааааа!",//Злой трикстер RUS
            "Do not offend him! It'll work next time surely!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Не обижай его! В следующий раз обязательно получится!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Lose_002(){
        Lose_002 = new TextUnit(id, "Lose_002");
        current = Lose_002;
        Lose_002.AddText(
            "Or not, ahhahha!",//Злой трикстер ENG
            "Или нет, аххахха!",//Злой трикстер RUS
            "That's ok, next time it’ll work out for sure!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Ничего, в следующий раз точно получится!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Lose_010(){
        Lose_010 = new TextUnit(id, "Lose_010");
        current = Lose_010;
        Lose_010.AddText(
            "This is my favorite day!",//Злой трикстер ENG
            "Это мой любимый день!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_010.AddText(
            "Every day, when the monkey loses - my favorite!",//Злой трикстер ENG
            "Каждый день, когда мартышка проигрывает - мой любимый!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Lose_011(){
        Lose_011 = new TextUnit(id, "Lose_011");
        current = Lose_011;
        Lose_011.AddText(
            "Will work for sure!",//Злой трикстер ENG
            "Точно выйдет!",//Злой трикстер RUS
            "I'm sorry... Next time it...",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Жаль... В следующий раз т..." //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_011.AddText(
            "We got it, seneaky, got it, let us enjoy this magical moment",//Злой трикстер ENG
            "Мы поняли, поклиза, поняли, дай нам насладиться этим волшебным моментом",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Lose_013(){
        Lose_013 = new TextUnit(id, "Lose_013");
        current = Lose_013;
        Lose_013.AddText(
            "Do you hear?",//Злой трикстер ENG
            "Слышишь?",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_013.AddText(
            "Do you hear these amazing fireworks sounds?",//Злой трикстер ENG
            "Слышишь эти восхитительные звуки феерверка?",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_013.AddText(
            "It is all rejoicing that you lost, ahahahaha!",//Злой трикстер ENG
            "Это все радуются, что ты проиграл, ахахахаха!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Lose_014(){
        Lose_014 = new TextUnit(id, "Lose_014");
        current = Lose_014;
        Lose_014.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "I can bring jasmine tea",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Я могу принести чай с жасмином" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_014.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "it can help to forget this misunderstanding",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "он может помочь забыть это недоразумение" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_014.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "though I have to swim back to the island...",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "правда придется сплавать обратно на остров..." //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_014.AddText(
            "I’ll cry .. with laughter! Ahahahahah!",//Злой трикстер ENG
            "Я сейчас заплачу...от смеха! Ахахахахах!",//Злой трикстер RUS
            "But I'll do anything for you!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Но ради вас все, что угодно!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }

   
    private void CreateText_Lose_015(){
        Lose_015 = new TextUnit(id, "Lose_015");
        current = Lose_015;
        Lose_015.AddText(
            "Stop losing already, hey!",//Злой трикстер ENG
            "Вообще, хватит уже проигрывать, эй!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_015.AddText(
            "How long should I wait till you open this lamn chest?",//Злой трикстер ENG
            "Сколько можно ждать, когда ты уже откроешь этот чертов сундук?",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Lose_016(){
        Lose_016 = new TextUnit(id, "Lose_016");
        current = Lose_016;
        Lose_016.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "And the ruins were not built in a day!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "И руины не за день строили!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_016.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "You still have a lot of chances! Let's go!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "У вас еще море шансов! Вперед!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Lose_020(){
        Lose_020 = new TextUnit(id, "Lose_020");
        current = Lose_020;
        Lose_020.AddText(
            "AHAHAHAH",//Злой трикстер ENG
            "АХАХАХА",//Злой трикстер RUS
            "One day you'll win for sure!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Однажды точно победите!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Lose_022(){
        Lose_022 = new TextUnit(id, "Lose_022");
        current = Lose_022;
        Lose_022.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Use the help, the green button on the right so I can help you!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Используйте помощь, зеленую кнопку справа, чтобы я мог вам помочь!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_022.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "*whisper*",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "*шепотом*" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_022.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Only carefully, Wulf can set you up",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Только осторожно, Вульф может подставить вас" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Lose_025(){
        Lose_025 = new TextUnit(id, "Lose_025");
        current = Lose_025;
        Lose_025.AddText(
            "One day you will definitely win!",//Злой трикстер ENG
            "Однажды ты точно победишь!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_025.AddText(
            "I would like to believe, but that's a hard one! Ahahahaha!",//Злой трикстер ENG
            "Хотелось бы верить, но вериться с трудом! Ахахахаха!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Lose_027(){
        Lose_027 = new TextUnit(id, "Lose_027");
        current = Lose_027;
        Lose_027.AddText(
            "Just admit you can never pass this level!",//Злой трикстер ENG
            "Просто признай, ты никогда не сможешь пройти этот уровень!",//Злой трикстер RUS
            "He can!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Сможет!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_027.AddText(
            "Can not!",//Злой трикстер ENG
            "Не сможет!",//Злой трикстер RUS
            "Will be able!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Сможет!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_027.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "@SC@Ha!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ха!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_027.AddText(
            "And what was that?",//Злой трикстер ENG
            "И что это было?",//Злой трикстер RUS
            "@SC@I helped you decide!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Я помог вам определиться!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_027.AddText(
            "No, you didn’t help to decide at all, knuckle!",//Злой трикстер ENG
            "Нет, ты не помог определиться от слова совсем, костяшка!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_027.AddText(
            "Better give us a piece of gold and we will move on",//Злой трикстер ENG
            "Лучше давай нам золотишко и мы пойдем дальше",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_027.AddText(
            "otherwise the monkey will never pass this lamn level",//Злой трикстер ENG
            "а то мартышка никогда не пройдет этот чертов уровень",//Злой трикстер RUS
            "@SC@Let him pass this mechanism at fisrt! Ha! Ha!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Пусть сначала пройдет этот механизм! Ха! Ха!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_027.AddText(
            "This is hopeless",//Злой трикстер ENG
            "Это безнадежно",//Злой трикстер RUS
            "No! He can do it! Come on, I believe in you!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Нет! Он сможет! Давайте, я верю в вас!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_027.AddText(
            "But I don't, the score is equal again!",//Злой трикстер ENG
            "А я нет, счет снова равный!",//Злой трикстер RUS
            "Oh...",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Ох..." //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Lose_030(){
        Lose_030 = new TextUnit(id, "Lose_030");
        current = Lose_030;
        Lose_030.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "As Ingvar Voitenko says",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Как говорит Ингвар Войтенко" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_030.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "'Attack, explode!'",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "'Атакуй, взрывайся!'" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_030.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "This tactic probably won't help you, but it motivated you, right?",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Эта тактика вам не совсем поможет, но она вас смотивировала, правда?" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_030.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Me for sure!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Меня точно!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_Lose_031(){
        Lose_031 = new TextUnit(id, "Lose_031");
        current = Lose_031;
        Lose_031.AddText(
            "So...",//Злой трикстер ENG
            "Так...",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_031.AddText(
            "Let's do it - you pass the level, and I don’t give you anything",//Злой трикстер ENG
            "Давай так сделаем - ты проходишь уровень, а я тебе ничего не даю",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        Lose_031.AddText(
            "Agree? That's great, and now pass this mother level!!!!",//Злой трикстер ENG
            "Договорились? Вот и отлично, а теперь пройди этот мать его уровень!!!!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_lvl_001(){
        lvl_001 = new TextUnit(id, "lvl_001");
        current = lvl_001;
        lvl_001.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Ooooh, it's a colorbomb!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Ууу, это калрбомба!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        lvl_001.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Be careful, paint can get on you!!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Осторожнее, на тебя может краска попасть!!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_lvl_002(){
        lvl_002 = new TextUnit(id, "lvl_002");
        current = lvl_002;
        lvl_002.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "This is a turtleball!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Это черепашебол!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        lvl_002.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "You need to choose your own ball!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Тебе нужно выбрать свой шарик!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        lvl_002.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Do you remember where he was?",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Ты запомнил, где он был?" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_lvl_003(){
        lvl_003 = new TextUnit(id, "lvl_003");
        current = lvl_003;
        lvl_003.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "This is a statball! You can't click on it! I mean, it won't rotate!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Это статбол! Ты не можешь на него нажать! Ну, то есть он не будет крутится!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_lvl_004(){
        lvl_004 = new TextUnit(id, "lvl_004");
        current = lvl_004;
        lvl_004.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Wow! This ancient mechanism is trying to stop you!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Ого! Этот древний механизм пытается вам помешать!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        lvl_004.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "You need to score more points than he and we will win!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Вам нужно набрать больше очков чем он и мы победим!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        lvl_004.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Good luck!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Удачи!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        lvl_004.AddText(
            "Wow! Are you doing this, Chester??",//Злой трикстер ENG
            "Ого! Это ты делаешь, Сундукер??",//Злой трикстер RUS
            "@SC@Ha! I have nothing to do with it!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "@SC@Ха! Я тут не причем!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_home_r(){
        home_r = new TextUnit(id, "home_r");
        current = home_r;
        home_r.AddText(
            "I smell a pirate. Get out!",//Злой трикстер ENG
            "Чувствую запах пирата. Вали!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_r.AddText(
            "You again, knuckle?! Get out, I said!",//Злой трикстер ENG
            "Опять ты, костлявый?! Вали, я сказал!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "I am silent",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Молчу" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_r.AddText(
            "Вали!",//Злой трикстер ENG
            "Get out!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_r.AddText(
            "Go get treasures, duruktuktuk! Go!",//Злой трикстер ENG
            "Сокровища иди добывай, дуруктуктук! Пошёл!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_r.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "You make progress, yes? Well done!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Вы делайте прогресс, да? Молодец!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_r.AddText(
            "It's time to dump someone!",//Злой трикстер ENG
            "Пора бы кому-то свалить!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_home_001(){
        home_001 = new TextUnit(id, "home_001");
        current = home_001;
        home_001.AddText(
            "Who's there? Again you, a piece of a pirate? I am not my brother",//Злой трикстер ENG
            "Кто там? Опять ты, пирата кусок? Я -  не мой брат",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_001.AddText(
            "I will trample you from here to the Far Lands! Get out!",//Злой трикстер ENG
            "я тебя попру отсюда за три девять земель! Вали!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_home_002(){
        home_002 = new TextUnit(id, "home_002");
        current = home_002;
        home_002.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Who is it? Is that you, my friend? Ha. What is it?",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Кто это? Это вы, мой друг? Ха. А что такое?" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_002.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Are you stuck Ha, poor thing, but this is only the beginning!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Вы застряли? Ха, бедняга, а ведь это только начало!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_002.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Be brave, further worse!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Крепитесь, дальше больнее!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_home_004(){
        home_004 = new TextUnit(id, "home_004");
        current = home_004;
        home_004.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "We are already going to sleep, walk along the shore, go to the castle",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Мы уже собираемся спать, погуляйте по берегу, сходите в замок" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_004.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "and in the morning we’ll talk!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "а утром поговорим!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_004.AddText(
            "[From home]",//Злой трикстер ENG
            "[Из дома]",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_004.AddText(
            "Ha, chool, did he really believe there was morning here?",//Злой трикстер ENG
            "Ха, пулупец, он реально поверил, что тут есть утро?",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_004.AddText(
            "Ha-ha-ha",//Злой трикстер ENG
            "Ха-ха-ха",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_004.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Shhh. Goodnight!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Тссс. Доброй ночи!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_home_005(){
        home_005 = new TextUnit(id, "home_005");
        current = home_005;
        home_005.AddText(
            "Did you hear that some shamans appeared in Lowland?",//Злой трикстер ENG
            "Ты слышал, что в Низкоземье появились какие-то шаманы?",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_005.AddText(
            "They speak in some strange words and often repeat",//Злой трикстер ENG
            "Они говорят какими-то странными словами и часто повторяют ",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_005.AddText(
            "\"Reel tok, reel tok, sink abuoot it\"",//Злой трикстер ENG
            "«Рил ток, рил ток, синк эбаут ит»",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_005.AddText(
            "It’s good that we don’t live there",//Злой трикстер ENG
            "Хорошо, что мы там не живём",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_home_006(){
        home_006 = new TextUnit(id, "home_006");
        current = home_006;
        home_006.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Why all my gorgeous green socks suddenly turned purple",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Почему все мои великолепные зелёные носки внезапно стали фиолетовыми" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_006.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "you are lumby!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "ты, лурная башка!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_home_008(){
        home_008 = new TextUnit(id, "home_008");
        current = home_008;
        home_008.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "There are rumors that some weirdo with a sword appeared in Upperlands!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Ходят слухи, что в Верхоземье появился какой-то чудак с мечом!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_008.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "He rides here and there in the city and looks for orders on some monsters",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Ездит по городу и ищет заказы на монстров всяких" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_008.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "And where do we get the monsters from?",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "А откуда у нас монстры?" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_008.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Only you and our king Gnevglaz",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Только ты да король наш Гневглаз" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_008.AddText(
            "What did you say, you green kenout?",//Злой трикстер ENG
            "Что ты сказал, кыло ты зелёное?",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_008.AddText(
            "Do you want to sleep on the floor again?",//Злой трикстер ENG
            "Опять хочешь на полу спать?",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_home_012(){
        home_012 = new TextUnit(id, "home_012");
        current = home_012;
        home_012.AddText(
            "Why does this tuktukok come to us so often?",//Злой трикстер ENG
            "Почему этот туктурок приходит к нам так часто?",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_012.AddText(
            "It’s necessary to put up a fence",//Злой трикстер ENG
            "Надо забор поставить",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_012.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "you have been saying this for five years in a row, go and do it",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "ты говоришь это уже пятый год подряд, пойди и сделай" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_012.AddText(
            "Kass? Have you forgotten all the expressions?",//Злой трикстер ENG
            "Копа? Ты выражения все забыл?",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_012.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Go to hell, I'd better go do some useful things",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Ну тебя, лучше пойду полезными делами займусь" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_012.AddText(
            "AHAHAHA. Well, yes, watching TV shows is now considered useful",//Злой трикстер ENG
            "АХАХАХА. Ну да, смотреть сериалы теперь считается полезным",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_012.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "oh",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "ох" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_012.AddText(
            "And you get out of here, sea rat! He also eavesdrops!",//Злой трикстер ENG
            "А ты иди отсюда, крыса морская! Он ещё и подслушивает!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_home_014(){
        home_014 = new TextUnit(id, "home_014");
        current = home_014;
        home_014.AddText(
            "Heard about the hobbits from the big mainland?",//Злой трикстер ENG
            "Слышал о хоббитах с большого материка?",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_014.AddText(
            "One of them threw some ring into a volcano",//Злой трикстер ENG
            "Один из них кольцо какое-то сбросил в вулкан",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_014.AddText(
            "Check it out, they walked from their home to this volcano",//Злой трикстер ENG
            "Прикинь, они пешком от дома до этого вулкана прошли",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_014.AddText(
            "and then they returned on the eagles",//Злой трикстер ENG
            "а потом на орлах вернулись",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_home_015(){
        home_015 = new TextUnit(id, "home_015");
        current = home_015;
        home_015.AddText(
            "Oh, that tuktukok again! Did you teach him how to open chests?",//Злой трикстер ENG
            "Ох, опять этот туктурок! Ты научил его, как открывать сундуки?",//Злой трикстер RUS
            "Yes",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Да" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_015.AddText(
            "So, what are YOU, face, doing here then??",//Злой трикстер ENG
            "Так, а чего ТЫ, лицо, тут делаешь тогда??",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_015.AddText(
            "Go open the chests!!",//Злой трикстер ENG
            "Иди открывай сундуки!!",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_home_017(){
        home_017 = new TextUnit(id, "home_017");
        current = home_017;
        home_017.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "I can smell the coins!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Я слышу запах монет!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
         home_017.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "But they are few, we need more, monsieur pirate!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Но их мало, нам надо больше, мусье пират!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_home_018(){
        home_018 = new TextUnit(id, "home_018");
        current = home_018;
        home_018.AddText(
            "To Gnevglaz in the castle? Are you out of your mind, green?",//Злой трикстер ENG
            "К Гневглазу в замок? Ты чёкнулся, зелёный?",//Злой трикстер RUS
            "Will we go to the festival this year?",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Мы пойдём в этом году на фестиваль?" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_018.AddText(
            "You work, I just eat there for free, nah",//Злой трикстер ENG
            "Ты работаешь, я там просто ем на халяву, к чёрту",//Злой трикстер RUS
            "Well, we work there anyway",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Ну, мы же всё равно там работаем" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_018.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Then I’ll go alone, this year Sineglazka is already celebrating coming of age",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Тогда пойду один, в этом году Синеглазка уже совершеннолетие празднует" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_018.AddText(
            "Oh... I'm going to sleep",//Злой трикстер ENG
            "Ох... Я спать",//Злой трикстер RUS
            "They say there will be a big firework!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Говорят, там будет большой феерверк!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_018.AddText(
            "To hell",//Злой трикстер ENG
            "К чёрту",//Злой трикстер RUS
            "Night",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Доброй" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_home_020(){
        home_020 = new TextUnit(id, "home_020");
        current = home_020;
        home_020.AddText(
            "Not true! Get out!",//Злой трикстер ENG
            "Неправда! Вали!",//Злой трикстер RUS
            "Oh, you are here again! Nice to see you!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "О, Вы снова здесь! Приятно вас видеть!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_home_021(){
        home_021 = new TextUnit(id, "home_021");
        current = home_021;
        home_021.AddText(
            "Never",//Злой трикстер ENG
            "Никогда",//Злой трикстер RUS
            "When will we go to the Far Lands?",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Когда мы поедем в Дальние Земли?" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_021.AddText(
            "No! We still have things to do here!..And what kind of sweet houses?",//Злой трикстер ENG
            "Нет! У нас есть ещё дела здесь!..А что за сладкие дома?",//Злой трикстер RUS
            "Well, let's go, Wulf, they say there are big sweet houses and..",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Ну давай поедем, Вульф, говорят, там большие сладкие дома и.." //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_021.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "These are houses where they sell yummy sweets",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Это дома, в которых продают вкусняшки" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_021.AddText(
            "What??? Okay, I'll think about it.. Mmmm...",//Злой трикстер ENG
            "Что??? Ладно, я подумаю.. Мммм...",//Злой трикстер RUS
            "they even give sweet ice on sticks!",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "там даже дают лёд сладкий на палочке!" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }

    private void CreateText_home_022(){
        home_022 = new TextUnit(id, "home_022");
        current = home_022;
        home_022.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Have you heard something about secret mechanics?",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "А ты слышал что-то про секретные механики?" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_022.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "I heard that if you click a certain number of times on some green button on the right, during the cooldown, something can change during the game in the cave :)",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Я слышал, что если нажать определённое количество раз по какой-то зеленой кнопочке справа, пока идет кулдаун, то может что-то измениться во время игры в пещере :)" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_home_023(){
        home_023 = new TextUnit(id, "home_023");
        current = home_023;
        home_023.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Have you heard something about secret mechanics?",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "А ты слышал что-то про секретные механики?" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_023.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "I heard that if you click a certain number of times on some green button on the right, during the cooldown, something can change during the game in the cave :)",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Я слышал, что если нажать определённое количество раз по какой-то зеленой кнопочке справа, пока идет кулдаун, то может что-то измениться во время игры в пещере :)" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_home_024(){
        home_024 = new TextUnit(id, "home_024");
        current = home_024;
        home_024.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Have you heard something about secret mechanics?",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "А ты слышал что-то про секретные механики?" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_024.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "I heard that if you click a certain number of times on some green button on the right, during the cooldown, something can change during the game in the cave :)",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Я слышал, что если нажать определённое количество раз по какой-то зеленой кнопочке справа, пока идет кулдаун, то может что-то измениться во время игры в пещере :)" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_home_025(){
        home_025 = new TextUnit(id, "home_025");
        current = home_025;
        home_025.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Have you heard something about secret mechanics?",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "А ты слышал что-то про секретные механики?" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_025.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "I heard that if you click a certain number of times on some green button on the right, during the cooldown, something can change during the game in the cave :)",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Я слышал, что если нажать определённое количество раз по какой-то зеленой кнопочке справа, пока идет кулдаун, то может что-то измениться во время игры в пещере :)" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
    private void CreateText_home_026(){
        home_026 = new TextUnit(id, "home_026");
        current = home_026;
        home_026.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "Have you heard something about secret mechanics?",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "А ты слышал что-то про секретные механики?" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        home_026.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "I heard that if you click a certain number of times on some green button on the right, during the cooldown, something can change during the game in the cave :)",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "Я слышал, что если нажать определённое количество раз по какой-то зеленой кнопочке справа, пока идет кулдаун, то может что-то измениться во время игры в пещере :)" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
}
/*
private void CreateText_Location_J(){
        Location_J = new TextUnit(id, "Location_J");
        current = Location_J;
        Location_J.AddText(
            "",//Злой трикстер ENG
            "",//Злой трикстер RUS
            "",//Добрый трикстер ENG или Сундукер ENG, если в начале текста добавить @SC@, например "@SC@Hello!"
            "" //Добрый трикстер RUS или Сундукер RUS, если в начале текста добавить @SC@, например "@SC@Привет!"
        );
        id++;
    }
*/
[Serializable]
public class TextUnit{ 
    int id; //Идентификатор
    string title; //Наименование
    int num; //Номер текущего текста
    int count; //Кол-во текстов
    List<string> textEng = new List<string>(); //Текста ENG
    List<string> textRus = new List<string>(); //Текста RUS
    List<string> dialogEng = new List<string>(); //2-я часть диалога, первая часть храниться в Текста ENG
    List<string> dialogRus = new List<string>(); //2-я часть диалога, первая часть храниться в Текста RUS

    public TextUnit(int _id, string _name){
        this.id = _id;
        this.title = _name;
        this.count = 0;
        this.num = -1;
    }

    public void AddText(string _textEng, string _textRus, string _dialogEng = "", string _dialogRus = ""){
        textEng.Add(_textEng);
        textRus.Add(_textRus);
        dialogEng.Add(_dialogEng);
        dialogRus.Add(_dialogRus);
        count++;
    }

    public string ReturnText(){
        num++;
        if(info.lang == 0)//ENG
        {
            if(count> num){
                return textEng[num];
            }else{
                //Debug.Log("Ошибка: такого диалога нет");
            }
        }else if (info.lang == 1)//RUS
        {
            if(count> num){
                return textRus[num];
            }else{
                //Debug.Log("Ошибка: такого диалога нет");
            }
        }
        return "";
    }

    public string[] ReturnDialog(){
        num++;
        //Debug.Log(num);
        if(info.lang == 0)//ENG
        {
            if(count> num){
                return new string[]{textEng[num], dialogEng[num]};
            }else{
                //Debug.Log("Ошибка: такого диалога нет");
            }
        }else if (info.lang == 1)//RUS
        {
            if(count> num){
                return new string[]{textRus[num], dialogRus[num]};
            }else{
                //Debug.Log("Ошибка: такого диалога нет");
            }
        }
        return new string[]{"", ""};
    }

    public string ReturnRandomText(){
        int rand = UnityEngine.Random.Range(0, count);
        if(info.lang == 0)//ENG
        {
            return textEng[rand];
        }else if (info.lang == 1)//RUS
        {
            return textRus[rand];
        }
        return "";
    }

    public string[] ReturnRandomDialog(){
        int rand = UnityEngine.Random.Range(0, count);
        if(info.lang == 0)//ENG
        {
            return new string[]{textEng[rand], dialogEng[rand]};
        }else if (info.lang == 1)//RUS
        {
            return new string[]{textRus[rand], dialogRus[rand]};
        }
        return new string[]{"", ""};
    }
}