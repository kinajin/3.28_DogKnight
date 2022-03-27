public interface Subject
{
    void RoundNotify();
    void TurnNotify();
}

public interface Observer
{
    void TurnUpdate(int round, int turn);
    void FinishUpdate(bool isFinish);
}
