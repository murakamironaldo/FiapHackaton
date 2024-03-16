using Sistema.Application.Interfaces;

namespace Sistema.API.endpoints.usuarios
{
    public class UsuarioCarregar
    {
        
        public static string Template => "/usuarios/{id}";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        //[Authorize(Policy = "EmployeePolicy")]
        public static IResult Action(IUsuarioApp usuarioService, Guid id)
        {
            var userObj= usuarioService.Carregar(id);
        
            return Results.Ok(userObj);
        }
    }
}
