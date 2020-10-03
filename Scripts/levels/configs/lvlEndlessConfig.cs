using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlEndlessConfig : MonoBehaviour
{
    const int MaxSpawnSize = 10+1;
    static public bool isReboot = false;
    static public bool colorbombOn = false;
    static public bool tortoiseOn = false;
    static public bool botOn = false;
    static public bool StatOn = false;
    static public int stepsMem = 0;
    static public int timerMem = 0;
    //static public int trickHelpMem = 0;
    private StatBallVar[] statBallVar = new StatBallVar[MaxSpawnSize];

    void Start()
    {
        //Основное
        if(!isReboot){
            spawn.field_size = Random.Range(4,11); //Размер поля
            info.steps = Random.Range(0, 50); // Кол-во ходов, 0 - показывает кол-во ходов, >0 - убывающее кол-во ходов
            if (info.steps < 10) info.steps = 0;
            stepsMem = info.steps;
            info.stat_balls = new int[]{};//Не трогать!
            info.timersecond = Random.Range(0, 100); // Кол-во секунд, 0 - показывает время игры, >0 - убывающий таймер
            if (info.timersecond < 20) info.timersecond = 0;
            timerMem = info.timersecond;
            info.winBall = Random.Range(0, 4); // Победный цвет: 0-blue, 1- yellow, 2- green, 3-red;

        //Включение дополнительного 

            StatOn = Random.Range(0,4)==1?true:false; //25%
            
            if(StatOn){

                for (int i = 0; i < MaxSpawnSize; i++){
                    statBallVar[i] = new StatBallVar(i);
                }
                // Как добавлять: statBallVar[/*размер поля*/].Add(new int[]{/*здесь перечисляешь номера шариков, начиная от 0*/});
                // Пример для поля размером 3: statBallVar[3].Add(new int[] {0,4,8});
                statBallVar[4].Add(new int[] {5,6,9,10});  
                statBallVar[4].Add(new int[] {2,5,10,13});
                statBallVar[4].Add(new int[] {0,1,2,3,4,7,8,11,12,13,14,15});
                statBallVar[4].Add(new int[] {3,6,9,12});
                statBallVar[4].Add(new int[] {0,5,10,15});
                statBallVar[4].Add(new int[] {0,3,5,6,9,10,12,15});
                statBallVar[4].Add(new int[] {1,2,3,7,9,11,13});
                statBallVar[4].Add(new int[] {1,7,8,14});
                statBallVar[4].Add(new int[] {1,2,4,7,8,11,13,14});
                statBallVar[4].Add(new int[] {0,2,3,4,7,8,9,11,12,15});
                statBallVar[5].Add(new int[] {3,7,8,12,16,17,21});
                statBallVar[5].Add(new int[] {2,7,10,11,12,13,14,17,22});
                statBallVar[5].Add(new int[] {4,8,12,16,20});
                statBallVar[5].Add(new int[] {2,7,12,17,22});
                statBallVar[5].Add(new int[] {0,4,7,11,12,13,17,20,24});
                statBallVar[5].Add(new int[] {12});
                statBallVar[5].Add(new int[] {0,1,3,4,5,9,15,19,20,21,23,24});
                statBallVar[5].Add(new int[] {2,6,8,11,13,18,22});
                statBallVar[5].Add(new int[] {6,7,8,10,11,13,14,22});
                statBallVar[5].Add(new int[] {0,6,12,18,24});
                statBallVar[6].Add(new int[] {5,10,15,20,25,30});
                statBallVar[6].Add(new int[] {0,7,14,21,28,35});
                statBallVar[6].Add(new int[] {0,5,7,10,14,15,20,21,25,28,30,35});
                statBallVar[6].Add(new int[] {1,2,3,11,12,14,15,17,18,20,21,23,31,32,33,34});
                statBallVar[6].Add(new int[] {1,2,3,4,12,13,14,15,16,17,18,19,20,21,22,23,31,32,33,34});
                statBallVar[6].Add(new int[] {1,2,3,11,12,17,18,23,31,32,33,34});
                statBallVar[6].Add(new int[] {0,1,2,3,4,5,6,7,10,11,12,17,18,23,24,25,28,29,30,31,32,33,34,35});
                statBallVar[6].Add(new int[] {0,1,2,3,4,5,6,11,12,13,14,17,18,22,23,24,26,29,30,31,32,33,34,35});
                statBallVar[6].Add(new int[] {6,7,9,10,18,19,22,23,26,32,35});
                statBallVar[6].Add(new int[] {0,5,7,8,10,13,22,25,27,28,30,35});
                statBallVar[7].Add(new int[] {8,9,10,11,12,15,16,17,18,19,22,23,24,25,26,29,30,31,32,33,36,37,38,39,40}); 
                statBallVar[7].Add(new int[] {10,16,18,22,26,30,32,38}); 
                statBallVar[7].Add(new int[] {8,9,11,12,15,19,21,24,27,29,33,36,37,39,40}); 
                statBallVar[7].Add(new int[] {0,3,6,16,18,21,24,27,30,32,42,45,48}); 
                statBallVar[7].Add(new int[] {0,6,8,12,17,23,24,25,31,36,40,42,48}); 
                statBallVar[7].Add(new int[] {10,17,22,23,24,25,26,31,38}); 
                statBallVar[7].Add(new int[] {6,12,18,24,30,36,42}); 
                statBallVar[7].Add(new int[] {0,8,16,24,32,40,48}); 
                statBallVar[7].Add(new int[] {0,6,8,12,16,18,24,20,32,36,40,42,48});
                statBallVar[7].Add(new int[] {0,3,6,8,12,16,17,18,24,20,31,32,36,40,42,45,48}); 
                statBallVar[7].Add(new int[] {0,3,6,8,12,16,17,18,23,24,25,20,31,32,36,40,42,45,48}); 
                statBallVar[7].Add(new int[] {0,3,6,8,12,16,17,18,23,24,25,20,21,27,31,32,36,40,42,45,48}); 
                statBallVar[7].Add(new int[] {6,8,9,11,13,15,17,18,19,21,24,26,27,28,30,31,34,37,40,41}); 
                statBallVar[7].Add(new int[] {1,5,8,12,15,16,17,18,19,22,26,30,32,37,39,45}); 
                statBallVar[7].Add(new int[] {1,2,3,4,8,12,15,18,22,23,24,25,26,29,32,36,40,43,44,45,46}); 
                statBallVar[7].Add(new int[] {10,16,18,22,26,29,31,33,37,39}); 
                statBallVar[7].Add(new int[] {1,3,5,8,10,12,17,21,22,23,24,25,26,27,31,36,38,40,43,45,47});
                statBallVar[7].Add(new int[] {8,12,15,19,21,22,23,24,25,26,27,29,32,37,39,44}); 
                statBallVar[7].Add(new int[] {3,8,9,10,14,17,18,19,24,31,33,36,37,38,39,45}); 
                statBallVar[8].Add(new int[] {0,9,18,27,36,45,54,63}); 
                statBallVar[8].Add(new int[] {7,14,21,28,35,42,49,56}); 
                statBallVar[8].Add(new int[] {0,9,18,7,14,21,42,49,56,45,54,63});
                statBallVar[8].Add(new int[] {0,9,18,27,36,45,54,63,7,14,21,28,35,42,49,56}); 
                statBallVar[8].Add(new int[] {9,18,27,36,45,54,14,21,28,35,42,49,43,44,51,52,59,60,19,20,11,12,3,4});
                statBallVar[8].Add(new int[] {3,4,11,12,19,20,43,44,51,52,59,60}); 
                statBallVar[8].Add(new int[] {3,4,11,12,19,20,27,28,35,36,43,44,51,52,59,60,24,25,26,32,33,34,37,38,39,29,30,31}); 
                statBallVar[8].Add(new int[] {0,7,10,16,17,18,20,21,22,23,26,34,41,42,43,44,45,46,50,56,58,63}); 
                statBallVar[8].Add(new int[] {0,7,10,13,16,17,18,20,21,22,26,29,34,37,41,42,43,44,45,46,47,50,53,56,58,63}); 
                statBallVar[8].Add(new int[] {0,1,9,10,12,13,18,21,22,23,26,27,28,29,31,35,36,42,43,44,52,53,56,57,61,62}); 
                statBallVar[8].Add(new int[] {16,17,18,19,20,21,22,23,26,29,34,37,42,45,50,51,52,53}); 
                statBallVar[9].Add(new int[] {0,8,10,12,14,16,20,24,28,30,32,34,40,46,48,50,52,56,60,64,66,68,70,72,80}); 
                statBallVar[9].Add(new int[] {4,12,14,20,24,28,34,36,44,46,52,52,60,66,68,76}); 
                statBallVar[9].Add(new int[] {0,2,3,5,6,8,18,20,21,23,34,36,38,39,41,42,44,54,56,57,59,60,62,72,74,75,77,78,80}); 
                statBallVar[9].Add(new int[] {8,16,24,32,40,48,56,64,72}); 
                statBallVar[9].Add(new int[] {0,10,20,30,40,50,60,70,80}); 
                statBallVar[9].Add(new int[] {8,16,24,32,40,48,56,64,72,0,10,20,30,50,60,70,80}); 
                statBallVar[9].Add(new int[] {8,16,24,32,40,48,56,64,72,0,10,20,30,50,60,70,80,1,2,3,4,5,6,7,73,74,75,76,77,78,79}); 
                statBallVar[9].Add(new int[] {8,16,24,32,40,48,56,64,72,0,10,20,30,50,60,70,80,1,2,3,4,5,6,7,73,74,75,76,77,78,79,63,54,45,36,27,18,9,17,26,35,44,53,62,71}); 
                statBallVar[9].Add(new int[] {0,2,6,9,12,15,17,18,19,21,24,27,30,31,32,33,34,38,45,47,48,49,51,52,58,60,64,65,67,69,72,77,80});
                statBallVar[9].Add(new int[] {4,12,22,32,40,48,58,68,76}); 
                statBallVar[9].Add(new int[] {4,18,20,22,24,26,40,45,47,51,53,57,59,67,75,77}); 
                statBallVar[9].Add(new int[] {0,2,4,6,8,9,13,17,18,20,22,24,26,27,29,31,33,35,36,38,42,44,45,47,49,51,53,54,56,58,60,62,63,67,71,72,74,76,78,80}); 
                statBallVar[9].Add(new int[] {4,13,22,31,40,49,58,67,76,36,37,38,39,40,41,42,43,44}); 
                statBallVar[9].Add(new int[] {4,13,22,31,40,49,58,67,76,36,37,38,39,40,41,42,43,44,10,20,30,50,60,70,16,24,32,48,56,64}); 
                statBallVar[9].Add(new int[] {4,13,22,31,40,49,58,67,76,36,37,38,39,40,41,42,43,44,0,20,30,50,60,80,8,24,32,48,56,72,63,54,45,27,18,9,17,26,35,53,62,71,73,74,75,77,78,79,1,2,3,5,6,7}); 
                statBallVar[9].Add(new int[] {0,1,2,3,4,5,6,7,8,10,16,20,24,28,30,32,34,40,46,48,50,52,56,60,64,70,72,73,74,75,76,77,78,79,80}); 
                statBallVar[9].Add(new int[] {0,1,2,3,4,5,6,7,8,9,13,17,18,22,26,27,28,29,30,31,32,33,34,35,36,44,45,46,47,48,49,50,51,52,53,54,58,62,63,67,71,72,73,74,75,76,77,78,79,80}); 
                statBallVar[9].Add(new int[] {0,2,4,6,8,18,20,22,24,26,27,29,33,35,39,41,45,47,51,53,57,59,67,75,77}); 
                statBallVar[9].Add(new int[] {0,9,18,27,36,45,54,2,11,20,29,38,47,56,3,57,75,4,13,22,40,49,58,67,76,5,59,77,6,15,24,33,42,51,60,8,17,26,35,44,53,62}); 
                statBallVar[9].Add(new int[] {3,4,5,6,9,11,12,17,18,21,26,27,30,35,36,39,40,41,42,43,44,45,46,47,48,51,57,60,66,68,69,75}); 
                statBallVar[9].Add(new int[] {9,10,11,12,13,14,16,21,23,25,30,32,33,34,39,43,45,46,47,48,49,50,52,57,61,66,70,75,79}); 
                statBallVar[9].Add(new int[] {0,1,2,3,4,5,6,7,8,9,18,27,36,45,54,63,72,73,74,75,76,77,78,79,70,61,52,43,34,25,24,23,22,21,20,29,38,47,56,57,58,59,50,41,40}); 
                statBallVar[9].Add(new int[] {71,62,53,44,35,26,17,8,7,6,5,4,3,2,1,0,9,18,27,36,45,54,63,64,65,66,67,68,69,60,51,42,33,24,23,22,21,20,29,38,47,48,49,40,80}); 
                statBallVar[10].Add(new int[] {0,11,22,33,44,55,66,77,88,99}); 
                statBallVar[10].Add(new int[] {9,18,27,36,45,54,63,72,81,90}); 
                statBallVar[10].Add(new int[] {0,11,22,33,44,55,66,77,88,99,9,18,27,36,45,54,63,72,81,90}); 
                statBallVar[10].Add(new int[] {0,11,22,33,66,77,88,99,9,18,27,36,63,72,81,90}); 
                statBallVar[10].Add(new int[] {0,11,22,33,44,55,66,77,88,99,9,18,27,36,45,54,63,72,81,90,64,65,74,75,34,35,24,25}); 
                statBallVar[10].Add(new int[] {0,11,22,33,44,55,66,77,88,99,9,18,27,36,45,54,63,72,81,90,64,65,74,75,34,35,24,25,53,52,51,43,42,41,56,57,58,46,47,48,84,85,14,15}); 
                statBallVar[10].Add(new int[] {4,5,14,15,24,25,34,35,40,41,42,47,48,49,50,51,52,57,58,59,64,65,74,75,84,85,94,95}); 
                statBallVar[10].Add(new int[] {14,15,24,25,34,35,44,45,54,55,64,65,74,75,84,85,53,52,51,43,42,41,56,57,58,46,47,48}); 
                statBallVar[10].Add(new int[] {11,13,18,23,31,32,33,35,36,37,38,43,53,62,63,64,65,66,67,73,81,83,88}); 
                statBallVar[10].Add(new int[] {11,13,18,23,26,31,32,33,35,36,37,38,43,46,53,56,61,62,63,64,65,66,67,68,73,76,81,83,88}); 
                statBallVar[10].Add(new int[] {11,12,15,22,23,25,26,33,36,37,38,43,44,45,46,48,54,55,63,64,65,72,73,75,76,81,82,86,87}); 
                statBallVar[10].Add(new int[] {31,32,33,34,35,36,37,38,43,46,53,56,63,66,73,74,75,76}); 
                statBallVar[10].Add(new int[] {11,12,13,15,18,22,23,25,26,31,32,33,34,35,36,37,38,43,44,45,46,48,53,54,55,56,61,62,63,64,65,66,67,68,72,73,74,75,76,81,82,83,86,87,88}); 
                statBallVar[10].Add(new int[] {0,4,5,9,11,14,15,18,22,24,25,27,33,34,35,36,43,44,45,46,54,55,63,64,65,66,70,72,74,75,77,79,81,88}); 
                statBallVar[10].Add(new int[] {2,4,5,6,8,12,15,18,21,22,23,25,26,28,33,35,36,41,42,43,46,47,48,49,53,55,58,61,62,63,64,65,66,68,72,75,76,82,83,86,92}); 
                statBallVar[10].Add(new int[] {0,9,10,11,18,19,21,22,27,28,32,33,36,37,42,43,44,45,46,47,51,54,55,58,63,66,72,77,81,88,90,99}); 
                statBallVar[10].Add(new int[] {4,14,19,22,23,24,27,29,32,37,38,39,41,42,43,44,45,46,47,53,62,63,64,72,74,75,76,77,80,81,82,87,96,97}); 
                statBallVar[10].Add(new int[] {10,11,12,13,14,15,16,17,18,19,30,31,32,33,34,35,36,37,38,39,50,51,52,53,54,55,56,57,58,59,70,71,72,73,74,75,76,77,78,79,90,91,92,93,94,95,96,97,98,99}); 
                statBallVar[10].Add(new int[] {11,12,13,14,15,16,17,18,30,32,33,34,35,36,37,38,51,52,53,54,55,56,57,58,70,72,73,74,75,76,77,78,90,91,92,93,94,95,96,97,98,99,2,8,22,28,42,48,62,68,82,88}); 
                statBallVar[10].Add(new int[] {0,1,2,3,4,5,6,7,8,9,10,11,13,14,15,16,18,19,24,25,34,35,40,41,44,45,48,49,50,51,52,53,54,55,56,57,58,59,63,64,65,66,74,75,83,84,85,86,94,95}); 


                // Конец объявления шаблонов StatBall'ов

                switch (spawn.field_size) //4..9
                {
                    case 4: info.stat_balls = statBallVar[4].RandomMass(); break;
                    case 5: info.stat_balls = statBallVar[5].RandomMass(); break;
                    case 6: info.stat_balls = statBallVar[6].RandomMass(); break;
                    case 7: info.stat_balls = statBallVar[7].RandomMass(); break;
                    case 8: info.stat_balls = statBallVar[8].RandomMass(); break;
                    case 9: info.stat_balls = statBallVar[9].RandomMass(); break;
                    case 10: info.stat_balls = statBallVar[10].RandomMass(); break;
                }
            }

            colorBall.timeForExplosion = Random.Range(15,30); //Время между взрывами ColorBall'а  [9...]
            colorBall.quantity = Random.Range(1,4); //Кол-во ColorBall'а
            GetComponent<colorBall>().enabled = Random.Range(0,2)==0?false:true; //Вкл ColorBall'а
            colorbombOn = GetComponent<colorBall>().enabled;
       
            tortoiseBall.timeForExplosion = Random.Range(15,30); //Время между взрывами TortoiseBall'а  [9...]
            tortoiseBall.quantity = Random.Range(2,4); //Кол-во TortoiseBall'а
            GetComponent<tortoiseBall>().enabled = Random.Range(0,2)==0?false:true; //Вкл TortoiseBall'а
            tortoiseOn = GetComponent<tortoiseBall>().enabled;
       
            GetComponent<trickHelp>().quantity = Random.Range(2,8); //Кол-во облаков (Мб сделать случайным?)

            if(StatOn){
                GetComponent<Bot>().enabled = false; //Вкл бота (EVA)
                botOn = false;
            } 
            else{
                GetComponent<Bot>().enabled = Random.Range(0,10)>0?false:true; //Вкл бота (EVA)
                botOn = GetComponent<Bot>().enabled;
                if(botOn) {
                    Debug.Log("botOn");
                    info.timersecond = 0;
                    info.steps = Random.Range(10, 26); // Кол-во ходов, 0 - показывает кол-во ходов, >0 - убывающее кол-во ходов
                }
                do info.botColor = Random.Range(0,4); //Цвет победы бота: 0-blue, 1- yellow, 2- green, 3-red;
                while (info.botColor == info.winBall);
            }
            //endlessScore.trickHelpNum = Random.Range(2,5);
            //trickHelpMem = endlessScore.trickHelpNum;
        }else{
            info.steps = stepsMem;
            info.timersecond = timerMem;
            //endlessScore.trickHelpNum = trickHelpMem;
        }

        //================================================================================================

        if(!GetComponent<Bot>().enabled) info.botActive = false;
        
        info.isEndless = true;

        info.field_size = spawn.field_size;

        if (info.steps > 0){ //Вкл шагометра
            info.stepGo = true;
            info.configStep = info.steps;
        }else{
            info.stepGo = false;
        }
        if (info.timersecond > 0){ //Вкл таймер
            info.timerGo = true;
            info.configTime = info.timersecond;
        }else{
            info.timerGo = false;
        }

        if(GetComponent<tortoiseBall>().enabled)
            GetComponent<tortoiseBall>().lvlActive = true;

        GetComponent<spawn>().enabled = true;
    }
}

public class StatBallVar{
    private int spawnSize;
    private int count = 0;
    private List<int[]> mass = new List<int[]>();

    public StatBallVar(int size){
        this.spawnSize = size;
    }

    public void Add(int[] inputMass){
        mass.Add(inputMass);
        count++;
    }

    public int[] RandomMass(){
        if(mass.Count != 0){
            int rand = Random.Range(0, count);
            return mass[rand];
        }else{
            return new int[]{};
        }
    }
}