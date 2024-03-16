using Sistema.Application.Interfaces;

namespace Sistema.API.endpoints.configuracoes
{
    public class ConfiguracaoCarregar
    {
        
        public static string Template => "/configuracoes/{id}";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        //[Authorize(Policy = "EmployeePolicy")]
        public static IResult Action(IConfiguracaoApp configuracaoApp, string id)
        {
            Guid.TryParse(id, out Guid guidId);
            var obj =  Results.Ok(configuracaoApp.Carregar(guidId));
            return obj;
        }
    }
}
