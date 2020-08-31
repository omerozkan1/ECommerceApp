namespace DreamsBytes.ECommerce.Business.Interfaces
{
    public interface IValidator<T>
    {
        string ErrorMessage { get; set; }
        bool Validate(T entity);
    }
}
