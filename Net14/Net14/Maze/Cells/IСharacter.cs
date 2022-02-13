namespace Net14.Maze.Cells
{
    public interface IСharacter
    {
        int Coins { get; set; }
        int Hp { get; set; }
        string MessageInMyHead { get; set; }
        Mood Mood { get; set; }
        int Stamina { get; set; }
        char Symbol { get; }

        bool TryToStep(IСharacter chapter);
    }
}