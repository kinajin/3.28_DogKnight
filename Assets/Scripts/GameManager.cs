using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, Subject
{
    // 1. Singleton Pattern: Instance() method
    private static GameManager _instance;


    public static GameManager Instance()
    {

        if (_instance == null)
        {

            _instance = FindObjectOfType<GameManager>();
            if (_instance == null)
            {

                GameObject container = new GameObject("GameManager");
                _instance = container.AddComponent<GameManager>();


            }




        }


        return _instance;

    }





    // �ʱ�ȭ ���� �ٲ��� �� ��
    private int _gameRound = 0;
    private string _whoseTurn = "Enemy";
    private bool _isEnd = false;

    // delegate: TurnHandler, FinishHandler ����


    delegate void TurnHandler (int round, string turn);
    delegate void FinishHandler (bool isFinish);

    TurnHandler turnHandler;
    FinishHandler finishHandler;












    /// <summary>
    /// 2. RoundNotify:
    /// 1) ���� ���� Enemy�̸� ���� gameRound��
    ///  + Debug.Log($"GameManager: Round {gameRound}.");
    /// 2) TurnNotify() ȣ��
    /// </summary>
    public void RoundNotify()
    {


        if (_isEnd == false && _whoseTurn == "Enemy" )
        {
             Debug.Log($"GameManager:Round{_gameRound}.");
             _gameRound += 1;

        }
    
        TurnNotify();



    }

    /// <summary>
    /// 3. TurnNotify:
    /// 1) whoseTurn update
    ///  + Debug.Log($"GameManager: {_whoseTurn} turn.");
    /// 2) _turnHandler ȣ��
    /// </summary>
    public void TurnNotify()
    {


        if (_isEnd == false)
                {
                    if (_whoseTurn == "Enemy")
                    {
                        Debug.Log($"GameManager: {_whoseTurn} turn.");
                        _whoseTurn = "Player";
                    }
                
                    else if (_whoseTurn == "Player")
                    {
                        Debug.Log($"GameManager: {_whoseTurn} turn.");
                        _whoseTurn = "Enemy";
                    }

                }







    }

    /// <summary>
    /// 4. EndNotify: 
    /// 1) isEnd update
    ///  + Debug.Log("GameManager: The End");
    ///  + Debug.Log($"GameManager: {_whoseTurn} is Win!");
    /// 2) _finishHandler ȣ��
    /// </summary>
    public void EndNotify()
    {

        _isEnd = true;
        Debug.Log("GameManager: The End");
        Debug.Log($"GameManager: {_whoseTurn} is Win!");
        finishHandler(_isEnd);

    }

    // 5. AddCharacter: _turnHandler, _finishHandler ������ �޼ҵ� �߰�
    public void AddCharacter(Character character)
    {

        turnHandler += new TurnHandler(character.TurnUpdate);
        finishHandler += new FinishHandler (character.FinishUpdate);



    }
}
