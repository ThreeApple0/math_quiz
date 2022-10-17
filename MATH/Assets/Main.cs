using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{

    public int[] selectedNum = new int[13];
    public GameObject StartBt;
    public int nowRound = 0;
    public int nowQNum = 0;

    public GameObject GamePn;
    public GameObject ScorePn;
    public Text ScoreTx;

    public GameObject[] QPn = new GameObject[13];
    public Text nowRoundTx;

    public Text AnsTx;
    public int Anscnt;
    public Text AnscntTx;

    public GameObject Obt;
    public GameObject Xbt;
    public GameObject Ansbt;

    public Text QTx;
    //1
    public Text Q1Text_1;

    public int Num1_1;
    public int Num2_1;
    //2
    public Text UnderNumTx_2;
    public Text MainTx_2;

    public int a_2;
    public int b_2;
    //3
    public int[] QNum_3 = new int[5];
    public Text[] QNumTx_3 = new Text[5];

    public int[] AnsNum_3 = new int[4];
    public Text[] AnsNumTx_3 = new Text[4];
    public GameObject AnsPn_3;

    //4
    public int[] AnsNum_4 = new int[3];
    public Text[] QNumTx_4 = new Text[3];
    public int[] QNum_4 = new int[3];

    //5
    public int[] QNum_5 = new int[5];
    public Text[] QNumTx_5 = new Text[5];

    //6
    public int[] QNum_6 = new int[3];
    public Text[] QNumTx_6 = new Text[3];

    // --------------------------------------
    public float Timer = 0;
    public Text TimerTx;
    public bool actTimer = false;
    public GameObject TimeOutPn;
    // Update is called once per frame
    void Update()
    {
        if (actTimer)
        {
            if (Timer > 0)
            {
                Timer -= Time.deltaTime;
                
            }
            else
            {
                Timer = 0;
                TimeOutPn.SetActive(true);
            }
            int sec = Mathf.FloorToInt(Timer);
            float secelse = Timer - sec;

            TimerTx.text = sec + "." + (Mathf.FloorToInt(secelse * 10));
        }
    }

    public void GameStart()
    {
        StartBt.SetActive(false);
        GamePn.SetActive(true);
        Anscnt = 0;
        for (int i = 1; i <= 12; i++)
        {
            selectedNum[i] = 0;
        }
        int cnt = 0;
        while (true)
        {
            if (cnt == 6)
            {
                break;
            }
            int randomnum = Random.Range(1, 7);
            if (selectedNum[randomnum] == 0)
            {
                selectedNum[randomnum] = 1;
                cnt++;
            }
            else
            {
                continue;
            }
        }
        int j = 1;
        while (true)
        {
            if (selectedNum[j] == 1)
            {
                break;
            }
            else
            {
                j++;
            }
        }

        nowRound = 1;
        nowQNum = j;
        NEXT();
    }

    public void NEXT()
    {
        actTimer = true;
        Timer = 15;
        TimeOutPn.SetActive(false);
        nowRoundTx.text = nowRound + "번";
        AnsTx.gameObject.SetActive(false);
        Ansbt.SetActive(true);
        Obt.SetActive(false);
        Xbt.SetActive(false);

        AnscntTx.text = Anscnt + "문제 정답";
        for (int i = 1; i <= 6; i++)
        {
            QPn[i].SetActive(false);
        }
        QPn[nowQNum].SetActive(true);

        if (nowQNum == 1)
        {
            QTx.text = "다음 값은?";
            Num1_1 = Random.Range(10, 21);
            Num2_1 = Random.Range(10, 21);

            Q1Text_1.text = Num1_1 + " X " + Num2_1;

            AnsTx.text = (Num1_1 * Num2_1).ToString();
        }
        else if(nowQNum == 2)
        {
            QTx.text = "다음 값은?";
            a_2 = Random.Range(-20, 21);
            b_2 = Random.Range(-20, 21);

            UnderNumTx_2.text = a_2.ToString();

            if (b_2 < 0)
            {
                MainTx_2.text = "( x - " + Mathf.Abs(b_2) +" )";
            }
            else if(b_2 > 0)
            {
                MainTx_2.text = "( x + " + Mathf.Abs(b_2) + " )";
            }
            else
            {
                MainTx_2.text = "x";
            }
            AnsTx.text = (a_2 + b_2).ToString();
        }
        else if(nowQNum == 3)
        {
            QTx.text = "미분하세요";
            AnsPn_3.SetActive(false);

            for(int i = 1; i <= 4; i++)
            {
                QNum_3[i] = Random.Range(-10, 11);
                if (QNum_3[i] == 0) QNum_3[i] = 1;

                if (i == 1)
                {
                    if (QNum_3[i] > 1)
                    {
                        QNumTx_3[i].text = QNum_3[i].ToString();
                    }
                    else if (QNum_3[i] < -1)
                    {
                        QNumTx_3[i].text = "- " + Mathf.Abs(QNum_3[i]);
                    }
                    else if (QNum_3[i] == 1)
                    {
                        QNumTx_3[i].text = "";
                    }
                    else if (QNum_3[i] == -1)
                    {
                        QNumTx_3[i].text = "- ";
                    }
                    continue;
                }

                if (i == 4)
                {
                    if (QNum_3[i] > 0)
                    {
                        QNumTx_3[i].text = "+ " + QNum_3[i].ToString();
                    }
                    else if (QNum_3[i] < 0)
                    {
                        QNumTx_3[i].text = "- " + Mathf.Abs(QNum_3[i]);
                    }
                    
                    continue;
                }

                if (QNum_3[i] > 1)
                {
                    QNumTx_3[i].text = "+ " + QNum_3[i];
                }
                else if(QNum_3[i] < -1)
                {
                    QNumTx_3[i].text = "- " +Mathf.Abs( QNum_3[i]);
                }
                else if (QNum_3[i] == 1)
                {
                    QNumTx_3[i].text = "+ ";
                }
                else if(QNum_3[i] == -1)
                {
                    QNumTx_3[i].text = "- ";
                }
            }


            for(int i = 1; i <= 3; i++)
            {
                AnsNum_3[i] = QNum_3[i] * (4 - i);


                if (i == 1)
                {
                    if (AnsNum_3[i] > 1)
                    {
                        AnsNumTx_3[i].text = AnsNum_3[i].ToString();
                    }
                    else if (AnsNum_3[i] < -1)
                    {
                        AnsNumTx_3[i].text = "- " + Mathf.Abs(AnsNum_3[i]);
                    }
                    else if (AnsNum_3[i] == 1)
                    {
                        AnsNumTx_3[i].text = "";
                    }
                    else if (AnsNum_3[i] == -1)
                    {
                        AnsNumTx_3[i].text = "- ";
                    }
                    continue;
                }

                if (i == 3)
                {
                    if (AnsNum_3[i] > 0)
                    {
                        AnsNumTx_3[i].text = "+ " + AnsNum_3[i].ToString();
                    }
                    else if (QNum_3[i] < 0)
                    {
                        AnsNumTx_3[i].text = "- " + Mathf.Abs(AnsNum_3[i]);
                    }

                    continue;
                }

                if (AnsNum_3[i] > 1)
                {
                    AnsNumTx_3[i].text = "+ " + AnsNum_3[i];
                }
                else if (AnsNum_3[i] < -1)
                {
                    AnsNumTx_3[i].text = "- " + Mathf.Abs(AnsNum_3[i]);
                }
                else if (AnsNum_3[i] == 1)
                {
                    AnsNumTx_3[i].text = "+ ";
                }
                else if (AnsNum_3[i] == -1)
                {
                    AnsNumTx_3[i].text = "- ";
                }
            }
        }
        else if(nowQNum == 4)
        {
            QTx.text = "인수분해하세요";
            while (true)
            {
                AnsNum_4[1] = Random.Range(-10, 11);
                if (AnsNum_4[1] == 0) AnsNum_4[1] = 1;

                AnsNum_4[2] = Random.Range(-10, 11);
                if (AnsNum_4[2] == 0) AnsNum_4[2] = 1;

                if (AnsNum_4[1] + AnsNum_4[2] == 0)
                {
                    continue;
                }
                break;

            }

            QNum_4[1] = AnsNum_4[1] + AnsNum_4[2];
            QNum_4[2] = AnsNum_4[1] * AnsNum_4[2];

            if(QNum_4[1] > 1)
            {
                QNumTx_4[1].text = "+ " + QNum_4[1];
            }
            else if (QNum_4[1] < -1)
            {
                QNumTx_4[1].text = "- " + Mathf.Abs(QNum_4[1]);
            }
            else if (QNum_4[1] == 1)
            {
                QNumTx_4[1].text = "+ ";
            }
            else if (QNum_4[1] == -1)
            {
                QNumTx_4[1].text = "- ";
            }


            if (QNum_4[2] > 0)
            {
                QNumTx_4[2].text = "+ " + QNum_4[2].ToString();
            }
            else if (QNum_4[2] < 0)
            {
                QNumTx_4[2].text = "- " + Mathf.Abs(QNum_4[2]);
            }


            AnsTx.text = "( X ";

            if (AnsNum_4[1] > 0)
            {
                AnsTx.text = AnsTx.text + " + " + AnsNum_4[1].ToString();
            }
            else if (AnsNum_4[1] < 0)
            {
                AnsTx.text = AnsTx.text + " - " + Mathf.Abs(AnsNum_4[1]);
            }

            AnsTx.text = AnsTx.text + " ) ( X ";

            if (AnsNum_4[2] > 0)
            {
                AnsTx.text = AnsTx.text + " + " + AnsNum_4[2].ToString();
            }
            else if (AnsNum_4[2] < 0)
            {
                AnsTx.text = AnsTx.text + " - " + Mathf.Abs(AnsNum_4[2]);
            }
            AnsTx.text = AnsTx.text + " )";
        }
        else if (nowQNum == 5)
        {
            QTx.text = "다음 값은?";

            QNum_5[1] = Random.Range(2, 5);
            QNum_5[2] = QNum_5[1];

            QNum_5[4] = Random.Range(2, 11);
            QNum_5[3] = QNum_5[4] + Random.Range(0, 4);
            QNum_5[4] = QNum_5[4] * -1;

            for (int i = 1; i<= 4; i++){
                QNumTx_5[i].text = QNum_5[i].ToString();
            }

            if(QNum_5[3] + QNum_5[4] == 0)
            {
                AnsTx.text = "1";
            }
            else
            {
                int ans_5 = QNum_5[1];
                for(int i=1;i< QNum_5[3] + QNum_5[4]; i++)
                {
                    ans_5 *= QNum_5[1];
                }
                AnsTx.text = ans_5.ToString();
            }
        }
        else if(nowQNum == 6)
        {
            QTx.text = "다음 값은?";
            QNum_6[1] = Random.Range(2, 7);
            QNum_6[2] = Random.Range(0, QNum_6[1] + 1);
            QNumTx_6[1].text = QNum_6[1].ToString();
            QNumTx_6[2].text = QNum_6[2].ToString();

            int res_6 = 1;
            for(int i=QNum_6[1];i>= QNum_6[1]- QNum_6[2] + 1; i--)
            {
                res_6 *= i;
            }
            for (int i = QNum_6[2]; i >= 1; i--)
            {
                res_6 /= i;
            }

            AnsTx.text = res_6.ToString();
        }
    }

    public void ShowAns()
    {
        actTimer = false;
        if (nowQNum == 3)
        {
            AnsPn_3.SetActive(true);
        }
        else AnsTx.gameObject.SetActive(true);
        Ansbt.SetActive(false);
        Obt.SetActive(true);
        Xbt.SetActive(true);


    }

    public void OClick()
    {
        Anscnt++;

        if (nowRound == 6)
        {
            GameOver();
            return;
        }

        int j = nowQNum+1;
        while (true)
        {
            if (selectedNum[j] == 1)
            {
                break;
            }
            else
            {
                j++;
            }
        }

        nowRound++;
        nowQNum = j;
        NEXT();
    }

    public void XClick()
    {

        if (nowRound == 6)
        {
            GameOver();
            return;
        }

        int j = nowQNum + 1;
        while (true)
        {
            if (selectedNum[j] == 1)
            {
                break;
            }
            else
            {
                j++;
            }
        }

        nowRound++;
        nowQNum = j;
        NEXT();
    }
    public void GameOver()
    {
        Ansbt.SetActive(false);
        Obt.SetActive(false);
        Xbt.SetActive(false);


        GamePn.SetActive(false);
        ScorePn.SetActive(true);
        ScoreTx.text = "총 정답 "+Anscnt+"문제";

    }

    public void ResetBT()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
