namespace rockpaperscissor
{
    public interface IMove
    {
        bool Kills(IMove otherMove);
        GameData.MOVE GetMoveName();
    }
}