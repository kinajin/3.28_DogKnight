using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, Subject
{
    // 1. Singleton Pattern: Instance() method
    private static GameManager _instance;


    private int gameRound = 0;
    private int whoseTurn = 1;
    private bool isEnd = false;

    // delegate: TurnHandler, FinishHandler 선언

    // 2. Enemy까지 공격을 마치면 gameRound++ -> TurnNotify() 호출
    public void RoundNotify()
    {
        //Debug.Log($"PlayerManager: Round {gameRound}.");
    }

    // 3. whoseTurn update, _turnHandler 호출
    public void TurnNotify()
    {
        //Debug.Log($"PlayerManager: player {whoseTurn} turn.");
    }

    // 4. isEnd update, _finishHandler 호출
    public void EndNotify(string name)
    {
        //Debug.Log("PlayerManager: The End");
        //Debug.Log($"PlayerManager: Character {name} is Win!");
    }

    // 5. _turnHandler, _finishHandler 각각에 메소드 추가
    public void AddCharacter(Character character)
    {

    }
}
