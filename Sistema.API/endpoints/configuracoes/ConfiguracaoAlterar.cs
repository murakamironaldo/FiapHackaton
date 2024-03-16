using Sistema.Application.Interfaces;

namespace Sistema.API.endpoints.configuracoes
{
    public class ConfiguracaoAlterar
    {
        public static string Template => "/configuracoes";
        public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handle => Action;



        //[Authorize(Policy = "EmployeePolicy")]
        public static IResult Action(IConfiguracaoApp configuracaoApp, ConfiguracaoRequest obj)
        {
            try
            {
                Guid.TryParse(obj.id, out Guid id);
                configuracaoApp.Alterar(id, obj.valor);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.BadRequest("Erro durante a gravação, por favor tente novamente.");
            }
            
        }

    }
}
