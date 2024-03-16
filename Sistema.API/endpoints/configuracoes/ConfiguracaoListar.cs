using Sistema.Application.Interfaces;

namespace Sistema.API.endpoints.configuracoes
{
    /// <summary>
    /// Listar configurações
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">Bad Request</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="500">Internal Server error</response>
    public class ConfiguracaoListar
    {
        
        public static string Template => "/configuracoes";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        //[Authorize(Policy = "EmployeePolicy")]
        public static IResult Action(IConfiguracaoApp configuracaoApp)
        {
            return Results.Ok(configuracaoApp.Listar());
        }
    }
}
