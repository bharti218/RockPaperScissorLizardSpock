namespace rockpaperscissor
{
    public interface IMove
    {
        bool Kills(IMove otherMove);
        string GetMoveName();
    }
}