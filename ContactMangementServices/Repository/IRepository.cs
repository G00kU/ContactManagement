using ContactMangementServices.Modal;

public interface ICityRepository
{
    Task<IEnumerable<City>> GetAllAsync();
    Task<City> GetByIdAsync(int id);
    Task AddAsync(City city);
    Task UpdateAsync(City city);
    Task DeleteAsync(int id);
}

public interface IStateRepository
{
    Task<IEnumerable<State>> GetAllAsync();
    Task<State> GetByIdAsync(int id);
    Task AddAsync(State state);
    Task UpdateAsync(State state);
    Task DeleteAsync(int id);
}

public interface ICountryRepository
{
    Task<IEnumerable<Country>> GetAllAsync();
    Task<Country> GetByIdAsync(int id);
    Task AddAsync(Country country);
    Task UpdateAsync(Country country);
    Task DeleteAsync(int id);
}
