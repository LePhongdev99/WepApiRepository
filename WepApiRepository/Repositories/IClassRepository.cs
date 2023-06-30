using WepApiRepository.Model;

namespace WepApiRepository.Repositories
{
    public interface IClassRepository : IDisposable
    {
        List<Class> GetClasses();
        Class GetClass(int id);
        void DeleteClass(int id);
        void InsertClass(int id, string name);
        void UpdateClass(int id, string name);
        void Save();
    }
}
