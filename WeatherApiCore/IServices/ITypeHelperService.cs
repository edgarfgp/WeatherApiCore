namespace WeatherApiCore.IServices
{
    public interface ITypeHelperService
    {
        bool TypeHasProperties<T>(string fields);
    }
}