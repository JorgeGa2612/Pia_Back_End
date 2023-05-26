namespace PiaTienda.Services
{
    public interface Iconfigcorreo
    {
        Task SendEmailAsync(correorequest mailRequest);
    }
}
