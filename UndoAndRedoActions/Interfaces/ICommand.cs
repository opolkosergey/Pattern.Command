namespace UndoAndRedoActions.Interfaces
{
    public interface ICommand
    {
        void DoAction();

        void UndoAction();
    }
}
