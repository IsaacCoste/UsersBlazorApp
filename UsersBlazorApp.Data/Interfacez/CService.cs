namespace UsersBlazorApp.Data.Interfacez;
public interface CService<C>
{
    Task<List<C>> GetAll();
    Task<C> Get(int id);
    Task<C> Add(C property);
    Task<bool> Update(C property);
    Task<bool> Delete(int id);
}
