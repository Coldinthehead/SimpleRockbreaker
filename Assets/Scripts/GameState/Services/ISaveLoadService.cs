namespace Scripts.GameState.Services
{
    public interface ISaveLoadService : IService
    {
        public void Save();
        public void Load();
    }
}